using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        //static class only contain functions
        //you do not create objects from them. 
        //Example is the math class
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateStudentListBox();
        }

        /// <summary>
        /// Retrieves all students from database and puts them in listbox
        /// </summary>
        private void PopulateStudentListBox()
        {
            lstStudents.Items.Clear();
            List<Student> students = StudentDB.GetAllStudents();
            
            foreach (Student s in students)
            {
                lstStudents.Items.Add($"{s.FirstName} {s.LastName}");
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddStudent addStuForm = new frmAddStudent();
            addStuForm.ShowDialog();

            PopulateStudentListBox();
        }
    }
}
