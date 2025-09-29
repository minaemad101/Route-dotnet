using Assignment1.Contexts;


using Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ITIDbContext())
            {
                // create
                // Create Department
                var dept = new Department
                {
                    Name = "Computer Science",
                    HiringDate = DateTime.Now,
                    InstructorMgrId = 1 // assuming instructor exists
                };

                context.Departments.Add(dept);

                // Create Instructor
                var instructor = new Instructor
                {
                    Name = "Dr. Mina",
                    Salary = 20000,
                    Bonus = 1500,
                    HourRate = 100,
                    Department = dept
                };

                context.Instructors.Add(instructor);

                // Create Topic
                var topic = new Topic { Name = "Databases" };
                context.Topics.Add(topic);

                // Create Course
                var course = new Course
                {
                    Name = "Entity Framework Core",
                    Duration = 30,
                    Topic = topic
                };
                context.Courses.Add(course);

                // Create Student
                var student = new Student
                {
                    FName = "John",
                    LName = "Doe",
                    Age = 23,
                    Address = "Cairo",
                    Department = dept
                };
                context.Students.Add(student);

                // Student ↔ Course
                var studCourse = new StudCourse
                {
                    Student = student,
                    Course = course,
                    Grade = 95
                };
                context.StudCourses.Add(studCourse);

                // Instructor ↔ Course
                var courseInstructor = new CourseInstructor
                {
                    Instructor = instructor,
                    Course = course,
                    Evaluate = "Excellent"
                };
                context.CourseInstructors.Add(courseInstructor);

                context.SaveChanges();

                // read
                var students = context.Students.ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.FName} {s.LName}, DeptId: {s.DepartmentId}");
                }

                // update
                var upstudent = context.Students.FirstOrDefault(s => s.Id == 1);
                if (upstudent != null)
                {
                    upstudent.Address = "Alexandria";
                    context.SaveChanges();
                }

                //delete
                var delcourse = context.Courses.FirstOrDefault(c => c.Id == 1);
                if (delcourse != null)
                {
                    context.Courses.Remove(delcourse);
                    context.SaveChanges();
                }

                // eager loading
                var eagerstudents = context.Students
                    .Include(s => s.Department)
                    .Include(s => s.StudCourses)
                        .ThenInclude(sc => sc.Course)
                    .ToList();

                foreach (var s in eagerstudents)
                {
                    Console.WriteLine($"{s.FName} {s.LName}, Department: {s.Department.Name}");
                    foreach (var sc in s.StudCourses)
                    {
                        Console.WriteLine($" - Course: {sc.Course.Name}, Grade: {sc.Grade}");
                    }
                }
                // will still study the lazy loading
            }
        }
    }
}
