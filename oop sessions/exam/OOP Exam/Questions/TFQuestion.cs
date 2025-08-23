using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Questions
{
    internal class TFQuestion: Question
    {
        public TFQuestion(string? header, string? body, int mark)
                   : base(header, body, mark) { }

        public override void CreateQuestion()
        {
            Console.WriteLine("\nCreating True/False Question...");
            Console.Write("Enter Question Header: ");
            Header = Console.ReadLine();

            Console.Write("Enter Question Body: ");
            Body = Console.ReadLine();

            // Validation for mark
            int mark;
            while (true)
            {
                Console.Write("Enter Question Mark: ");
                if (int.TryParse(Console.ReadLine(), out mark) && mark > 0) break;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            Mark = mark;

            CreateAnswerList();
        }

        public override void CreateAnswerList()
        {
            AnswersList = new Answer[2];
            AnswersList[0] = new Answer(1, "True");
            AnswersList[1] = new Answer(2, "False");

            // Correct Answer Validation
            int correct;
            while (true)
            {
                Console.Write("Enter the number of the correct answer (1 for True, 2 for False): ");
                if (int.TryParse(Console.ReadLine(), out correct) &&
                    (correct == 1 || correct == 2))
                {
                    CorrectAnswer = correct;
                    break;
                }
                Console.WriteLine("Invalid choice. Enter 1 or 2.");
            }
        }
    }
}
