using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSM.Entity
{
    public class Classes
    {
        public string ClassID { get; set; }
    }
    public class Students
    {
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ID { get; set; }
        public Classes classID { get; set; }
    }
    public class Courses
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string Room { get; set; }
        public Classes classID { get; set; }
    }
    public class ClassCourse
    {
        public Courses course { get; set; }
        public List<Students> students { get; set; }
    }
    public class Grade
    {
        public string StudentID { get; set; }
        public double GradeGK { get; set; }
        public double GradeCK { get; set; }
        public double GradeE { get; set; }
        public double TotalGrade { get; set; }
    }
    public class GradeClassCourse
    {
        public ClassCourse classCourse { get; set; }
        public List<Grade> listGrade { get; set; }
    }
    public class AccountLogIn
    {
        public string ID { get; set; }
        public string Password { get; set; }
    }
}
