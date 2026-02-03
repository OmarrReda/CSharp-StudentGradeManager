using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GradeManager
{
    public class Student
    {
        private string studentName;
        private int studentID;
        private Dictionary<string, double> grades;

        public Student (string studentName, int studentID)
        {
            this.studentName = studentName;
            this.studentID = studentID;
            grades = new Dictionary<string, double>();
        }
        public string GetStudentName() => studentName;
        public int GetStudentID() => studentID;
        public Dictionary<string, double> GetAllGrades() => grades;
        public double? GetCourseGrade(string courseID)
        {
            if (string.IsNullOrWhiteSpace(courseID))
                return null;

            courseID = courseID.Trim().ToLower();

            if (grades.ContainsKey(courseID))
            {
                return grades[courseID];
            }
            return null;
        }
        public bool SetStudentName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (!int.TryParse(name, out int result))
                {
                    studentName = name;
                    return true;
                }
            }
            return false;
        }
        public bool SetStudentID(string ID)
        {
            if (int.TryParse(ID, out int result))
            {
                studentID = result;
                return true;
            }
            return false;
        }
        public bool SetGrade(string courseID, double score)
        {

            if (string.IsNullOrWhiteSpace(courseID) && score < 0 || score > 100)
                { 
                return false; 
                }

            courseID = courseID.Trim().ToLower();

            grades[courseID] = score;    
            return true;
        }
        public double CalculateAverageStudentGrade()
        {
            if (grades.Count == 0)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                foreach (var grade in grades.Values)
                {
                    sum += grade;
                }
                return sum / grades.Count;
            }
        }

        
    }
}
