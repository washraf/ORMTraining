using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DataMapper
{
    public class StudentMapper : IDisposable
    {

        private SqlConnection _connection;
        public StudentMapper(SqlConnection con)
        {
            _connection = con;
            _connection.Open();
        }
        public StudentMapper(string conString)
        {
            _connection = new SqlConnection(conString);
            _connection.Open();
        }
        public Student GetStudentById(int id)
        {
            String sql = "SELECT * FROM student WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, _connection);
            comm.Parameters.Add(new OleDbParameter("key", id));
            IDataReader reader = comm.ExecuteReader();
            reader.Read();
            Object[] result = new Object[reader.FieldCount];
            reader.GetValues(result);
            reader.Close();
            return new Student()
            {
                Id = Convert.ToInt32(result[0]),
                Name = result[1].ToString()
            };
        }
        public List<Student> GetAll()
        {
            String sql = "SELECT * FROM student";
            SqlCommand cmd = new SqlCommand(sql, _connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            var students = new List<Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt32(dt.Rows[i][0]),
                    Name = dt.Rows[i][1].ToString()
                });
            }
            return students;
        }
        public int InsertStudent(Student student)
        {
            string sql = "INSERT INTO student VALUES (@key,@name)";
            long key = DateTime.Now.Ticks;
            IDbCommand comm = new SqlCommand(sql, _connection);
            comm.Parameters.Add(new SqlParameter("key", student.Id));
            comm.Parameters.Add(new SqlParameter("name", student.Name));
            return comm.ExecuteNonQuery();
        }
        public void Dispose()
        {
            _connection.Dispose();
        }

    }
}