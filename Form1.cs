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

            lstStudents.Items.Clear();

            foreach (Student s in students)
            {
                //lstStudents.Items.Add($"{s.FirstName} {s.LastName}");
                lstStudents.Items.Add(s);
            }
        }

        /// <summary>
        /// Brings up a form that allows the user to enter new student information 
        /// and add them to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddUpdateStudent addStuForm = new frmAddUpdateStudent();
            addStuForm.ShowDialog();

            PopulateStudentListBox();
        }

        /// <summary>
        /// Deletes the selected student from the list and database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            //make sure there is a student selected
            if(lstStudents.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a student");
                return;
            }

            Student stu = (Student)lstStudents.SelectedItem;
            String msg = $"Are you sure you want to delete {stu.FullName} : {stu.StudentId}";

            DialogResult answer = MessageBox.Show(msg, "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                StudentDB.Delete(stu.StudentId);
                PopulateStudentListBox();

                MessageBox.Show("Student deleted successfully");
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            //TODO: Check student is selected

            Student s = (Student) lstStudents.SelectedItem;
            frmAddUpdateStudent updateForm = new frmAddUpdateStudent(s);

            updateForm.ShowDialog();
        }
    }
}
