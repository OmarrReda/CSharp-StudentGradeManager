using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GradeManager
{
    public class Course
    {
        private string courseName;
        private string courseID;
        private List<Student> enrolledStudents;

        public Course (string courseName, string courseID)
        {
            this.courseName = courseName;
            this.courseID = courseID;
            enrolledStudents = new List<Student>();
        }
        public string GetCourseName() => courseName;
        public string GetCourseID() => courseID;
        public List<Student> GetEnrolledStudents() => enrolledStudents;
        
        public bool SetCourseName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (!int.TryParse(name, out int result))
                {
                    courseName = name;
                    return true;
                }
            }
            return false;
        }
        public bool SetCourseID(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (!int.TryParse(name, out int result))
                {
                    courseID = name;
                    return true;
                }
            }
            return false;
        }
        public bool EnrollStudentInCourse(Student student)
        {
            if (enrolledStudents.Any(s => s.GetStudentID() == student.GetStudentID()))
            {
                return false;
            }

            enrolledStudents.Add(student);
            return true;
        }
        public double CalculateAverageCourseGrade()
        {
            double sum = 0;
            int count = 0;
            string normalizedCourseID = courseID.Trim().ToLower();

            foreach (var student in enrolledStudents)
            {
                double? grade = student.GetCourseGrade(normalizedCourseID);

                if (grade.HasValue)
                {
                    sum += grade.Value;
                    count++;
                }
            }

            if (count == 0) { return 0; }

            return sum / count;

        }
         public Dictionary<int, double> GetCourseReport()
        {
            var report = new Dictionary<int, double>();
            foreach (var student in enrolledStudents)
            {
                double? grade = student.GetCourseGrade(courseID);

                if (grade != null)
                {
                    report[student.GetStudentID()] = grade.Value;
                }
            }

            return report;
        }


    }
}
