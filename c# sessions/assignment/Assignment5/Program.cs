using System;
using System.Reflection.Metadata.Ecma335;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1,2 Explain the difference between passing by value and by reference then write a suitable c# example.
            {/*
            * passing by value : the variable gets copied inside the function it is passed to
            * passing by refrence : the variable's location in the memory is directly accessed inside the function
            */
                static int passing_by_refrence(ref int x, int y)
                {
                    x = y;
                    return x;
                }
                static int passing_by_value(int x, int y)
                {
                    x = y;
                    return x;
                }
                int x = 10, y = 20;
                Console.WriteLine(passing_by_value(x, y));
                Console.WriteLine(passing_by_refrence(ref x, y));
            }
            #endregion

            #region 3 Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers
            {
                static void sum_diff(int a, int b, int c, int d, out int sum, out int diff)
                {
                    sum = a + b;
                    diff = c - d;
                }
                int.TryParse(Console.ReadLine(), out int a);
                int.TryParse(Console.ReadLine(), out int b);
                int.TryParse(Console.ReadLine(), out int c);
                int.TryParse(Console.ReadLine(), out int d);
                int sum, diff;
                sum_diff(a, b, c, d,out sum, out diff);
            }
            #endregion
            #region 4 Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.
            {
                Console.WriteLine("enter a number: ");
                int.TryParse(Console.ReadLine(), out int num);
                int sum = 0;
                int numcop = num;
                while (numcop > 0) {
                    sum += numcop % 10;
                    numcop /= 10;
                }
                Console.WriteLine($"the sum of the digigts of the number {num} is: {sum}");
            }
            #endregion
            #region 5 Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not
            {
                static bool is_prime(int num)
                {
                    for(int i = 1; i < num / 2; i++)
                    {
                        if (num % i == 0)
                            return false;
                    }
                    return true;
                }
                Console.WriteLine("enter a number: ");
                int.TryParse(Console.ReadLine(), out int num);
                bool isp = is_prime(num);
                Console.WriteLine($"the number entered is {(isp?"prime":"not prime")}");
            }
            #endregion
            #region 6 Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters
            {
                static void minmaxarr(int[] arr,ref int min,ref int max)
                {
                    min = arr[0];
                    max = arr[0];
                    for (int i = 0; i < arr.Length; i++) {
                        if (min > arr[i]) 
                            min = arr[i];
                        if (max < arr[i])
                            max = arr[i];
                    }
                }
            }
            #endregion
            #region 7 Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter
            {
                static int factorial(int num)
                {
                    int fac = 1;
                    int counter = 1;
                    while (counter <= num)
                    {
                        fac *= counter++;
                    }
                    return fac;
                }
                Console.WriteLine("enter a number: ");
                int.TryParse(Console.ReadLine(), out int num);
                int fac = factorial(num);
                Console.WriteLine($"the factorial of {num} is: {fac}");
            }
            #endregion
            #region 8 Create a function named "ChangeChar" to modify a letter in a certain position (0 based) of a string, replacing it with a different letter
            {
                static string changechar(string tobechangedin,int position,char tochangewith)
                {
                    char[] chars = tobechangedin.ToCharArray();
                    chars[position] = tochangewith;
                    return new string(chars);
                }
            }
            #endregion

        }
    }
}