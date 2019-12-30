using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectSM.Entity;

namespace ProjectSM.Database
{
    public class DataSetRepo
    {
        static string conn = "";
        static List<Classes> List_Of_Classes = null;
        static List<Students> List_Of_Students = null;
        static List<Courses> List_Of_Courses = null;
        static List<ClassCourse> List_Of_ClassCourses = null;
        static List<GradeClassCourse> List_Of_GradeClassCourses = null;
        static List<AccountLogIn> List_Of_Account = null;

        public List<Classes> GetList_Of_Classes() { return List_Of_Classes; }
        public List<Students> GetList_Of_Students() { return List_Of_Students; }
        public List<Courses> GetList_Of_Courses() { return List_Of_Courses; }
        public List<ClassCourse> GetList_Of_ClassCourses() { return List_Of_ClassCourses; }
        public List<GradeClassCourse> GetList_Of_GradeClassCourses() { return List_Of_GradeClassCourses; }
        public List<AccountLogIn> GetList_Of_Account() { return List_Of_Account; }
        public string get_Conn() { return conn; }
        public void set_Conn(string cons) { conn = cons; }

        public void LoadClasses(string pathFile)
        {
            if (List_Of_Classes == null)
                List_Of_Classes = new List<Classes>();
            try
            {
                StreamReader reader = new StreamReader(pathFile);
                string ClassID = reader.ReadLine();
                string[] split = ClassID.Split(',');

                foreach (var classL in List_Of_Classes)
                {
                    if (classL.ClassID == ClassID)
                        return;
                }

                var newClass = new Classes();
                newClass.ClassID = split[0];
                

                List_Of_Classes.Add(newClass);

                reader.Close();

                //Import To DATABASE
                InitialClassesToDatabase(newClass.ClassID);

                return;
            }
            catch
            {
                return;
            }
        }
        public void LoadStudents(string pathFile)
        {
            if (List_Of_Students == null)
                List_Of_Students = new List<Students>();
            if (List_Of_Account == null)
                List_Of_Account = new List<AccountLogIn>();
            try
            {
                StreamReader reader = new StreamReader(pathFile);

                string ClassID = reader.ReadLine();
                string[] splitClass = ClassID.Split(',');

                reader.ReadLine();

                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(',');

                    
                    var newStudent = new Students();

                    newStudent.StudentID = split[1];
                    newStudent.FullName = split[2];
                    newStudent.Gender = split[3];
                    newStudent.ID = split[4];

                    newStudent.classID = new Classes();
                    newStudent.classID.ClassID = splitClass[0];

                    var newAccount = new AccountLogIn();
                    newAccount.ID = newStudent.StudentID;
                    newAccount.Password = newStudent.ID;

                    List_Of_Students.Add(newStudent);
                    List_Of_Account.Add(newAccount);

                    InitialAccount(newAccount);
                }
                reader.Close();

                //Import To DATABSE
                InitialStudentsToDatabase(splitClass[0]);

                return;
            } catch
            {
                return;
            }

        }
        public void LoadCourses(string pathFile)
        {
            if (List_Of_Courses == null)
                List_Of_Courses = new List<Courses>();
            try
            {
                StreamReader reader = new StreamReader(pathFile);

                string ClassID = reader.ReadLine();
                string[] splitClass = ClassID.Split(',');

                reader.ReadLine();

                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(',');

                    var newCourse = new Courses();

                    newCourse.CourseID = split[1];
                    newCourse.CourseName = split[2];
                    newCourse.Room = split[3];
                    newCourse.classID = new Classes();
                    newCourse.classID.ClassID = splitClass[0];

                    List_Of_Courses.Add(newCourse);
                    LoadClassCourses(newCourse);

                }
                reader.Close();

                //Import To DATABASE
                InitialCoursesToDatabase(splitClass[0]);
                InitialClassCoursesToDatabase(splitClass[0]);
                return;
            }catch
            {
                return;
            }

        }
        public void LoadClassCourses(Courses course)
        {
            if (List_Of_ClassCourses == null)
                List_Of_ClassCourses = new List<ClassCourse>();
            else
            {
                foreach (var classCourse in List_Of_ClassCourses)
                {
                    if (classCourse.course.CourseID == course.CourseID && classCourse.course.classID == course.classID)
                        return;
                }
            }

            ClassCourse newClassCourse = new ClassCourse();
            newClassCourse.course = course;

            newClassCourse.students = new List<Students>();

            foreach (var student in List_Of_Students)
            {
                if (student.classID.ClassID == course.classID.ClassID)
                {
                    newClassCourse.students.Add(student);
                }
            }
            List_Of_ClassCourses.Add(newClassCourse);

            return;
        }
        

        public void LoadGradeClassCourse(string pathFile)
        {
            if (List_Of_GradeClassCourses == null)
                List_Of_GradeClassCourses = new List<GradeClassCourse>();
            try
            {
                StreamReader reader = new StreamReader(pathFile);


                string ClassID_Course = reader.ReadLine();
                string classID_course = ClassID_Course.Replace('-', ',');
                string[] splitCI = classID_course.Split(',');

                GradeClassCourse newGradeClassCourse = new GradeClassCourse();
                newGradeClassCourse.classCourse = null;

                foreach (var classCourse in List_Of_ClassCourses)
                {
                    if (classCourse.course.CourseID == splitCI[1] && classCourse.course.classID.ClassID == splitCI[0])
                    {
                        newGradeClassCourse.classCourse = classCourse;
                    }
                }

                newGradeClassCourse.listGrade = new List<Grade>();
                reader.ReadLine();

                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(',');

                    Grade newGrade = new Grade();

                    newGrade.StudentID = split[1];
                    newGrade.GradeGK = double.Parse(split[3]);
                    newGrade.GradeCK = double.Parse(split[4]);
                    newGrade.GradeE = double.Parse(split[5]);
                    newGrade.TotalGrade = double.Parse(split[6]);

                    newGradeClassCourse.listGrade.Add(newGrade);
                }
                reader.Close();
                List_Of_GradeClassCourses.Add(newGradeClassCourse);

                InitialGradeCourses(newGradeClassCourse.classCourse.course.CourseID);
                return;
            }
            catch {
                return;
            }
        }

        public bool AddStudent(Students newStudent)
        {
            if (List_Of_Students != null)
            {
                List_Of_Students.Add(newStudent);
                var newAccount = new AccountLogIn();
                newAccount.ID = newStudent.StudentID;
                newAccount.Password = newStudent.ID;
                if (List_Of_Account == null)
                    List_Of_Account = new List<AccountLogIn>();
                List_Of_Account.Add(newAccount);
                InitialAccount(newAccount);
                try
                {
                    OleDbConnection connect = new OleDbConnection();
                    connect.ConnectionString = conn;
                    connect.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "INSERT INTO Students VALUES (?,?,?,?,?)";

                    OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                    para.Value = newStudent.StudentID;

                    para = cmd.Parameters.Add("", OleDbType.LongVarChar);
                    para.Value = newStudent.FullName;

                    para = cmd.Parameters.Add("", OleDbType.VarChar);
                    para.Value = newStudent.Gender;

                    para = cmd.Parameters.Add("", OleDbType.VarChar);
                    para.Value = newStudent.ID;

                    para = cmd.Parameters.Add("", OleDbType.VarChar);
                    para.Value = newStudent.classID.ClassID;

                    cmd.ExecuteNonQuery();

                    if (List_Of_ClassCourses != null)
                    {
                        foreach (var classCourse in List_Of_ClassCourses)
                        {
                            if (classCourse.course.classID.ClassID == newStudent.classID.ClassID)
                                classCourse.students.Add(newStudent);
                        }
                        foreach (var classCourse in List_Of_ClassCourses)
                        {
                            if (classCourse.course.classID.ClassID == newStudent.classID.ClassID)
                            {
                                cmd.CommandText = "INSERT INTO ClassCourses VALUES (?,?)";

                                para = cmd.Parameters.Add("", OleDbType.VarChar);
                                para.Value = classCourse.course.CourseID;

                                para = cmd.Parameters.Add("", OleDbType.VarChar);
                                para.Value = newStudent.StudentID;

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    connect.Close();

                    return true;
                } catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool AddStudentToClassCourse (Students AStudent,ClassCourse AClassCourse)
        {
            foreach (var course in List_Of_ClassCourses)
            {
               if(course.course.CourseID == AClassCourse.course.CourseID && course.course.classID.ClassID == AClassCourse.course.classID.ClassID)
                {
                    course.students.Add(AStudent);
                    try
                    {
                        OleDbConnection connect = new OleDbConnection();
                        connect.ConnectionString = conn;
                        connect.Open();

                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connect;
                        cmd.CommandText = "INSERT INTO ClassCourses VALUES (?,?)";

                        OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = course.course.CourseID;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = AStudent.StudentID;

                        cmd.ExecuteNonQuery();

                        connect.Close();

                        return true;
                    }catch
                    {
                        //return false;
                    }
                }
            }
            return false;
        }
        public bool RemoveStudentFromClassCourse(Students AStudent, ClassCourse AClassCourse)
        {
            foreach (var course in List_Of_ClassCourses)
            {
                if (course.course.CourseID == AClassCourse.course.CourseID && course.course.classID.ClassID == AClassCourse.course.classID.ClassID)
                {
                    course.students.Remove(AStudent);
                    try
                    {
                        OleDbConnection connect = new OleDbConnection();
                        connect.ConnectionString = conn;
                        connect.Open();

                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connect;
                        cmd.CommandText = "DELETE FROM ClassCourses WHERE CourseID = ? AND StudentID = ?";

                        OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = course.course.CourseID;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = AStudent.StudentID;

                        cmd.ExecuteNonQuery();

                        connect.Close();

                        return true;
                    }
                    catch
                    {

                    }
                }
            }
            return false;
        }
        public bool updateGradeStudentInClassCourse(GradeClassCourse seleted,Grade newGrade)
        {
            if (List_Of_GradeClassCourses != null)
            {
                foreach (var classCourse in List_Of_GradeClassCourses)
                {
                    if(classCourse.classCourse.course.CourseID==seleted.classCourse.course.CourseID&& classCourse.classCourse.course.classID.ClassID== seleted.classCourse.course.classID.ClassID)
                    {
                        foreach (var student in classCourse.listGrade)
                        {
                            if(student.StudentID==newGrade.StudentID)
                            {
                                student.GradeCK = newGrade.GradeCK;
                                student.GradeGK = newGrade.GradeGK;
                                student.GradeE = newGrade.GradeE;
                                student.TotalGrade = newGrade.TotalGrade;
                                try
                                {
                                    OleDbConnection connect = new OleDbConnection();
                                    connect.ConnectionString = conn;
                                    connect.Open();

                                    OleDbCommand cmd = new OleDbCommand();
                                    cmd.Connection = connect;
                                    cmd.CommandText = "Update GradeCourses SET GradeGK = ?, GradeCK = ?, GradeE = ?, Total = ? WHERE CourseID = ? AND StudentID = ?";

                                    OleDbParameter para = cmd.Parameters.Add("", OleDbType.Double);
                                    para.Value = student.GradeGK;

                                    para = cmd.Parameters.Add("", OleDbType.Double);
                                    para.Value = student.GradeCK;

                                    para = cmd.Parameters.Add("", OleDbType.Double);
                                    para.Value = student.GradeE;

                                    para = cmd.Parameters.Add("", OleDbType.Double);
                                    para.Value = student.TotalGrade;

                                    para = cmd.Parameters.Add("", OleDbType.VarChar);
                                    para.Value = classCourse.classCourse.course.CourseID;

                                    para = cmd.Parameters.Add("", OleDbType.VarChar);
                                    para.Value = student.StudentID;

                                    cmd.ExecuteNonQuery();

                                    return true;
                                }
                                catch { }
                            }
                        }
                    }
                }
                return false;
            }
            return false;
        }
        public bool changePassword(AccountLogIn account)
        {
            if (List_Of_Account!=null)
            {
                foreach (var acc in List_Of_Account)
                {
                    if(acc.ID == account.ID)
                    {
                        acc.Password = account.Password;

                        try
                        {
                            OleDbConnection connect = new OleDbConnection();
                            connect.ConnectionString = conn;
                            connect.Open();

                            OleDbCommand cmd = new OleDbCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "Update Account SET Pass = ? WHERE ID = ?";

                            OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                            para.Value = account.Password;

                            para = cmd.Parameters.Add("", OleDbType.VarChar);
                            para.Value = account.ID;

                            cmd.ExecuteNonQuery();

                            connect.Close();
                            return true;
                        }
                        catch { }
                    }
                }
                return false;
            }
            return false;
        }
        public bool InitialClassesToDatabase(string ClassID)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                foreach (var classes in List_Of_Classes)
                {
                    if (classes.ClassID == ClassID)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connect;
                        cmd.CommandText = "INSERT INTO Classes VALUES (?)";
                        OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = classes.ClassID;

                        cmd.ExecuteNonQuery();
                    }
                }

                connect.Close();
                return true;
            }
            catch { return false; }
        }
        public bool InitialStudentsToDatabase(string ClassID)
        {

            try
            {
                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                foreach (var student in List_Of_Students)
                {
                    if (student.classID.ClassID == ClassID)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connect;
                        cmd.CommandText = "INSERT INTO Students VALUES (?,?,?,?,?)";

                        OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = student.StudentID;

                        para = cmd.Parameters.Add("", OleDbType.LongVarChar);
                        para.Value = student.FullName;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = student.Gender;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = student.ID;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = student.classID.ClassID;

                        cmd.ExecuteNonQuery();
                    }
                }
                connect.Close();
                return true;
            }
            catch { return false; }
        }
        public bool InitialCoursesToDatabase(string ClassID)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                foreach (var courses in List_Of_Courses)
                {
                    if (courses.classID.ClassID == ClassID)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connect;
                        cmd.CommandText = "INSERT INTO Courses VALUES (?,?,?,?)";

                        OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = courses.CourseID;

                        para = cmd.Parameters.Add("", OleDbType.LongVarChar);
                        para.Value = courses.CourseName;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = courses.Room;

                        para = cmd.Parameters.Add("", OleDbType.VarChar);
                        para.Value = courses.classID.ClassID;

                        cmd.ExecuteNonQuery();
                    }
                }
                connect.Close();
                return true;
            }
            catch { return false; }
        }
        public bool InitialClassCoursesToDatabase(string ClassID)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                foreach (var classeCourse in List_Of_ClassCourses)
                {
                    if (classeCourse.course.classID.ClassID == ClassID)
                    {
                        foreach (var student in classeCourse.students)
                        {

                            OleDbCommand cmd = new OleDbCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "INSERT INTO ClassCourses VALUES (?,?)";

                            OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                            para.Value = classeCourse.course.CourseID;

                            para = cmd.Parameters.Add("", OleDbType.VarChar);
                            para.Value = student.StudentID;

                            cmd.ExecuteNonQuery();

                        }
                    }
                }

                connect.Close();
                return true;
            }
            catch { return false; }
        }
        public bool InitialGradeCourses(string CourseID)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                foreach (var GradeCourse in List_Of_GradeClassCourses)
                {
                    if (GradeCourse.classCourse.course.CourseID == CourseID)
                    {
                        foreach (var grade in GradeCourse.listGrade)
                        {
                            OleDbCommand cmd = new OleDbCommand();
                            cmd.Connection = connect;
                            cmd.CommandText = "INSERT INTO GradeCourses VALUES (?,?,?,?,?,?)";


                            OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                            para.Value = GradeCourse.classCourse.course.CourseID;

                            para = cmd.Parameters.Add("", OleDbType.VarChar);
                            para.Value = grade.StudentID;

                            para = cmd.Parameters.Add("", OleDbType.Double);
                            para.Value = grade.GradeGK;

                            para = cmd.Parameters.Add("", OleDbType.Double);
                            para.Value = grade.GradeCK;

                            para = cmd.Parameters.Add("", OleDbType.Double);
                            para.Value = grade.GradeE;

                            para = cmd.Parameters.Add("", OleDbType.Double);
                            para.Value = grade.TotalGrade;

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                connect.Close();
                return true;
            }
            catch { return false; }
        }
        public bool InitialAccount(AccountLogIn account)
        {
            try
            {
                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Insert INTO Account VALUES (?,?)";

                OleDbParameter para = cmd.Parameters.Add("", OleDbType.VarChar);
                para.Value = account.ID;

                para = cmd.Parameters.Add("", OleDbType.VarChar);
                para.Value = account.Password;

                cmd.ExecuteNonQuery();

                connect.Close();
                return true;
            }
            catch { return false; }
        }
        public bool LoadData()
        {
            
            try
            {
                List_Of_Classes = new List<Classes>();
                List_Of_Students = new List<Students>();
                List_Of_Courses = new List<Courses>();
                List_Of_ClassCourses = new List<ClassCourse>();
                List_Of_GradeClassCourses = new List<GradeClassCourse>();
                List_Of_Account = new List<AccountLogIn>();

                OleDbConnection connect = new OleDbConnection();
                connect.ConnectionString = conn;
                connect.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connect;

                cmd.CommandText = "SELECT * FROM Classes";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var Class = new Classes();
                    Class.ClassID = reader.GetString(0);
                    List_Of_Classes.Add(Class);
                }

                reader.Close();

                cmd.CommandText = "SELECT * FROM Students";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var student = new Students();
                    student.StudentID = reader.GetString(0);
                    student.FullName = reader.GetString(1);
                    student.Gender = reader.GetString(2);
                    student.ID = reader.GetString(3);
                    student.classID = new Classes();
                    student.classID.ClassID = reader.GetString(4);

                    List_Of_Students.Add(student);
                }

                reader.Close();

                cmd.CommandText = "SELECT * FROM Courses";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var course = new Courses();
                    course.CourseID = reader.GetString(0);
                    course.CourseName = reader.GetString(1);
                    course.Room = reader.GetString(2);
                    course.classID = new Classes();
                    course.classID.ClassID = reader.GetString(3);

                    List_Of_Courses.Add(course);
                }

                reader.Close();

                cmd.CommandText = "SELECT distinct CourseID FROM ClassCourses";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var classCourse = new ClassCourse();
                    string temp = reader.GetString(0);
                    foreach (var course in List_Of_Courses)
                    {
                        if (course.CourseID == temp)
                        {
                            classCourse.course = course;
                            classCourse.students = new List<Students>();

                            OleDbCommand cmd2 = new OleDbCommand();
                            cmd2.Connection = connect;
                            cmd2.CommandText = $"SELECT StudentID FROM ClassCourses WHERE CourseID = '{course.CourseID}' ";
                            OleDbDataReader rd = cmd2.ExecuteReader();
                            while (rd.Read())
                            {
                                string StudentID = rd.GetString(0);
                                foreach (var stu in List_Of_Students)
                                {
                                    if (stu.StudentID == StudentID)
                                        classCourse.students.Add(stu);
                                }
                            }
                            rd.Close();

                            List_Of_ClassCourses.Add(classCourse);
                        }
                    }
                }
                reader.Close();

                cmd.CommandText = "SELECT distinct CourseID FROM GradeCourses";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var gradeClassCourse = new GradeClassCourse();
                    gradeClassCourse.classCourse = new ClassCourse();
                    string temp = reader.GetString(0);
                    foreach (var course in List_Of_Courses)
                    {
                        if (course.CourseID == temp)
                        {
                            gradeClassCourse.classCourse.course = course;
                            gradeClassCourse.listGrade = new List<Grade>();

                            OleDbCommand cmd2 = new OleDbCommand();
                            cmd2.Connection = connect;
                            cmd2.CommandText = $"SELECT * FROM GradeCourses WHERE CourseID = '{course.CourseID}' ";
                            OleDbDataReader rd = cmd2.ExecuteReader();
                            while (rd.Read())
                            {
                                Grade newGrade = new Grade();
                                newGrade.StudentID = rd.GetString(1);
                                newGrade.GradeGK = rd.GetDouble(2);
                                newGrade.GradeCK = rd.GetDouble(3);
                                newGrade.GradeE = rd.GetDouble(4);
                                newGrade.TotalGrade = rd.GetDouble(5);

                                gradeClassCourse.listGrade.Add(newGrade);
                            }
                            rd.Close();

                            List_Of_GradeClassCourses.Add(gradeClassCourse);
                        }
                    }
                }
                reader.Close();

                cmd.CommandText = "SELECT * FROM Account";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var account = new AccountLogIn();
                    account.ID = reader.GetString(0);
                    account.Password = reader.GetString(1);

                    List_Of_Account.Add(account);
                }
                reader.Close();

                connect.Close();
                return true;
            }
            catch { return false; }
        }          
    }
}
