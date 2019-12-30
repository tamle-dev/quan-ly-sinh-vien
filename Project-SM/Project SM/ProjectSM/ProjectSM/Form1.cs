using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProjectSM.Business;
using ProjectSM.Entity;

namespace ProjectSM
{
    public partial class SMForm : Form
    {
        public SMForm()
        {
            InitializeComponent(); 
        }

        private void enable()
        {
            buttonAdd.Enabled = true;
            buttonAddjust.Enabled = true;
            buttonImport.Enabled = true;
            buttonModify.Enabled = true;
            comboBoxClass.Enabled = true;
            comboBoxCourses.Enabled = true;
            comboBoxGrade.Enabled = true;
            comboBoxClassCourse.Enabled = true;
        }
        private void disable()
        {
            buttonAdd.Enabled = false;
            buttonAddjust.Enabled = false;
            buttonImport.Enabled = false;
            buttonModify.Enabled = false;
            comboBoxClass.Enabled = false;
            comboBoxCourses.Enabled = false;
            comboBoxGrade.Enabled = false;
            comboBoxClassCourse.Enabled = false;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string pathFile = dlg.FileName;

                Service service = new Service();

                if (service.importCSV(pathFile))
                {
                    MessageBox.Show("Import successed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListClasses();
                }
                else
                    MessageBox.Show("Import unsuccessed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadListClasses()
        {
            Service service = new Service();
            comboBoxClass.Items.Clear();
            comboBoxCourses.Items.Clear();
            comboBoxClassCourse.Items.Clear();
            comboBoxGrade.Items.Clear();

            var classe = service.GetList_Of_Classes();
            if (classe != null)
            {
                foreach (var clas in classe)
                {
                    comboBoxClass.Items.Add(clas.ClassID);
                    comboBoxCourses.Items.Add(clas.ClassID);
                }
            }
            if (service.GetList_Of_ClassCourses() != null)
            {

                foreach (var cs in service.GetList_Of_ClassCourses())
                {
                    comboBoxClassCourse.Items.Add(cs.course.classID.ClassID + "-" + cs.course.CourseID);
                }
            }
            if (service.GetList_Of_GradeClassCourses() != null)
            {
                foreach (var gradeCourse in service.GetList_Of_GradeClassCourses())
                    comboBoxGrade.Items.Add(gradeCourse.classCourse.course.classID.ClassID + '-' + gradeCourse.classCourse.course.CourseID);
            }
        }

        private void AddCoursesToListView(ListView view, List<Courses> List_Of_Courses)
        {
            view.Clear();
            view.FullRowSelect = true;
            view.GridLines = true;
            view.Columns.Add("Ma Mon", 150);
            view.Columns.Add("Ten Mon", 150);
            view.Columns.Add("Phong Hoc", 150);
            foreach (var courses in List_Of_Courses)
            {
                ListViewItem item = new ListViewItem();
                item.Text = courses.CourseID;
                item.SubItems.Add(courses.CourseName);
                item.SubItems.Add(courses.Room);
                view.Items.Add(item);
            }
        }

        private void AddStudentToListView(ListView view, List<Students> List_Of_Students)
        {
            view.Clear();
            view.FullRowSelect = true;
            view.GridLines = true;
            view.Columns.Add("MSSV", 150);
            view.Columns.Add("Ho ten", 150);
            view.Columns.Add("Gioi tinh", 150);
            view.Columns.Add("CMND", 150);
            foreach (var student in List_Of_Students)
            {
                ListViewItem item = new ListViewItem();
                item.Text = student.StudentID;
                item.SubItems.Add(student.FullName);
                item.SubItems.Add(student.Gender);
                item.SubItems.Add(student.ID);
                view.Items.Add(item);
            }
        }

        private void AddGradeCourseToListView(ListView view,GradeClassCourse GradeCourse)
        {
            view.Clear();
            view.FullRowSelect = true;
            view.GridLines = true;
            view.Columns.Add("MSSV", 100);
            view.Columns.Add("Ho ten", 100);
            view.Columns.Add("Diem GK", 70);
            view.Columns.Add("Diem CK", 70);
            view.Columns.Add("Diem khac", 70);
            view.Columns.Add("Diem tong", 70);
            view.Columns.Add("Tinh trang", 70);
            foreach (var grade in GradeCourse.listGrade)
            {
                ListViewItem item = new ListViewItem();
                item.Text = grade.StudentID;
                item.SubItems.Add(findName(grade.StudentID));
                item.SubItems.Add(grade.GradeGK.ToString());
                item.SubItems.Add(grade.GradeCK.ToString());
                item.SubItems.Add(grade.GradeE.ToString());
                item.SubItems.Add(grade.TotalGrade.ToString());
                if (grade.TotalGrade >= 5.0)
                    item.SubItems.Add("Dau");
                else
                    item.SubItems.Add("Rot");

                view.Items.Add(item);
            }
        }
        private string findName(string StudentID)
        {
            Service service = new Service();
            if(service.GetList_Of_Students()!=null)
            {
                foreach (var student in service.GetList_Of_Students())
                    if (student.StudentID == StudentID)
                        return student.FullName;
            }
            return null;
        }

        private void AddStudentGradeToList(ListView view, Grade grade)
        {
            view.Clear();
            view.FullRowSelect = true;
            view.GridLines = true;
            view.Columns.Add("MSSV", 100);
            view.Columns.Add("Ho ten", 100);
            view.Columns.Add("Diem GK", 70);
            view.Columns.Add("Diem CK", 70);
            view.Columns.Add("Diem khac", 70);
            view.Columns.Add("Diem tong", 70);
            view.Columns.Add("Tinh trang", 70);

            ListViewItem item = new ListViewItem();
            item.Text = grade.StudentID;
            item.SubItems.Add(findName(grade.StudentID));
            item.SubItems.Add(grade.GradeGK.ToString());
            item.SubItems.Add(grade.GradeCK.ToString());
            item.SubItems.Add(grade.GradeE.ToString());
            item.SubItems.Add(grade.TotalGrade.ToString());
            if (grade.TotalGrade >= 5.0)
                item.SubItems.Add("Dau");
            else
                item.SubItems.Add("Rot");

            view.Items.Add(item);
        }

        private void comboBoxViewGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service service = new Service();
            if (service.GradeStudentInClassCourse(comboBoxViewGrade.SelectedItem.ToString(), textBoxID.Text.ToString()) != null)
            {
                AddStudentGradeToList(listView1, service.GradeStudentInClassCourse(comboBoxViewGrade.SelectedItem.ToString(), textBoxID.Text.ToString()));
            }

        }
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service service = new Service();
            List<Students> students = service.GetList_Of_StudentsByClassID(comboBoxClass.SelectedItem.ToString());
            AddStudentToListView(listView1, students);
        }
        private void comboBoxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service service = new Service();
            List<Courses> courses = service.GetList_Of_CoursesByClassID(comboBoxCourses.SelectedItem.ToString());
            if (courses != null)
                AddCoursesToListView(listView1, courses);
        }
        private void comboBoxClassCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service service = new Service();
            List<Students> students = service.GetList_Of_StudentsInCourseByClassID(comboBoxClassCourse.SelectedItem.ToString());
            AddStudentToListView(listView1, students);
        }
        private void comboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service service = new Service();
            GradeClassCourse grade = service.GetGradeClassCourse(comboBoxGrade.SelectedItem.ToString());
            AddGradeCourseToListView(listView1, grade);
            textBoxGrade.Visible = true;
            textBoxGrade.Clear();
            textBoxGrade.AppendText("So luong: "+ grade.listGrade.Count().ToString() + "\r\n");
            textBoxGrade.AppendText("Dau: " + PassOrFail(grade).ToString() + "/"+ (PassOrFail(grade)*1.0 / grade.listGrade.Count() *100).ToString()+ "%" + "\r\n");
            textBoxGrade.AppendText("Rot: " + (grade.listGrade.Count() - PassOrFail(grade)).ToString() + "/" + (100 - (PassOrFail(grade)*1.0 / grade.listGrade.Count() * 100)).ToString() + "%" + "\r\n");
        }

        private int PassOrFail(GradeClassCourse grade)
        {
            int Pass = 0;

            foreach(var Grade in grade.listGrade)
            {
                if (Grade.TotalGrade >= 5)
                    Pass++;
            }

            return Pass;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Service service = new Service();
                var List_Of_Classes = service.GetList_Of_Classes();
                Form2 newForm = new Form2(List_Of_Classes);
                newForm.ShowDialog();
                if (newForm.newStudent != null)
                {
                    Students newStudent = newForm.newStudent;
                    if (service.AddStudent(newStudent))
                        MessageBox.Show("Adding successed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Adding unsuccessed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                return;
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {


                Service service = new Service();
                var List_Of_Student = service.GetList_Of_Students();
                var List_Of_ClassCourse = service.GetList_Of_ClassCourses();
                Form3 newForm = new Form3(List_Of_Student, List_Of_ClassCourse);
                newForm.ShowDialog();
                if (newForm.CODE != -1)
                {
                    service.Modify(newForm.CODE, newForm.St, newForm.Cs);
                    MessageBox.Show("Done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }

        }
        private void buttonAddjust_Click(object sender, EventArgs e)
        {
            try
            {
                Service service = new Service();
                var List_Of_Student = service.GetList_Of_Students();
                var List_Of_GradeClassCourse = service.GetList_Of_GradeClassCourses();
                Form4 newForm = new Form4(List_Of_Student, List_Of_GradeClassCourse);
                newForm.ShowDialog();
                if(newForm.choose==null||newForm.newGrade==null)
                    return;
                service.updateGradeStudentInClassCourse(newForm.choose, newForm.newGrade);
            }
            catch { }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            if (service.getCons() == "")
            {
                Form5 newForm = new Form5("Provider=SQLNCLI11;Server=LAPTOP-T2T3B19;Database=Univer;Trusted_Connection=yes;");
                newForm.ShowDialog();
                service.setCons(newForm.conn);
            }
           
            if (!service.LoadData())
                MessageBox.Show("Can't find data.\n Pleases try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LoadListClasses();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonData.PerformClick();
            Service service = new Service();
            if (!service.LogIn(textBoxID.Text.ToString(), textBoxPass.Text.ToString()))
                MessageBox.Show("Can't not login.\nPlease check your account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                textBoxID.Enabled = false;
                textBoxPass.Enabled = false;
                buttonChangePass.Enabled = true;
                buttonChangePass.Visible = true;
                if (!service.IsStudent())
                    enable();
                else
                {
                    if(service.Get_List_Grade_By_StudentID(textBoxID.Text.ToString())!=null)
                    {
                        foreach(var gradeCourse in service.Get_List_Grade_By_StudentID(textBoxID.Text.ToString()))
                        {
                            comboBoxViewGrade.Items.Add(gradeCourse.classCourse.course.classID.ClassID + '-' + gradeCourse.classCourse.course.CourseID+'-'+ gradeCourse.classCourse.course.CourseName);
                        }
                    }
                    disable();
                }
            }
        }
        private void buttonLogOFF_Click(object sender, EventArgs e)
        {
            textBoxID.Clear();
            textBoxPass.Clear();
            textBoxID.Enabled = true;
            textBoxPass.Enabled = true;
            buttonChangePass.Enabled = false;
            buttonChangePass.Visible = false;
            listView1.Clear();
            comboBoxClass.Items.Clear();
            comboBoxCourses.Items.Clear();
            comboBoxGrade.Items.Clear();
            comboBoxClassCourse.Items.Clear();
            comboBoxViewGrade.Items.Clear();
            textBoxGrade.Enabled = true;
            textBoxGrade.Clear();
            textBoxGrade.Enabled = false;
            disable();
        }
        private void buttonChangePass_Click(object sender, EventArgs e)
        {
           
            textBoxPass.Enabled = true;
            textBoxPass.PasswordChar = '\0';
            buttonSave.Enabled = true;
            buttonSave.Visible = true;
            buttonCancel.Enabled = true;
            buttonCancel.Visible = true;
            buttonChangePass.Visible = false;
            buttonChangePass.Enabled = false;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            textBoxPass.Enabled = false;
            textBoxPass.PasswordChar = '*';
            buttonSave.Enabled = false;
            buttonSave.Visible = false;
            buttonCancel.Enabled = false;
            buttonCancel.Visible = false;
            Service service = new Service();
            if (service.ChangePassword(textBoxPass.Text.ToString()))
                MessageBox.Show("Change password successed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonChangePass.Visible = true;
            buttonChangePass.Enabled = true;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxPass.Clear();
            textBoxPass.Enabled = false;
            textBoxPass.PasswordChar = '*';
            buttonSave.Enabled = false;
            buttonSave.Visible = false;
            buttonCancel.Enabled = false;
            buttonCancel.Visible = false;
            buttonChangePass.Visible = true;
            buttonChangePass.Enabled = true;
        }
        //Minimize form without border using the taskbar
        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        //Move form without border
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void SMForm_Load(object sender, EventArgs e)
        {
            Service service = new Service();
            service.InitialLogIn();
            disable();
           
        }

    }
}
