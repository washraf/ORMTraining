using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Helpers
{
    /// <summary>
    /// SQL Abstractions
    /// </summary>
    public class SqlHelpers
    {
        /// <summary>
        /// Load a Single Row
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader GetRow(SqlConnection connection, string command, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.AddRange(parameters);
            cmd.Connection = connection;
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                r.Read();
                return r;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Load a Data Table
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(SqlConnection connection, string command, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(command);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Modify the database either by inserts, updates or deletes
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ModifyDatabase(SqlConnection connection, string command, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(command);
            cmd.Parameters.AddRange(parameters.ToArray());
            cmd.Connection = connection;
            return cmd.ExecuteNonQuery();
        }

    }
}
