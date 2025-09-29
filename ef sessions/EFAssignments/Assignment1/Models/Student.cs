using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }

        // 🔗 Each Student belongs to one Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // 🔗 Many-to-Many with Courses via StudCourse
        public ICollection<StudCourse> StudCourses { get; set; } = new List<StudCourse>();
    }
}
