namespace OOPAssignment2
{
    #region 1 Define a struct "Person" with properties "Name" and "Age".
    internal struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    #endregion
    #region 2 Create a struct called "Point" to represent a 2D point with properties "X" and   "Y"
    internal struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static double DistanceTo(Point p1, Point p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
    #endregion
    #region 4 Create a struct named Rectangle that represents a rectangle with the following fields: width(type: double) height(type: double) Implement encapsulation by making the fields private and provide public properties  access and modify these values.
    internal struct Rectangle
    {
        private double width;
        private double height;

        public double Width { 
            get { return width; }
            set
            {
                if (value >= 0)
                    width = value;
                else
                    Console.WriteLine("Width cannot be negative!");
            }
        }
        public double Height { 
            get { return height; }
            set
            {
                if (value >= 0)
                    height = value;
                else
                    Console.WriteLine("Height cannot be negative!");
            }
        }

        public double Area { get {  return width*height; } }
        public void DisplayInfo()
        {
            Console.WriteLine($"width = {width} height = {height} and the area = {Area}");
        }
    }
    #endregion

    internal class Program
    {

        static void Main(string[] args)
        {
            #region 1 Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
            {
                Person[] people = new Person[3];
                people[0] = new Person("name1", 1);
                people[1] = new Person("name2", 2);
                people[2] = new Person("name3", 3);
                Console.WriteLine("List of people:");
                foreach (var person in people)
                {
                    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
                }
            }
            #endregion
            #region 2 Write a C# program that takes two points as input from the user and calculates the distance between them.
            {
                // Read first point
                Console.WriteLine("Enter coordinates for Point 1:");
                Console.Write("X1: ");
                int.TryParse(Console.ReadLine(), out int x1);
                Console.Write("Y1: ");
                int.TryParse(Console.ReadLine(), out int y1);
                Point p1 = new Point(x1, y1);

                // Read second point
                Console.WriteLine("Enter coordinates for Point 2:");
                Console.Write("X2: ");
                int.TryParse(Console.ReadLine(), out int x2);
                Console.Write("Y2: ");
                int.TryParse(Console.ReadLine(), out int y2);
                Point p2 = new Point(x2, y2);

                // Calculate and print the distance
                double distance = Point.DistanceTo(p1,p2);
                Console.WriteLine($"Distance between the two points: {distance:F2}");
            }
            #endregion
            #region 3 Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
            {
                Person[] people = new Person[3];

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Enter name of person {i + 1}: ");
                    string name = Console.ReadLine();

                    Console.Write($"Enter age of person {i + 1}: ");
                    int.TryParse(Console.ReadLine(), out int age);

                    people[i] = new Person(name, age);
                }

                // Find oldest
                Person oldest = people[0];
                for (int i = 1; i < people.Length; i++)
                {
                    if (people[i].Age > oldest.Age)
                    {
                        oldest = people[i];
                    }
                }

                Console.WriteLine($"\nThe oldest person is {oldest.Name}, Age: {oldest.Age}");
            }
            #endregion
            #region 4 
            {
                Rectangle rect = new Rectangle();

                Console.Write("Enter width: ");
                double.TryParse(Console.ReadLine(), out double w);
                rect.Width = w;

                Console.Write("Enter height: ");
                double.TryParse(Console.ReadLine(), out double h);
                rect.Height = h;

                rect.DisplayInfo();
            }
            #endregion
        }
    }
}
