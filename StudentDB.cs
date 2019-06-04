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
        /// <summary>
        /// Returns a list of all students in the database
        /// </summary>
        /// <returns></returns>
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
            List<Student> stuList = new List<Student>();
            while (rdr.Read()) //similar to hasNext() (goes through each row)
            {
                Student tempStu = new Student
                {
                    StudentId = Convert.ToInt32(rdr["SID"]),
                    FirstName = Convert.ToString(rdr["FirstName"]),
                    LastName = Convert.ToString(rdr["LastName"]),
                    DateOfBirth = Convert.ToDateTime(rdr["DOB"]),
                    ProgramOfChoice = Convert.ToString(rdr["Program"])
                };
                stuList.Add(tempStu);
            }

            //Close connection
            con.Close();
            return stuList;
        }

        /// <summary>
        /// Adds a student to the database
        /// </summary>
        /// <param name="stu">Student to be added</param>
        /// <exception cref="SqlException"></exception>
        /// 
        public static void Add(Student stu)
        {
            //create connection
            SqlConnection con = SmsDB.GetConnection();

            //create command
            SqlCommand addCmd = new SqlCommand
            {
                Connection = con,
                //ALWAYS USE PARAMETERIZED QUERIES!!!!
                CommandText =
                    "INSERT INTO Students(FirstName, " +
                        "LastName, DOB, Program) " +
                    "VALUES (@fName, @lName, @dob, @program)",
            };

            //Add values into parameters
            addCmd.Parameters.AddWithValue("fName", stu.FirstName);
            addCmd.Parameters.AddWithValue("@lName", stu.LastName);
            addCmd.Parameters.AddWithValue("@dob", stu.DateOfBirth);
            addCmd.Parameters.AddWithValue("@program", stu.ProgramOfChoice);

            //open connection
            //this can fail so you wrap it in a try/catch statement
            try
            {
                con.Open();
                int rowsAffected = addCmd.ExecuteNonQuery();
                //This will insert correctly OR throw a SQLException
            }
            finally //finally always executes
            {
                //con.Close();
                con.Dispose(); //calls close and then disposes the object
            }
        }

        public static void Update(Student stu)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(int ID)
        {
            SqlConnection con = SmsDB.GetConnection();

            SqlCommand delCmd = new SqlCommand();
            delCmd.Connection = con;
            delCmd.CommandText = "DELETE " +
                                 "FROM Students " +
                                 "WHERE SID = @id";
            delCmd.Parameters.AddWithValue("@id", ID);

            try
            {
                con.Open();
                int rowsAffected = delCmd.ExecuteNonQuery();

                return (rowsAffected == 1);
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}
