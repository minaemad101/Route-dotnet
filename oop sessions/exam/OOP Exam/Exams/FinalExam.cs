using OOP_Exam.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exams
{
    internal class FinalExam : Exam
    {
        private Question[]? questions;

        public FinalExam(int time, int numQuestions) : base(time, numQuestions)
        {
            questions = new Question[numQuestions];
            CreateQuestions();
        }

        public void CreateQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Creating Question {i + 1}");
                Console.Write("Enter question type (1: MCQ, 2: True/False): ");
                int type;
                while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2))
                {
                    Console.WriteLine("Invalid input. Enter 1 for MCQ or 2 for True/False.");
                }

                if (type == 1)
                {
                    questions[i] = new MCQQuestion("", "", 0);
                }
                else
                {
                    questions[i] = new TFQuestion("", "", 0);
                }

                questions[i].CreateQuestion();
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine($" Final Exam (Time: {Time} mins)");

            int score = 0;

            foreach (var q in questions!)
            {
                q.DisplayQuestion();

                int answer;
                while (true)
                {
                    Console.Write("Enter your answer: ");
                    if (int.TryParse(Console.ReadLine(), out answer) &&
                        q.AnswersList != null &&
                        answer >= 1 &&
                        answer <= q.AnswersList.Length)
                        break;

                    Console.WriteLine(" Invalid answer. Try again.");
                }

                if (answer == q.CorrectAnswer)
                {
                    score += q.Mark;
                }
            }

            Console.WriteLine($" Exam Finished. Your total grade: {score}");
        }
    }
}
