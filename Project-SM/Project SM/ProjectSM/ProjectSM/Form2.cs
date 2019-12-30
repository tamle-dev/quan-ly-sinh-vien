using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectSM.Entity;

namespace ProjectSM
{
    public partial class Form2 : Form
    {
        public Form2(List<Classes> List_Of_Class)
        {
            InitializeComponent();
            if (List_Of_Class == null)
                Close();
            else
            {
                foreach(var clas in List_Of_Class)
                {
                    comboBox1.Items.Add(clas.ClassID.ToString());
                }
            }
        }
        public Students newStudent = null;

        private void button1_Click(object sender, EventArgs e)
        {
            newStudent = new Students();
            newStudent.classID = new Classes();
            newStudent.classID.ClassID = comboBox1.SelectedItem.ToString();
            newStudent.StudentID = textBox2.Text.ToString();
            newStudent.FullName = textBox1.Text.ToString();
            newStudent.Gender = textBox4.Text.ToString();
            newStudent.ID = textBox3.Text.ToString();
            if (newStudent.StudentID == null || newStudent.StudentID == "" )
            {
                newStudent = null;
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newStudent = null;
            Close();
        }
    }
}
