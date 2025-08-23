namespace OOP_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub = new Subject(1, "OOP");
            sub.CreateExam();
            sub.Exam?.ShowExam();
        }
    }
}
