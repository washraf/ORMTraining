using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecord
{
    public class StudentActiveRecord
    {
        private static readonly SqlConnection Con = new SqlConnection("Data Source=.;Initial Catalog=EMSDb;Integrated Security=True");
        public int Id { get; set; }
        public string Name { get; set; }


        public int InsertStudent()
        {
            string sql = "INSERT INTO student VALUES (@key,@name)";
            long key = DateTime.Now.Ticks;
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new OleDbParameter("key", Id));
            comm.Parameters.Add(new OleDbParameter("name", Name));
            return comm.ExecuteNonQuery();
        }


        public int UpdateStudent()
        {
            string sql = @"UPDATE student SET name = @name WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new SqlParameter("name", Name));
            comm.Parameters.Add(new SqlParameter("key", Id));
            return comm.ExecuteNonQuery();
        }


        public static StudentActiveRecord FindById(int id)
        {
            String sql = "SELECT * FROM student WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new OleDbParameter("key", id));
            IDataReader reader = comm.ExecuteReader();
            reader.Read();
            Object[] result = new Object[reader.FieldCount];
            reader.GetValues(result);
            reader.Close();
            return new StudentActiveRecord()
            {
                Id = Convert.ToInt32(result[0]),
                Name = result[1].ToString()
            };
        }

        public static List<StudentActiveRecord> FindByName(string name)
        {
            String sql = "SELECT * FROM student WHERE name like %@name%";
            SqlCommand cmd = new SqlCommand(sql, Con);
            cmd.Parameters.Add(new OleDbParameter("name", name));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            var students = new List<StudentActiveRecord>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                students.Add(new StudentActiveRecord()
                {
                    Id = Convert.ToInt32(dt.Rows[i][0]),
                    Name = dt.Rows[i][1].ToString()
                });
            }
            return students;
        }
        public static List<StudentActiveRecord> GetAll()
        {
            String sql = "SELECT * FROM student";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            var students = new List<StudentActiveRecord>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                students.Add(new StudentActiveRecord()
                {
                    Id = Convert.ToInt32(dt.Rows[i][0]),
                    Name = dt.Rows[i][1].ToString()
                });
            }
            return students;
        }
    }

}
