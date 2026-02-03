using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    public class Grade
    {
        private List<Student> students;
        private List<Course> courses;

        public Grade ()
        {
            students = new List<Student> ();
            courses = new List<Course> ();
        }

        public List<Student> GetStudents() => students;
        public List<Course> GetCourses() => courses;

        public bool SetStudent(Student student)
        {
            if (students.Any(s => s.GetStudentID() == student.GetStudentID()))
            {
                return false;
            }

            students.Add(student);
            return true;
        }

        public bool SetCourse(Course course)
        {
            if (courses.Any(c => c.GetCourseID() == course.GetCourseID()))
            {
                return false;
            }

            courses.Add(course);
            return true;
        }

        public Student FindStudentByID(int id)
        {
            foreach (var student in students)
            {
                if (student.GetStudentID() == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Course FindCourseByID(string id)
        {
            foreach(var course in courses)
            {
                if (course.GetCourseID().Equals(id))
                {
                    return course;
                }
            }
            return null;
        }

        public bool AddGrade(int id, string courseID, double score)
        {
            Student student = FindStudentByID(id);
            Course course = FindCourseByID(courseID);

            if (student == null || course == null)
                return false;

            course.EnrollStudentInCourse(student);

            
            student.SetGrade(courseID, score);
            return true;
        }

        public Student ViewStudents()
        {
            foreach(var student in students)
            {
                return student;
            }
            return null;
        }

        public double CalculateStudentAverage(int id)
        {
            Student student = FindStudentByID(id);
            if (student != null)
            {
                return student.CalculateAverageStudentGrade();
            }

            return 0;
        }
        public double? CalculateCourseAverage(string id)
        {
            Course course = FindCourseByID(id);
            if (course != null)
            {
                return course.CalculateAverageCourseGrade();
            }
            return null;
        }

        public Dictionary<int, double> GenerateCourseReport(string courseID)
        {
            Course course = FindCourseByID(courseID);

            if (course == null)
            {
                return null;
            }

            return course.GetCourseReport();
        }


    }

}
