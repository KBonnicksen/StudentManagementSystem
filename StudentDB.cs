using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    //DATABASE CLASS!!!!!!!!!!!!!!
    static class StudentDB
    {
        public static List<Student> GetAllStudents()
        {
            //Get a connection to the DB
            SqlConnection con = SmsDB.GetConnection();

            //Set up query
            string query = "SELECT SID, FirstName, LastName, DOB, Program " +
                            "FROM Students ";
            SqlCommand selCmd = new SqlCommand
            {
                Connection = con,
                CommandText = query
            };

            //Open a connection to the DB
            con.Open();

            //Execute query
            SqlDataReader rdr = selCmd.ExecuteReader(); //returns a sql data reader object

            //Do something with results


            //Close connection
        }

        public static void Add(Student stu)
        {
            throw new NotImplementedException();
        }

        public static void Update(Student stu)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
