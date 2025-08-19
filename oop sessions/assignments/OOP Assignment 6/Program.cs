namespace OOP_Assignment_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region project 1
            Console.WriteLine("enter 3 coordinates for the first point:");
            _3DPoint p1 = _3DPoint.ReadPoint();
            Console.WriteLine("enter 3 coordinates for the second point:");
            _3DPoint p2 = _3DPoint.ReadPoint();

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine($"are the two points equale: {p1==p2}"); // this will not work till the == operator is overloaded
            _3DPoint[] points = new _3DPoint[]
            {
                new _3DPoint(0, 0, 0),
                new _3DPoint(2, 1, 0),
                new _3DPoint(3, 0, 1),
                new _3DPoint(0, 0, 1)
            };
            foreach (var p in points) Console.WriteLine(p);
            Array.Sort(points);
            foreach (var p in points) Console.WriteLine(p);

            _3DPoint p3 = p1;
            p1.X = 22;
            Console.WriteLine(p1);
            Console.WriteLine(p3);

            _3DPoint p4 = (_3DPoint)p2.Clone();
            p2.X = 55;
            Console.WriteLine(p2);
            Console.WriteLine(p4);
            #endregion
            #region project 2
            Console.WriteLine("Addition: " + Maths.Add(10, 5));
            Console.WriteLine("Subtraction: " + Maths.Subtract(10, 5));
            Console.WriteLine("Multiplication: " + Maths.Multiply(10, 5));
            Console.WriteLine("Division: " + Maths.Divide(10, 5));
            #endregion
            #region project 3
            Console.WriteLine("Enter your user type (Regular, Premium, Guest):");
            string userType = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            User user;
            switch (userType)
            {
                case "regular":
                    user = new RegularUser(name);
                    break;
                case "premium":
                    user = new PremiumUser(name);
                    break;
                case "guest":
                    user = new GuestUser(name);
                    break;
                default:
                    Console.WriteLine("Invalid user type, defaulting to Guest.");
                    user = new GuestUser(name);
                    break;
            }

            Console.WriteLine("Enter product price:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Discount discount = user.GetDiscount();
            decimal discountAmount = discount.CalculateDiscount(price, quantity);
            decimal finalPrice = (price * quantity) - discountAmount;

            Console.WriteLine($"Hello {user.Name}, you are a {userType} user.");
            Console.WriteLine($"Discount Applied: {discount.Name}");
            Console.WriteLine($"Discount Amount : {discountAmount:C}");
            Console.WriteLine($"Final Price     : {finalPrice:C}");
            #endregion
        }
    }
}
