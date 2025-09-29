using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Bonus { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public decimal HourRate { get; set; }

        // 🔗 Belongs to Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // 🔗 Many-to-Many with Courses
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    }
}
