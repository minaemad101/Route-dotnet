using System.Reflection.Metadata;

namespace Assignment_Session03
{
    internal class Program
    {
        static void Main(string[] args)
        {
			#region Q1 - Write a program that allows the user to enter a number then print it.
				string input = Console.ReadLine();
				Console.WriteLine(input);
			#endregion

			#region Q2 - Write C# program that converts a string to an integer, but the string contains non-numeric characters. And mention what will happen
			string test = "abc";
			int.TryParse(test, out int res);
            // with tryparse the result is saved in the res and since the input is not numerical 0 is in res
            #endregion


            #region Q3 - Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen
            float a = 1.1f;
            float b = 2.2f;
            float sum = a + b;
            Console.WriteLine(sum);
            // it may not have an exact result it was 3.300000000019
            #endregion

            #region Q4 - Write C# program that Extract a substring from a given string.
            string fullStr = "abcdefghijklmnopqrstuvwxyz";
            string subStr = fullStr.Substring(1, 2);

            #endregion

            #region Q5 - Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
            int x = 10;
            int y = x;
            y = 20;
            // here only y will change and x stays as it is

            #endregion

            #region Q6 - Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
            int[] arr1 = { 1 };
            int[] arr2 = { 2 };
            arr2[0] = 3;
            Console.WriteLine(arr1);
            Console.WriteLine(arr2);
            // here both arr1 and arr2 have the value 3  in the first location

            #endregion

            #region Q7 - Write C# program that take two string variables and print them as one variable 
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            Console.WriteLine(str1+str2);
            Console.WriteLine($"{str1}{str2}");
            Console.WriteLine(string.Concat(str1, str2));
            Console.WriteLine(string.Format("{0}{1}", str1, str2));
            #endregion

            #region Q8 - Write a program that calculates the simple interest given the principal amount, rate of interest, and time
            // Note :  The formula for simple interest is Interest = (principal * rate * time ) /100.
                Console.Write("Enter Principal Amount: ");
                double principal = double.Parse(Console.ReadLine());

                Console.Write("Enter Rate of Interest (%): ");
                double rate = double.Parse(Console.ReadLine());

                Console.Write("Enter Time (in years): ");
                double time = double.Parse(Console.ReadLine());

                // Simple Interest formula
                double interest = (principal * rate * time) / 100;

                Console.WriteLine($"Simple Interest = {interest}");
            #endregion

            #region Q9 - Write a program that calculates the Body Mass Index (BMI) given a person's weight in kilograms and height in meters. 
            // Note: The formula for BMI is BMI = (Weight) / (Height * Height)
                Console.Write("Enter Weight: ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("Enter height: ");
                double height = double.Parse(Console.ReadLine());

                double BMI = (weight) / (height*height);

                Console.WriteLine($"Body Mass Index = {BMI}");


            #endregion

            #region Q10 - Write a program that uses the ternary operator to check if the temperature is too hot, too cold, or just good. Assign the result in a variable then display the result.
            ///that below 10 degrees is "Just Cold"
            ///above 30 degrees is "Just Hot"
            ///anything else is "Just Good"
            Console.Write("Enter temprature: ");
            double temp = double.Parse(Console.ReadLine());
            string tempres = temp < 10 ? "just cold" : temp > 30 ? "just hot" : "just good";
            Console.WriteLine(tempres);
            #endregion

            #region Q11  Write a program that takes the date from the user and displays it in various formats using string interpolation.
            ///Ex:
            ///Today’s date : 20 , 11 , 2001
            ///Today's date : 20 / 11 / 2001
            ///Today's date : 20 – 11 – 2001
            Console.Write("Enter day: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            // 🎯 Display using string interpolation
            Console.WriteLine($"Today's date : {day} , {month} , {year}");
            Console.WriteLine($"Today's date : {day} / {month} / {year}");
            Console.WriteLine($"Today's date : {day} – {month} – {year}");

            #endregion

            #region Q12 - Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.
            ///Example(1)
            ///Input: 12
            ///Output: Yes
            ///Example(2)
            ///Input: 9
            ///Output: No
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            string divres = num % 3 == 0 || num % 4 == 0 ? "yes" : "no";
            Console.WriteLine(divres);

            #endregion

            #region Q13 - Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.
            ///Example(1)
            ///Input: -5
            ///Output: negative
            ///Example(2)
            ///Input: 10
            ///Output: positive
            Console.Write("Enter number: ");
            int num13 = int.Parse(Console.ReadLine());
            string isneg = num >= 0 ? "positive" : "negative";
            Console.WriteLine(isneg);


            #endregion

            #region Q14 - Write a program that takes 3 integers from the user then prints the max element and the min element.
            ///Example(1)
            ///Input: 7,8,5
            ///Output:
            ///max element = 8
            ///min element = 5
            ///Example(2)
            ///Input: 3 6 9
            ///Outputs:
            ///Max element = 9
            ///Min element = 3
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            int num3 = int.Parse(Console.ReadLine());

            int max = Math.Max(num1, Math.Max(num2, num3));
            int min = Math.Min(num1, Math.Min(num2, num3));

            Console.WriteLine($"Maximum number is: {max}");
            Console.WriteLine($"Minimum number is: {min}");



            #endregion

            #region Q15 - Write a program that allows the user to insert an integer number then check If a number is even or odd.
            Console.Write("Enter number: ");
            int num15 = int.Parse(Console.ReadLine());
            string isev = num % 2 == 0 ? "even" : "odd";
            Console.WriteLine(divres);

            #endregion

            #region Q16 - Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
            ///Example(1)
            ///Input: O
            ///Output: vowel
            ///Example(2)
            ///Input: b
            ///Output: Consonant
            ///Console.Write("Enter a single character: ");
            char ch = char.ToLower(Console.ReadKey().KeyChar);
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                Console.WriteLine("Vowel");
            }
            else
            {
                Console.WriteLine("Consonant");
            }

            #endregion

            #region Q17 - Write a program to input the month number and print the number of days in that month.
            /// Example
            /// Input: Month Number: 1
            /// Output: Days in Month: 31
            Dictionary<int, int> monthDays = new Dictionary<int, int>()
            {
                { 1, 31},
                { 2, 28},
                { 3, 31},
                { 4, 30},
                { 5, 31},
                { 6, 30},
                { 7, 31},
                { 8, 31},
                { 9, 30},
                { 10, 31},
                { 11, 30},
                { 12, 31}
            };
            Console.Write("Enter month number (1-12): ");
            Console.WriteLine($"Number of days in month {month} is: {monthDays[month]}");



            #endregion

        }
    }
}
