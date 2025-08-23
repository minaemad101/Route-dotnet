using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Exams
{
    internal abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public Exam(int time, int numberQuestions)
        {
            Time = time;
            NumberOfQuestions = numberQuestions;
        }

        public abstract void ShowExam();
    }
}
