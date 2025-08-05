using System.Runtime.CompilerServices;

namespace OOP_Assignment_4
{
    #region part 1
    #region q1 Write a class named Calculator that contains a method named Add. Overload the Add method to
    internal class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Add(int x, int y, int z)
        {
            return x + y + z;
        }
        public static double Add(double x, double y)
        {
            return x + y;
        }
    }
    #endregion
    #region q2 Create a class named Rectangle with the following constructors
    internal class Rectangle
    {
        private int width;
        private int height;
        public Rectangle()
        {
            this.width = 0;
            this.height = 0;
        }
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public Rectangle(int side)
        {
            this.width = side;
            this.height = side;
        }
    }
    #endregion
    #region q3 Define a class Complex Number that represents a complex number with real and imaginary parts.
    internal class Complex
    {
        private double real;
        private double imaginary;
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public Complex(double r,double i) 
        {
            Real = r;
            Imaginary = i;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            Complex res = new Complex(a.Real+b.Real,a.Imaginary+b.Imaginary);
            return res;
        }
        public static Complex operator -(Complex a, Complex b)
        {
            Complex res = new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
            return res;
        }
        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

    }
    #endregion
    #region 4 Employee and Manager
    internal class Employee
    {
        public virtual void printinfo()
        {
            Console.WriteLine("Employee is working");
        }
    }
    internal class Manager : Employee
    {
        public override void printinfo()
        {
            Console.WriteLine("Manager is managing");
            base.printinfo();
        }
    }
    #endregion
    #region 5
    internal class BaseClass
    {
        public virtual void DisplayMessage()
        {
            Console.WriteLine("Message from BaseClass");
        }
    }
    internal class DerivedClass1:BaseClass
    {
        public override void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass1");
        }
    }
    internal class DerivedClass2 : BaseClass
    {
        public new void DisplayMessage()
        {
            Console.WriteLine("Message from DerivedClass2");
        }
    }
    #endregion
    #endregion
    #region part 2 Duration Class

    internal class Duration
    {
        private int hours;
        private int minutes;
        private int seconds;

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public override string ToString()
        {
            return $"{Hours} : {Minutes} : {Seconds}";
        }
        public override bool Equals(object? inobj)
        {
            if (inobj == null || !(inobj is Duration))
                return false;
            Duration obj = (Duration)inobj;
            return obj.Hours == this.Hours && obj.Minutes == this.Minutes && obj.Seconds == this.Seconds;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Duration()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Duration(double seconds)
        {
            Hours = (int)(seconds / 3600);
            seconds = seconds % 3600;
            Minutes = (int)(seconds / 60);
            Seconds = (int)(seconds % 60);
        }
        public static Duration operator +(Duration D1, Duration D2)
        {
            Duration res = new Duration((D1.Hours + D2.Hours) * 3600 + (D1.Minutes + D2.Minutes) * 60 + (D1.Seconds + D2.Seconds));
            return res;
        }
        public static Duration operator +(Duration D1, double secs)
        {
            Duration D2 = new Duration(secs);
            return D1 + D2;
        }
        public static Duration operator +(double secs, Duration D1)
        {
            Duration D2 = new Duration(secs);
            return D1 + D2;
        }
        public static Duration operator -(Duration D1, Duration D2)
        {
            Duration res = new Duration((D1.Hours - D2.Hours) * 3600 + (D1.Minutes - D2.Minutes) * 60 + (D1.Seconds - D2.Seconds));
            return res;
        }
        public static Duration operator +(Duration D1, double secs)
        {
            Duration D2 = new Duration(secs);
            return D1 - D2;
        }
        public static Duration operator +(double secs, Duration D1)
        {
            Duration D2 = new Duration(secs);
            return D2 - D1;
        }
        public static Duration operator ++(Duration D1)
        {
            if (D1.Minutes == 59)
            {
                D1.Minutes = 0;
                D1.Hours++;
            }
            else {
                D1.Minutes++;
            }
            return D1;
        }
        // this is getting me an error (sadface)
        //public static Duration operator ++(Duration D1, int _)
        //{
        //    Duration old = new Duration(D1.Hours, D1.Minutes, D1.Seconds);
        //    if (D1.Minutes == 59)
        //    {
        //        D1.Minutes = 0;
        //        D1.Hours++;
        //    }
        //    else
        //    {
        //        D1.Minutes++;
        //    }
        //    return old;
        //}
        public static Duration operator --(Duration D1)
        {
            if (D1.Minutes == 0)
            {
                D1.Minutes = 59;
                D1.Hours--;
            }
            else
            {
                D1.Minutes--;
            }
            return D1;
        }
        public static bool operator >(Duration D1, Duration D2)
        {
            if(D1.Hours != D2.Hours)
                return D1.Hours > D2.Hours;
            if(D1.Minutes != D2.Minutes)
                return D1.Minutes > D2.Minutes;
            return D1.Seconds != D2.Seconds;
        }
        public static bool operator <(Duration D2, Duration D1)
        {
            if (D1.Hours != D2.Hours)
                return D1.Hours > D2.Hours;
            if (D1.Minutes != D2.Minutes)
                return D1.Minutes > D2.Minutes;
            return D1.Seconds != D2.Seconds;
        }
        public static bool operator >=(Duration D1, Duration D2)
        {
            if (D1.Hours >= D2.Hours)
                return true;
            if (D1.Minutes >= D2.Minutes)
                return true;
            return D1.Seconds >= D2.Seconds;
        }
        public static bool operator <=(Duration D2, Duration D1)
        {
            if (D1.Hours >= D2.Hours)
                return true;
            if (D1.Minutes >= D2.Minutes)
                return true;
            return D1.Seconds >= D2.Seconds;
        }
        public static bool operator true(Duration D)
        {
            return (D.Hours!=0||D.Minutes!=0||D.Seconds!=0);
        }
        public static bool operator false(Duration D)
        {
            return (D.Hours==0&&D.Minutes==0&&D.Seconds==0);
        }
        // dont really know what to do with (DateTime) thank you!
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Complex A = new Complex(2d,3d);
            Complex B = new Complex(2d, 3d);
            Console.WriteLine(A);
            Console.WriteLine(A+B);

            Employee employee = new Employee();
            Manager manager = new Manager();
            employee.printinfo();
            manager.printinfo();

            BaseClass baseClass1 = new DerivedClass1();
            BaseClass baseclass2 = new DerivedClass2();
            DerivedClass1 derivedClass1 = new DerivedClass1();
            DerivedClass2 derivedClass2 = new DerivedClass2();
            baseClass1.DisplayMessage();
            baseclass2.DisplayMessage();
            derivedClass1.DisplayMessage();
            derivedClass2.DisplayMessage();

            /////////////// Part 2 ////////////////////
            Duration D1 = new Duration(666);
            Console.WriteLine(D1);

        }
    }
}
