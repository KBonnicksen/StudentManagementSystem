using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    /// <summary>
    /// Represents an individual Clover Park student
    /// </summary>
    public class Student
    {
        //This is the default no-argws constructor
        //The sompiler will create a no-args constructor
        //if no other constructors are found
        public Student()
        {
        }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        /// <summary>
        /// The legal first name of the student
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The legal last name of the student
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The ID of the student. Auto-incremented value
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// The date the student was born. Time portion is ignored
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The name of the program the student is registered in
        /// ex. Computer Programming
        /// </summary>
        public string ProgramOfChoice { get; set; }
        /// <summary>
        /// A read-only property that returns the full legal name
        /// (first + last)
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// Returns all student data split by a seperator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string GetDisplayText(string separator)
        {
            return $"{LastName},{FirstName}{separator}" +
                $"{DateOfBirth.ToShortDateString()}{separator}";
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
