using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mapper.Attibutes;
using Mapper.Sets;

namespace Mapper.Mappers
{
    
    public class EntityMapper<TEntityType> where TEntityType : class, new()
    {
        private SqlConnection _connection;
        public EntityMapper(SqlConnection connection)
        {
            _connection = connection;
        }
        /// <summary>
        /// Converts a dataRow to TEntityType
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public TEntityType ConvertToEntity(DataRow dataRow)
        {
            var obj = new TEntityType();

            var props = typeof(TEntityType).GetProperties();
            for (int j = 0; j < dataRow.ItemArray.Count(); j++)
            {
                string fieldName = dataRow.Table.Columns[j].ColumnName;
                var prop = props.FirstOrDefault(x => x.Name.ToLower() == fieldName.ToLower());
                if (prop != null)
                {
                    if (dataRow.ItemArray[j] != DBNull.Value)
                        prop.SetValue(obj,
                            Convert.ChangeType(dataRow.ItemArray[j],
                            prop.PropertyType), null);

                }
            }
            FillAssociations(props, obj);
            return obj;
        }

        private void FillAssociations(PropertyInfo[] props,
            TEntityType obj)
        {
            foreach (var vprop in props.Where(x => x.GetMethod.IsVirtual))
            {
                if (vprop.PropertyType.GetInterface("IEnumerable") != null)
                {
                    MapCollections(obj, vprop);
                }
                else
                {
                    MapClass(obj, vprop);
                }
            }
        }

        private void MapCollections(TEntityType obj, PropertyInfo vprop)
        {
            var keys = from prop in typeof(TEntityType).
                GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(EntityKey)))
                       select prop;
            var condition = string.Join("and", from k in keys select k.Name + "=@" + k.Name);
            var parameters = new List<SqlParameter>();
            foreach (var key in keys)
            {
                parameters.Add(new SqlParameter(key.Name, key.GetValue(obj)));
            }
            var reflectionType = vprop.PropertyType.GetGenericArguments()[0];

            var val = GetEnumrable(reflectionType, condition, parameters);
            vprop.SetValue(obj, val);
        }

        private object GetEnumrable(Type reflectionType, string condition,
           List<SqlParameter> parameters)
        {
            Type tableSetType =
                typeof(TableSet<>).MakeGenericType(reflectionType);
            var childTableSet = Activator.CreateInstance(tableSetType,
                _connection);
            //Type type = childTableSet.GetType();
            MethodInfo methodInfo = tableSetType.GetMethod("GetByKeyValue");
            object[] objarray = { condition, parameters };
            var result = methodInfo.Invoke(childTableSet, objarray);
            return result;
        }

        private void MapClass(TEntityType obj, PropertyInfo vprop)
        {
            var reflectionType = vprop.PropertyType;
            var primarykeys = from prop in reflectionType.
                       GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(EntityKey)))
                              select prop.Name;
            var foriegnKeys = from prop in typeof(TEntityType).GetProperties()
                .Where(x => primarykeys.Contains(x.Name))
                              select prop;

            var parameters = new List<SqlParameter>();
            var condition = string.Join("and", from k in foriegnKeys select k.Name + "=@" + k.Name);

            foreach (var key in foriegnKeys)
            {

                parameters.Add(new SqlParameter(key.Name, key.GetValue(obj)));
            }

            var val = GetParent(reflectionType, condition, parameters);
            vprop.SetValue(obj, val);
        }

        private object GetParent(Type reflectionType, string condition,
            List<SqlParameter> parameters)
        {
            Type tableSetType = typeof(TableSet<>).MakeGenericType(reflectionType);
            var childTableSet = Activator.CreateInstance(tableSetType, _connection);
            Type type = childTableSet.GetType();
            MethodInfo methodInfo = type.GetMethod("GetByKeyValue");
            object[] objarray = { condition, parameters };
            var result = methodInfo.Invoke(childTableSet, objarray);
            IEnumerable items = (IEnumerable)result;
            object single = items.Cast<object>().Single();
            return single;
        }

        public IEnumerable<PropertyInfo> GetProperties(TEntityType item)
        {
            var props = typeof(TEntityType).GetProperties()
                .Where(
                    x => x.CustomAttributes.
                    All(y => y.GetType() == typeof(AutoId) ||
                    y.GetType() == typeof(EntityKey) ||
                    y.GetType() == typeof(NonPersisted)) &&
                    !x.GetMethod.IsVirtual
                    );
            return props;
        }
    }
}
