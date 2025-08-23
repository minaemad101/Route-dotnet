using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Questions
{
    internal abstract class Question
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public int Mark { get; set; }
        public Answer[]? AnswersList { get; set; }
        public int? CorrectAnswer { get; set; }

        // Constructor
        public Question() { }
        public Question(string? header, string? body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        // Abstract methods
        public abstract void CreateQuestion();
        public abstract void CreateAnswerList();

        // Show Question
        public void DisplayQuestion()
        {
            Console.WriteLine($"\n{Header} ({Mark} marks)");
            Console.WriteLine(Body);

            if (AnswersList != null)
            {
                foreach (var answer in AnswersList)
                {
                    Console.WriteLine(answer);
                }
            }
        }
    }
}
