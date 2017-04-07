using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableDataGateway
{
    public class StudentTableGateway
    {
        
        private static readonly SqlConnection Con = new SqlConnection("Data Source=.;Initial Catalog=EMSDb;Integrated Security=True");

        public StudentTableGateway()
        {
            Con.Open();
        }
        public DataTable FindAll()
        {
            String sql = "select * from student";
            var cmd =  new SqlCommand(sql, Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FindWithName(string name)
        {
            String sql = "SELECT * FROM student WHERE name = @name";
            SqlCommand cmd = new SqlCommand(sql, Con);
            cmd.Parameters.Add(new OleDbParameter("name", name));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FindWhere(string whereClause)
        {
            var sql = $"select * from student where {whereClause}";
            var cmd = new SqlCommand(sql, Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public object[] FindRow(long key)
        {
            String sql = "SELECT * FROM student WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new OleDbParameter("key", key));
            IDataReader reader = comm.ExecuteReader();
            reader.Read();
            object[] result = new Object[reader.FieldCount];
            reader.GetValues(result);
            reader.Close();
            return result;
        }
        public void Update(long key, string name)
        {
            string sql = @"UPDATE student SET name = @name WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new SqlParameter("name", name));
            comm.Parameters.Add(new SqlParameter("key", key));
            comm.ExecuteNonQuery();
        }
        public long Insert(string name)
        {
            string sql = "INSERT INTO student VALUES (@key,@name)";
            long key = DateTime.Now.Ticks;
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new SqlParameter("key", key));
            comm.Parameters.Add(new SqlParameter("name", name));
            comm.ExecuteNonQuery();
            return key;
        }
    }
}
