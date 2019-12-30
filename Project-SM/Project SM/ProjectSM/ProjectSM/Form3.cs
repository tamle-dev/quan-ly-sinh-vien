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
    public partial class Form3 : Form
    {
        public Form3(List<Students> List_Of_Student,List<ClassCourse> List_Of_ClassCourse)
        {
            InitializeComponent();
            if (List_Of_Student == null || List_Of_ClassCourse == null)
                Close();
            else
            {
                List_Student = List_Of_Student;
                List_Course = List_Of_ClassCourse;
                foreach(var student in List_Of_Student)
                {
                    comboBoxSt.Items.Add(student.StudentID + "-" + student.FullName);
                    comboBoxSt2.Items.Add(student.StudentID + "-" + student.FullName);
                }
                foreach(var cs in List_Of_ClassCourse)
                {
                    comboBoxCs.Items.Add(cs.course.classID.ClassID + "-" + cs.course.CourseID);
                    comboBoxCs2.Items.Add(cs.course.classID.ClassID + "-" + cs.course.CourseID);
                }
            }
        }

        List<Students> List_Student = null;
        List<ClassCourse> List_Course = null;
        public Students St = null;
        public ClassCourse Cs = null;
        public int CODE = -1;

        private void buttonExit_Click(object sender, EventArgs e)
        {
            CODE = -1;
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {


                SELECTED(comboBoxSt, comboBoxCs);
                if (St == null || Cs == null)
                {
                    CODE = -1;
                    Close();
                }
                else
                {
                    CODE = 1;
                    Close();
                }
            }
            catch {
                CODE = -1;
                Close();
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                SELECTED(comboBoxSt2, comboBoxCs2);
                if (St == null || Cs == null)
                {
                    CODE = -1;
                    Close();
                }
                else
                {
                    CODE = 0;
                    Close();
                }
            }
            catch
            {
                CODE = -1;
                Close();
            }
        }
        private void SELECTED(ComboBox st,ComboBox cs)
        {
            foreach (var student in List_Student)
            {
                string[] split = st.SelectedItem.ToString().Split('-');
                if (student.StudentID == split[0])
                    St = student;
            }
            foreach (var course in List_Course)
            {
                string[] split = cs.SelectedItem.ToString().Split('-');
                if (course.course.classID.ClassID == split[0] && course.course.CourseID == split[1])
                    Cs = course;
            }
        }

       
    }
}
