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
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
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
