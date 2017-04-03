using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        #region --SQL--
        /// <summary>
        /// create table Student ( Id bigint primary key, Name nvarchar(50) )
        /// </summary>
        #endregion
        static void Main(string[] args)
        {
            RowDataDemo.Run();
            //TableDataDemo.Run();
            //ActiveRecordDemo.Run();

        }
    }
}
