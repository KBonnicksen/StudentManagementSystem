using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{   //static because you are not creating instances of an object
    //creating a method that you can call whenever you want to make
    //a connection to the database
    static class SmsDB
    {   //public so that it is accessible to other classes

        /// <summary>
        /// Gets a connection to the student management system database
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=B11R111E-15;Initial Catalog=SMS;Integrated Security=True");
        }
    }
}
