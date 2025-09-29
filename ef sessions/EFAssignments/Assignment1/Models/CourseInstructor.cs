using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    internal class CourseInstructor
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public string? Evaluate { get; set; }
    }
}
