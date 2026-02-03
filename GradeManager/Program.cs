using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager
{
    internal class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("Student grade management system");
            Console.WriteLine("1 - Add Student");
            Console.WriteLine("2 - Add Course");
            Console.WriteLine("3 - Enter grade to Student");
            Console.WriteLine("4 - Calculate student average");
            Console.WriteLine("5 - Generate Report");
            Console.WriteLine("6 - Exit");
        }

        static void AddStudent(Grade manager)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid name, please try again.");
                return;
            }

            Console.Write("Please enter student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int studentID))
            {
                Console.WriteLine("Invalid student ID, Please try again.");
                return;
            }

            Student student = new Student(name, studentID);
            manager.SetStudent(student);
            Console.WriteLine("Student successfully registered!");
        }

        static void AddCourse(Grade manager)
        {
            Console.Write("Please enter course name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid course name, please try again.");
                return;
            }

            Console.Write("Please enter course ID. EX:'math101': ");
            string courseID = Console.ReadLine().ToLower().Trim();
            if (int.TryParse(courseID, out int validate))
            {
                Console.WriteLine("invalid Course ID, try something like 'math101'.");
                return;
            }    

            Course course = new Course(name, courseID);
            manager.SetCourse(course);
            Console.WriteLine($"{courseID} successfully added!");
            
        }

        static void AddGrade(Grade manager)
        {
            Console.Write("Enter student ID: ");
            string id = Console.ReadLine();
            if (!int.TryParse(id, out int studentID))
            {
                Console.WriteLine("invalid student ID, please try again.");
                return;
            }

            Student student = manager.FindStudentByID(studentID);

            if (student == null)
            {
                Console.WriteLine("Student doesn't exist");
                return;
            }

            Console.Write("Enter Course ID: ");
            string courseID = Console.ReadLine().ToLower().Trim();
            if (int.TryParse(courseID, out int validate))
            {
                Console.WriteLine("invalid Course ID, try something like 'Math101'.");
                return;
            }

            Course course = manager.FindCourseByID(courseID);
            if (course == null)
            {
                Console.WriteLine("Course does not exist");
                return;
            }

            Console.Write("Enter grade: ");
            if (!double.TryParse(Console.ReadLine(),out double score))
            {
                Console.WriteLine("Invalid grade, Please try again.");
                return;
            }

            manager.AddGrade(studentID, courseID, score);
            Console.WriteLine("Grade added");
        }

        static void CalculateAverageStudentGrade(Grade manager)
        {
            Console.Write("Enter student ID: ");
            
            if (!int.TryParse(Console.ReadLine(), out int studentID))
            {
                Console.WriteLine("Invalid ID, Please try again.");
                return;
            }
            Student student = manager.FindStudentByID(studentID);

            if (student == null)
            {
                Console.WriteLine("Student doesn't exist");
                return;
            }

            Console.WriteLine($"Student average = {manager.CalculateStudentAverage(studentID)}");

        }
        

        static void ShowReport(Grade manager)
        {
            Console.Write("Enter Course ID: ");
            string courseID = Console.ReadLine().ToLower().Trim();
            if (int.TryParse(courseID, out int validate))
            {
                Console.WriteLine("invalid Course ID, try something like 'Math101'.");
                return;
            }

            var report = manager.GenerateCourseReport(courseID);

            Course course = manager.FindCourseByID(courseID);
            if (course == null)
            {
                Console.WriteLine("Course does not exist");
                return;
            }

            if (report == null || report.Count == 0)
            {
                Console.WriteLine("no grades found for this course");
                return;
            }
            Console.Clear();

            Console.WriteLine($"Report for course {courseID}");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Course Average = {manager.CalculateCourseAverage(courseID)}");
            foreach (var item in report)
            {
                Console.WriteLine($"Student ID:{item.Key} Grade:{item.Value}");
            }


        }
        

        static void Main()
        {
            Grade manager = new Grade();
            while (true)
            {
                ShowMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        AddStudent(manager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        AddCourse(manager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        AddGrade(manager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        CalculateAverageStudentGrade(manager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        ShowReport(manager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Application Closed");
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input, please try again");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
                
            }
        }
    }
}
