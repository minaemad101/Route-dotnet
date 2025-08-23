using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Questions
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string? header, string? body, int mark)
             : base(header, body, mark) { }

        public override void CreateQuestion()
        {
            Console.WriteLine("Creating MCQ Question...");
            do {
                Console.Write("Enter Question Header: ");
                Header = Console.ReadLine();
            }
            while(Header == null || Header == "");
            do {
                Console.Write("Enter Question Body: ");
                Body = Console.ReadLine();
            }
            while(Body == null || Body == "");

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
            Console.Write("Enter number of options: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 2)
            {
                Console.WriteLine("Invalid. Please enter at least 2 options.");
            }

            AnswersList = new Answer[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter text for option {i + 1}: ");
                string text = Console.ReadLine() ?? $"Option {i + 1}";
                AnswersList[i] = new Answer(i + 1, text);
            }

            // Correct Answer Validation
            int correct;
            while (true)
            {
                Console.Write("Enter the number of the correct option: ");
                if (int.TryParse(Console.ReadLine(), out correct) &&
                    correct >= 1 && correct <= count)
                {
                    CorrectAnswer = correct;
                    break;
                }
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
