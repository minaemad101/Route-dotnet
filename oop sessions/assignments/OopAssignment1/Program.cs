using System;

namespace OopAssignment1
{
    #region 1 Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members.
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,

    }
    #endregion
    #region 2 Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members.
    enum Seasons
    {
        Spring,
        Summer,
        Autumn,
        Winter,
    }
    #endregion
    #region 3 Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum
    [Flags]
    enum permissions : byte
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }
    #endregion
    #region 4 Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members.
    enum Colors
    {
        Red, Green, Blue
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1 Then, write a C# program that prints out all the days of the week using this Enum.
            {
                Console.WriteLine("Days of the Week:");
                foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
                {
                    Console.WriteLine(day);
                }
            }
            #endregion
            #region 2 Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)
            {
                Console.Write("Enter a season name (Spring, Summer, Autumn, Winter): ");
                string input = Console.ReadLine();
                bool isparse = Enum.TryParse<Seasons>(input, out Seasons seasonsobj);

                if (isparse)
                {
                    switch (seasonsobj)
                    {
                        case Seasons.Spring:
                            Console.WriteLine("Spring: March to May");
                            break;
                        case Seasons.Summer:
                            Console.WriteLine("Summer: June to August");
                            break;
                        case Seasons.Autumn:
                            Console.WriteLine("Autumn: September to November");
                            break;
                        case Seasons.Winter:
                            Console.WriteLine("Winter: December to February");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid season name. Please enter one of: Spring, Summer, Autumn, Winter.");
                }

            }
            #endregion
            #region 3 Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable
            {
                permissions userPerms = permissions.None;
                Console.WriteLine("Enter permissions one by one (Read, Write, Delete, Execute).");
                Console.WriteLine("Enter an invalid permission to stop:");
                while (true)
                {
                    Console.Write("Enter permission to add or remove: ");
                    bool isParsed = Enum.TryParse<permissions>(Console.ReadLine(), true, out permissions enteredPerm);

                    if (!isParsed || !Enum.IsDefined(typeof(permissions), enteredPerm))
                    {
                        Console.WriteLine("Invalid permission. Stopping input...");
                        break;
                    }

                    userPerms ^= enteredPerm; // Add permission using bitwise OR
                }

                Console.WriteLine($"\nFinal permissions set: {userPerms}");
         
            }
            #endregion
            #region 4 Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.
            { 
                Console.WriteLine("enter color: ");
                bool isparse = Enum.TryParse<Colors>(Console.ReadLine(), out Colors enteredcolor);
                if (!isparse)
                {
                    Console.WriteLine("you didnt enter a valid color");
                }
            }
            #endregion

        }
    }
}