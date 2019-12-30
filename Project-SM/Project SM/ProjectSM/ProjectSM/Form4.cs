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
    public partial class Form4 : Form
    {
        public Form4(List<Students> List_Of_Student,List<GradeClassCourse> List_Of_GradeClassCourses)
        {
            InitializeComponent();
            if (List_Of_Student == null || List_Of_GradeClassCourses == null)
                Close();
            List_Student = List_Of_Student;
            List_GradeClassCourses = List_Of_GradeClassCourses;
            foreach (var gradeCourse in List_GradeClassCourses)
                comboBoxGrade.Items.Add(gradeCourse.classCourse.course.classID.ClassID + '-' + gradeCourse.classCourse.course.CourseID);
        }
        List<Students> List_Student = null;
        List<GradeClassCourse> List_GradeClassCourses = null;
        public GradeClassCourse choose = null;
        public Grade newGrade = null;

        private void comboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            choose = GetGrades(comboBoxGrade.SelectedItem.ToString());
            foreach (var student in choose.listGrade)
            {
                comboBoxStudent.Items.Add(student.StudentID + "-" + FindName(student.StudentID));
            }
        }
        private GradeClassCourse GetGrades(string ClassCourse)
        {
            string[] split = ClassCourse.Split('-');
            foreach (var grade in List_GradeClassCourses)
            {
                if (grade.classCourse.course.classID.ClassID == split[0] && grade.classCourse.course.CourseID == split[1])
                    return grade;
            }
            return null;
        }
        private string FindName(string StudentID)
        {
            foreach (var student in List_Student)
                if (student.StudentID == StudentID)
                    return student.FullName;
            return null;
        }

        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] student = comboBoxStudent.SelectedItem.ToString().Split('-');
            foreach(var grade in choose.listGrade)
            {
                if(grade.StudentID==student[0])
                {
                    textBoxGK.Text = grade.GradeGK.ToString();
                    textBoxCK.Text = grade.GradeCK.ToString();
                    textBoxKhac.Text = grade.GradeE.ToString();
                    textBoxTong.Text = grade.TotalGrade.ToString();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            choose = null;
            newGrade = null;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            newGrade = new Grade();
            double temp = 0;
            if(!double.TryParse(textBoxCK.Text.ToString(),out temp)|| !double.TryParse(textBoxGK.Text.ToString(), out temp)||!double.TryParse(textBoxKhac.Text.ToString(), out temp)|| !double.TryParse(textBoxTong.Text.ToString(), out temp))
            {
                newGrade = null;
                choose = null;
                Close();
            }
            string[] studentID = comboBoxStudent.SelectedItem.ToString().Split('-');
            newGrade.GradeCK = double.Parse(textBoxCK.Text.ToString());
            newGrade.GradeGK = double.Parse(textBoxGK.Text.ToString());
            newGrade.GradeE = double.Parse(textBoxKhac.Text.ToString());
            newGrade.TotalGrade = double.Parse(textBoxTong.Text.ToString());
            newGrade.StudentID = studentID[0];
            Close();
        }
    }
}
