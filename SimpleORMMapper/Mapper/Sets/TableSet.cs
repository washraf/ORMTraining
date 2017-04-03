using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mapper.Attibutes;
using Mapper.Helpers;
using Mapper.Mappers;

namespace Mapper.Sets
{
    public class TableSet<TEntityType> where TEntityType : class, new()
    {
        private SqlConnection _connection;
        private EntityMapper<TEntityType> _mapper;

        public TableSet(SqlConnection con)
        {
            _connection = con;
            _mapper = new EntityMapper<TEntityType>(_connection);
        }

        public IEnumerable<TEntityType> GetAll()
        {
            string classtype = typeof(TEntityType).Name;
            string cmd = $"select * from {classtype}";
            var dt = SqlHelpers.GetDataTable(_connection, cmd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yield return _mapper.ConvertToEntity(dt.Rows[i]);
            }
        }

        public IEnumerable<TEntityType> GetByKeyValue(string condition,List<SqlParameter> parameters)
        {
            string classtype = typeof(TEntityType).Name;
            string cmd = $"select * from {classtype} where {condition}";
            var dt = SqlHelpers.GetDataTable(_connection, cmd, parameters);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yield return _mapper.ConvertToEntity(dt.Rows[i]);
            }
        }

        public int Add(TEntityType item)
        {
            var props = typeof(TEntityType).GetProperties()
                .Where(
                    x => x.CustomAttributes.
                    All(y => y.GetType() == typeof(AutoId) ||
                    y.GetType() == typeof(EntityKey) ||
                    y.GetType() == typeof(NonPersisted)) &&
                    !x.GetMethod.IsVirtual
                    );
            var attributes = from m in props select m.Name;
            var parameterlist = from m in attributes select "@" + m;

            string cmd = "insert into " + item.GetType().Name +
                "(" + String.Join(",", attributes) + ")" + "values(" +
                string.Join(",", parameterlist) + ")";

            var MyType = typeof(TEntityType);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            foreach (var attr in attributes)
            {
                PropertyInfo prop = MyType.GetProperty(attr);
                object value = prop.GetValue(item);
                sqlParameters.Add(new SqlParameter(attr, value));
            }
            return SqlHelpers.ModifyDatabase(_connection, cmd, sqlParameters);
        }

        public int Update(TEntityType item)
        {
            var props = typeof(TEntityType).GetProperties()
                .Where(
                    x => x.CustomAttributes.
                        All(y => y.GetType() == typeof(AutoId) ||
                                 y.GetType() == typeof(EntityKey) ||
                                 y.GetType() == typeof(NonPersisted)

                        ) &&
                    !x.GetMethod.IsVirtual);

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            var keys = from prop in typeof(TEntityType).
                       GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(EntityKey)))
                       select prop.Name;

            var myType = typeof(TEntityType);
            var keyWhere = new List<string>();
            foreach (var key in keys)
            {
                var obj = myType.GetProperty(key).GetValue(item);
                keyWhere.Add(
                        key + "=@" + key
                    );
                sqlParameters.Add(new SqlParameter(key, obj));
            }

            var attributes = from m in props select m.Name;
            var parameterlist = from m in props select m.Name + "=@" + m.Name;

            string cmd = "update " + item.GetType().Name +
                         " set " + String.Join(" ,", parameterlist) + " where " +
                         string.Join(" and ", keyWhere);


            foreach (var attr in attributes)
            {
                PropertyInfo prop = myType.GetProperty(attr);
                object value = prop.GetValue(item);
                sqlParameters.Add(new SqlParameter(attr, value));
            }

            return SqlHelpers.ModifyDatabase(_connection, cmd, sqlParameters);
        }

        public IEnumerable<TEntityType> Find(Expression<Func<TEntityType, bool>> predicate)
        {
            // hacks all the way
            dynamic operation = predicate.Body;
            var left = operation.Left;
            var right = operation.Right;

            var ops = new Dictionary<ExpressionType, String>();
            ops.Add(ExpressionType.Equal, "=");
            ops.Add(ExpressionType.GreaterThan, ">");
            ops.Add(ExpressionType.LessThan, "<");

            // add all required operations here            

            // Instead of SELECT *, select all required fields, since you know the type
            var cmd = String.Format("SELECT * FROM {0} WHERE {1} {2} {3}",
                typeof(TEntityType).Name,
                left.Member.Name, ops[operation.NodeType],
                right.Value);
            var dt = SqlHelpers.GetDataTable(_connection, cmd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yield return _mapper.ConvertToEntity(dt.Rows[i]);
            }
            //return null;
        }
    }
}
