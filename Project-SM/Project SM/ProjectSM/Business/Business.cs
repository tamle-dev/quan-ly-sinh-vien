using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjectSM.Entity;
using ProjectSM.Database;


namespace ProjectSM.Business
{
    public class Service
    {
       

        static List<string> CSV_inputed = null ;
        static bool isStudent = false;
        public bool IsStudent() { return isStudent; }
        static List<AccountLogIn> List_Account = null;
        public string getCons()
        {
            DataSetRepo dataSet = new DataSetRepo();
            return dataSet.get_Conn();
        }
        public void setCons(string con)
        {
            DataSetRepo dataSet = new DataSetRepo();
            dataSet.set_Conn(con);
        }
        static AccountLogIn login = null;

        public void InitialLogIn()
        {
            AccountLogIn account = new AccountLogIn();
            account.ID = "giaovu";
            account.Password = "giaovu";
            if (List_Account == null)
                List_Account = new List<AccountLogIn>();

            List_Account.Add(account);
        }

        public bool LogIn(string ID,string Password)
        {
            try
            {
                DataSetRepo dataSet = new DataSetRepo();
                List_Account = dataSet.GetList_Of_Account();
                InitialLogIn();
                foreach (var account in List_Account)
                {
                    if (ID == account.ID && Password == account.Password)
                    {
                        if (account.ID.Contains("giaovu"))
                            isStudent = false;
                        else
                            isStudent = true;
                        login = account;
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangePassword(string newPass)
        {
            DataSetRepo dataSet = new DataSetRepo();
            login.Password = newPass;
            return dataSet.changePassword(login);
        }

        public List<Classes> GetList_Of_Classes()
        {
            var dataRepo = new DataSetRepo();
            return dataRepo.GetList_Of_Classes();
        }
        public List<Students> GetList_Of_Students()
        {
            var dataRepo = new DataSetRepo();
            return dataRepo.GetList_Of_Students();

        }
        public List<Courses> GetList_Of_Courses()
        {
            var dataRepo = new DataSetRepo();
            return dataRepo.GetList_Of_Courses();
        }
        public List<ClassCourse> GetList_Of_ClassCourses()
        {
            var dataRepo = new DataSetRepo();
            return dataRepo.GetList_Of_ClassCourses();
        }
        public List<GradeClassCourse> GetList_Of_GradeClassCourses()
        {
            var dataRepo = new DataSetRepo();
            return dataRepo.GetList_Of_GradeClassCourses();
        }
        public List<GradeClassCourse> Get_List_Grade_By_StudentID(string StudentID)
        {
            try
            {


                DataSetRepo dataSet = new DataSetRepo();
                var List_Grade_Class_Course = dataSet.GetList_Of_GradeClassCourses();

                var List_Grade_Course = new List<GradeClassCourse>();

                foreach (var gradeCourse in List_Grade_Class_Course)
                {
                    foreach (var student in gradeCourse.listGrade)
                    {
                        if (student.StudentID == StudentID)
                            List_Grade_Course.Add(gradeCourse);
                    }
                }
                return List_Grade_Course;
            }
            catch
            { return null; }
        }
        public bool importCSV (string path)
        {
            if (CSV_inputed == null)
                CSV_inputed = new List<string>();

            string fileName = Path.GetFileName(path);

            if (checkInputed(fileName))
                return false;

            if (fileName.Contains('S'))
            {
                var dataRepo = new DataSetRepo();
                dataRepo.LoadCourses(path);
                CSV_inputed.Add(fileName);
                return true;
            }
            else if (fileName.Contains('G'))
            {
                var dataRepo = new DataSetRepo();
                dataRepo.LoadGradeClassCourse(path);
                CSV_inputed.Add(fileName);
                return true;
            }
            else
            {
                var dataRepo = new DataSetRepo();
                dataRepo.LoadClasses(path);
                dataRepo.LoadStudents(path);
                CSV_inputed.Add(fileName);
                return true;
            }
        }
        private bool checkInputed(string fileName)
        {
            foreach(string name in CSV_inputed)
            {
                if (fileName == name)
                    return true;
            }
            return false;
        }

        public bool AddStudent(Students newStudent)
        {
            var List_Of_Student = GetList_Of_Students();
            if (checkSameStudentIDInList(newStudent, List_Of_Student))
                return false;
            var dataSet = new DataSetRepo();
            return dataSet.AddStudent(newStudent);
        }
        bool checkSameStudentIDInList(Students AStudent, List<Students> ListStudent)
        {
            foreach (var student in ListStudent)
                if (student.StudentID == AStudent.StudentID)
                    return true;
            return false;
        }
        public bool Modify(int CODE,Students AStudent,ClassCourse AClassCourse)
        {
            DataSetRepo dataSet = new DataSetRepo();
            if (CODE == 1)
            {
                foreach (var course in dataSet.GetList_Of_ClassCourses())
                {
                    if(course.course.CourseID==AClassCourse.course.CourseID&&course.course.classID.ClassID==AClassCourse.course.classID.ClassID)
                    {
                        foreach (var student in course.students)
                            if (AStudent.StudentID == student.StudentID)
                                return true;
                        return dataSet.AddStudentToClassCourse(AStudent, AClassCourse);
                    }
                }
                return false;
            }
            else
            {
                foreach (var course in dataSet.GetList_Of_ClassCourses())
                {
                    if (course.course.CourseID == AClassCourse.course.CourseID && course.course.classID.ClassID == AClassCourse.course.classID.ClassID)
                    {
                            if (!checkSameStudentIDInList(AStudent,course.students))
                                return true;
                            else
                                return dataSet.RemoveStudentFromClassCourse(AStudent, AClassCourse);
                    }
                }
                return false;
            }
        }
  

        public List<Students> GetList_Of_StudentsByClassID(string ClassID)
        {
            List<Students> result = new List<Students>();
            var dataSet = new DataSetRepo();

            foreach (var student in dataSet.GetList_Of_Students())
            {
                if (student.classID.ClassID == ClassID)
                    result.Add(student);
            }

            return result;
        }
        public List<Courses> GetList_Of_CoursesByClassID (string ClassID)
        {
            
            List<Courses> result = new List<Courses>();
            var dataSet = new DataSetRepo();
            if (dataSet.GetList_Of_Courses() != null)
            {
                foreach (var course in dataSet.GetList_Of_Courses())
                {
                    if (course.classID.ClassID == ClassID)
                        result.Add(course);
                }
                return result;
            }
            return null;
        }
        public List<Students> GetList_Of_StudentsInCourseByClassID (string ClassCourse)
        {
            DataSetRepo dataSet = new DataSetRepo();
            string[] split = ClassCourse.Split('-');
            if(dataSet.GetList_Of_ClassCourses()!=null)
            {
                foreach(var cs in dataSet.GetList_Of_ClassCourses())
                {
                    if (cs.course.classID.ClassID == split[0] && cs.course.CourseID == split[1])
                        return cs.students;
                }
            }
            return null;
        }
        public GradeClassCourse GetGradeClassCourse(string ClassCourse)
        {
            GradeClassCourse result = new GradeClassCourse();
            DataSetRepo dataSet = new DataSetRepo();
            string[] split = ClassCourse.Split('-');
            if (dataSet.GetList_Of_GradeClassCourses() != null)
            {
                foreach(var grade in dataSet.GetList_Of_GradeClassCourses())
                {
                    if (grade.classCourse.course.classID.ClassID == split[0] && grade.classCourse.course.CourseID == split[1])
                        return grade;
                }
            }
            return null;
        }
        public Grade GradeStudentInClassCourse(string ClassCourse,string StudentID)
        {
            var GradeCourse = GetGradeClassCourse(ClassCourse);
            foreach(var grade in GradeCourse.listGrade)
            {
                if (grade.StudentID == StudentID)
                    return grade;
            }
            return null;
        }
        public bool updateGradeStudentInClassCourse(GradeClassCourse selected, Grade newGrade)
        {
            DataSetRepo dataSet = new DataSetRepo();
            if (dataSet.updateGradeStudentInClassCourse(selected, newGrade))
                return true;
            else
                return false;
        }
        public bool LoadData()
        {
            DataSetRepo dataSet = new DataSetRepo();
            return dataSet.LoadData();
        }
    }
}
