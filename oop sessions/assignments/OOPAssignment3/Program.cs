using System.Globalization;

namespace OOPAssignment3
{
    #region 2 .Develop a Class to represent the Hiring Date Data: Consisting of fields to hold the day, month and Years.
    internal class MyDate
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get => day;
            set
            {
                if (value >= 1 && value <= 31) day = value;
                else Console.WriteLine("Invalid Day");
            }
        }

        public int Month
        {
            get => month;
            set
            {
                if (value >= 1 && value <= 12) month = value;
                else Console.WriteLine("Invalid Month");
            }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value <= DateTime.Now.Year) year = value;
                else Console.WriteLine("Invalid Year");
            }
        }
        public MyDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public static bool operator <(MyDate d1, MyDate d2)
        {
            if (d1.year != d2.year)
                return d1.year < d2.year;
            else if (d1.month != d2.month)
                return d1.month < d2.month;
            else
                return d1.day < d2.day;
        }

        public static bool operator >(MyDate d1, MyDate d2)
        {
            if (d1.year != d2.year)
                return d1.year > d2.year;
            else if (d1.month != d2.month)
                return d1.month > d2.month;
            else
                return d1.day > d2.day;
        }
        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }
    #endregion

    #region 1,3 Design and implement a Class for the employees in a company
    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA
    }

    internal class Employee
    {
        public int Id { get; set; }
        public string Name {  get; set; }

        private char gender;
        public char Gender
        {
            get { return gender; }
            set
            {
                if(value == 'M'||value=='F')
                    gender = value;
                else
                {
                    gender = 'M';
                    Console.WriteLine("gender not set correctly");
                }
            }
        }
        public SecurityLevel Security {  get; set; }
        public decimal Salary { get; set; }
        public MyDate HireDate { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}\n" +
                $"Name: {Name}\n" +
                $"Gender: {(Gender == 'M' ? "Male" : "Female")}\n" +
                $"Security Level: {Security}\n" +
                $"Salary: {string.Format(CultureInfo.CurrentCulture, "{0:C}", Salary)}\n" +
                $"Hire Date: {HireDate}";
        }
        public Employee(int id, string name, char gender, SecurityLevel security, decimal salary, MyDate hireDate)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Security = security;
            Salary = salary;
            HireDate = hireDate;
        }
        public static Employee[] SortEmployeesByHireDate(Employee[] employees)
        {
            int n = employees.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (employees[j].HireDate > employees[j + 1].HireDate)
                    {
                        Employee temp = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = temp;
                    }
                }
            }

            return employees;
        }
    }
    #endregion
    #region 5
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public virtual string GetInfo()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}";
        }
    }

    // Derived class for EBook
    class EBook : Book
    {
        public double FileSize { get; set; } // in MB

        public EBook(string title, string author, string isbn, double fileSize)
            : base(title, author, isbn)
        {
            FileSize = fileSize;
        }
        // here the constructor of the derived class just calls the constructor of the base class without extra hussle in the code ... and also the getinfo function uses the base function and adds the parts specific to the ebook class

        public override string GetInfo()
        {
            return base.GetInfo() + $", File Size: {FileSize} MB";
        }
    }

    // Derived class for PrintedBook
    class PrintedBook : Book
    {
        public int PageCount { get; set; }

        public PrintedBook(string title, string author, string isbn, int pageCount)
            : base(title, author, isbn)
        {
            PageCount = pageCount;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Pages: {PageCount}";
        }
    }
    #endregion
    internal class Program
    {

        static void Main(string[] args)
        {
            // Create array of 3 employees
            Employee[] EmpArr = new Employee[3];

            EmpArr[0] = new Employee(
                id: 1,
                name: "dba_emp",
                gender: 'M',
                security: SecurityLevel.DBA,
                salary: 10000,
                hireDate: new MyDate(1, 1, 2020)
            );

            EmpArr[1] = new Employee(
                id: 2,
                name: "guest_emp",
                gender: 'F',
                security: SecurityLevel.Guest,
                salary: 3000,
                hireDate: new MyDate(5, 5, 2022)
            );

            EmpArr[2] = new Employee(
                id: 3,
                name: "security_emp",
                gender: 'M',
                security: SecurityLevel.Secretary, // Assuming full permissions
                salary: 8000,
                hireDate: new MyDate(10, 10, 2019)
            );

            // Print all employees
            foreach (var emp in EmpArr)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(emp);
            }

            #region 4 
            Employee[] sorted = Employee.SortEmployeesByHireDate(EmpArr);
            Console.WriteLine("-------------");
            Console.WriteLine("the sorted employees");
            foreach (var emp in sorted)
            {
                Console.WriteLine("-------------");
                Console.WriteLine(emp);
            }
            #endregion
        }
    }
}
