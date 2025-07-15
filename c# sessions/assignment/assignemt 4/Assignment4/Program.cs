using System.Runtime.InteropServices;

// struct point for question 10
struct point
{
    public int x;
    public int y;
    public point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

namespace assignment4
{
    class program
    {
        static void Main(string[] args)
        {
            #region Write a program that allows the user to insert an integer then print all numbers between 1 to that number.
            {
                Console.WriteLine("question 1");
                int.TryParse(Console.ReadLine(), out var result);
                for (int i = 1; i < result; i++)
                {
                    Console.Write($"{i} ");
                }
            }
            #endregion

            #region Write a program that allows the user to insert an integer then print a multiplication table up to 12.
            {
                Console.WriteLine("question 2");
                int.TryParse(Console.ReadLine(), out var result);
                for (int i = 0; i <= 12; i++)
                {
                    Console.WriteLine($"{result} * {i} = {result * i}");
                }
            }
            #endregion

            #region Write a program that allows to user to insert number then print all even numbers between 1 to this number
            {
                Console.WriteLine("question 3");
                int.TryParse(Console.ReadLine(), out var result1);
                for (int i = 1; i < result1; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine(i);
                }
            }
            #endregion

            #region Write a program that takes two integers then prints the power
            {
                Console.WriteLine("question 4");
                int.TryParse(Console.ReadLine(), out var number1);
                int.TryParse(Console.ReadLine(), out var number2);
                Console.WriteLine(Math.Pow(number1, number2));
            }
            #endregion

            #region  Write a program to enter marks of five subjects and calculate total, average and percentage.
            {
                Console.WriteLine("question 5");
                int total = 0;
                int avg = 0;
                float percentage = 0f;
                for (int i = 0; i < 5; i++)
                {
                    int.TryParse(Console.ReadLine(), out int daraga);
                    total += daraga;
                }
                avg = total / 5;
                percentage = (total*100 / 50);
                Console.WriteLine($"{total} {avg} {percentage}%");
            }
            #endregion

            #region Write a program to allow the user to enter a string and print the REVERSE of it.
            {
                Console.WriteLine("question 6");
                string input = Console.ReadLine();

                if (input != null)
                {
                    string reversed = new string(input.Reverse().ToArray());
                    Console.WriteLine("Reversed string: " + reversed);
                }
            }
            #endregion

            #region  Write a program to allow the user to enter int and print the REVERSED of it.
            {
                Console.WriteLine("question 7");
                int.TryParse(Console.ReadLine(), out int number);
                int output = 0;
                while (number > 0)
                {
                    output += number % 10;
                    number /= 10;
                    output *= 10;
                }
                Console.WriteLine(output / 10);
            }
            #endregion

            #region Write a program in C# Sharp to find prime numbers within a range of numbers.
            static bool IsPrime(int num)
            {
                if (num < 2)
                    return false;

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                        return false;
                }

                return true;
            }

            {
                Console.WriteLine("question 8");
                Console.Write("Enter the start of the range: ");
                int start = int.Parse(Console.ReadLine());

                Console.Write("Enter the end of the range: ");
                int end = int.Parse(Console.ReadLine());

                Console.WriteLine($"Prime numbers between {start} and {end} are:");

                for (int number = start; number <= end; number++)
                {
                    if (IsPrime(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
            #endregion

            #region  Write a program in C# Sharp to convert a decimal number into binary without using an array.
            {
                Console.WriteLine("question 9");
                Console.Write("Enter a decimal number: ");
                int number;
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    int result = 0;
                    int count = 0;

                    while (number > 0)
                    {
                        int remainder = number % 2;
                        result += remainder * (int)Math.Pow(10, count);
                        count++;
                        number /= 2;
                    }

                    Console.WriteLine("Binary representation: " + result);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
            #endregion

            #region Create a program that asks the user to input three points (x1, y1), (x2, y2), and (x3, y3), and determines whether these points lie on a single straight line
            static bool is_strait_line(point p1, point p2, point p3)
            {
                if ((p1.x == p2.x && p1.x == p3.x) || (p1.y == p2.y && p1.y == p3.y))
                {
                    return true;
                }
                return false;
            }
            {
                Console.WriteLine("question 10");
                int.TryParse(Console.ReadLine(), out int x);
                int.TryParse(Console.ReadLine(), out int y);
                point p1 = new point(x, y);
                int.TryParse(Console.ReadLine(), out x);
                int.TryParse(Console.ReadLine(), out y);
                point p2 = new point(x, y);
                int.TryParse(Console.ReadLine(), out x);
                int.TryParse(Console.ReadLine(), out y);
                point p3 = new point(x, y);
                Console.WriteLine(is_strait_line(p1, p2, p3));
            }
            #endregion

            #region Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.
            {
                Console.WriteLine("question 11");
                int.TryParse (Console.ReadLine(), out int n);
                int count = 0;
                for (int i = 0; i < n; i++) {
                    for(int j=0; j<n; j++)
                    {
                        if(i == j && i == count)
                        {
                            Console.Write('1');
                            count++;
                        }
                        Console.Write('0');
                    }
                    Console.WriteLine();
                }
            }
            #endregion

        }
    }
}