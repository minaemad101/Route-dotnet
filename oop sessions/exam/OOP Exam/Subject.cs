using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Exam.Exams;

namespace OOP_Exam
{
    internal class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Exam? Exam { get; set; }

        public Subject() { }

        public Subject(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            Console.WriteLine("Enter exam type (practical | final): ");
            string? examType = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(examType) ||
                  !(examType.Equals("practical") ||
                    examType.Equals("final")))
            {
                Console.WriteLine("Invalid input. Please enter 'practical' or 'final'.");
                examType = Console.ReadLine();
            }

            int time;
            while (true)
            {
                Console.Write("Enter exam time in minutes: ");
                if (int.TryParse(Console.ReadLine(), out time) && time > 0)
                    break;
                Console.WriteLine("Invalid input. Enter a positive number.");
            }

            int numQuestions;
            while (true)
            {
                Console.Write("Enter number of questions: ");
                if (int.TryParse(Console.ReadLine(), out numQuestions) && numQuestions > 0)
                    break;
                Console.WriteLine("Invalid input. Enter a positive number.");
            }

            if (examType.Equals("practical", StringComparison.OrdinalIgnoreCase))
            {
                Exam = new PracticalExam(time, numQuestions);
            }
            else
            {
                Exam = new FinalExam(time, numQuestions);
            }

            Console.WriteLine($" {examType} exam created successfully for subject {Name}.");
        }
    }
}
