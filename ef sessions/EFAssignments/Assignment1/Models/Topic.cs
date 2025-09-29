using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    internal class Topic
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // 🔗 One-to-Many with Courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
