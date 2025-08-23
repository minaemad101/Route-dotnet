using OOP_Exam.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exams
{
    internal class PracticalExam: Exam
    {
        private MCQQuestion[]? mcqQuestions;

        public PracticalExam(int time, int numQuestions) : base(time, numQuestions)
        {
            mcqQuestions = new MCQQuestion[numQuestions];
            CreateQuestions();
        }

        private void CreateQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Creating MCQ Question {i + 1}");
                mcqQuestions[i] = new MCQQuestion("", "", 0);
                mcqQuestions[i].CreateQuestion();
            }
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Practical Exam (Time: {Time} mins)");

            int score = 0;

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                mcqQuestions[i].DisplayQuestion();

                int answer;
                while (true)
                {
                    Console.Write("Enter your answer: ");
                    if (int.TryParse(Console.ReadLine(), out answer) &&
                        mcqQuestions[i].AnswersList != null &&
                        answer >= 1 &&
                        answer <= mcqQuestions[i].AnswersList.Length)
                        break;

                    Console.WriteLine(" Invalid answer. Try again.");
                }

                if (answer == mcqQuestions[i].CorrectAnswer)
                {
                    score += mcqQuestions[i].Mark;
                }
            }

            Console.WriteLine($" Exam Finished. Your score: {score}");
            Console.WriteLine("Correct Answers:");
            foreach (var q in mcqQuestions)
            {
                Console.WriteLine($"{q.Body}: Correct: {q.AnswersList![q.CorrectAnswer!.Value - 1]}");
            }
        }
    }
}
