using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public int Duration { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        // 🔗 Each Course belongs to one Topic
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        // 🔗 Many-to-Many with Students
        public ICollection<StudCourse> StudCourses { get; set; } = new List<StudCourse>();

        // 🔗 Many-to-Many with Instructors
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    }
}
