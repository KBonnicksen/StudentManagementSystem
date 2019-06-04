using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class frmAddUpdateStudent : Form
    {
        private Student existingStudent;

        //Default value, makes it so you do not HAVE to pass in a student
        public frmAddUpdateStudent(Student s = null)
        {
            InitializeComponent();
            existingStudent = s;

            if(s != null)
            {
                btnRegisterStudent.Text = "Update student";
                //change form title
                Text = "Updating student : " + s.StudentId;

                txtFirstName.Text = s.FirstName;
                txtLastName.Text = s.LastName;
                txtProgram.Text = s.ProgramOfChoice;
                dtpDateOfBirth.Value = s.DateOfBirth;

                txtFirstName.Focus();
            }
        }

        private void frmAddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnRegisterStudent_Click(object sender, EventArgs e)
        {
            //TODO: add validation code

            Student stu = new Student()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = dtpDateOfBirth.Value,
                ProgramOfChoice = txtProgram.Text
            };

            try
            {
                StudentDB.Add(stu);
                MessageBox.Show("Student added");

                Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("There was a DB problem, try again later");
            }

        }
    }
}
