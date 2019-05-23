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
            Student testStu = new Student
            {
                FirstName = "Pam",
                LastName = "Halpert",
                ProgramOfChoice = "Art",
            };
            Validator.IsPresent(new TextBox());

        }

        
    }
}
