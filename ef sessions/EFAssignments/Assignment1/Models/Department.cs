using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    internal class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime HiringDate { get; set; }

        // 🔗 Each Department has a Manager (Instructor)
        public int InstructorMgrId { get; set; }
        public Instructor Manager { get; set; }

        // 🔗 One-to-Many with Students
        public ICollection<Student> Students { get; set; } = new List<Student>();

        // 🔗 One-to-Many with Instructors
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
