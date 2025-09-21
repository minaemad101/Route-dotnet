using Assignment1;
using Assignment1.Data;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using static Assignment1.ListGenerator;
namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region restriction operators
            {// find all products that are out of stock
                List<Product> prods = ProductsList.Where(prod => prod.UnitsInStock == 0).Select(prod => prod).ToList();
                // Find all products that are in stock and cost more than 3.00 per unit.
                prods = ProductsList.Where(prod => (prod.UnitsInStock != 0 && prod.UnitPrice >= 3.0m)).Select(prod => prod).ToList();
                //  Returns digits whose name is shorter than their value.
                String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                var res = Arr.Select((name, index) => new { Digit = index, Name = name }).Where(x => x.Digit > x.Name.Length).Select(x => x.Name).ToList();
            }
            #endregion
            #region element operators
            {
                // get first product out of stock
                Product prody = ProductsList.FirstOrDefault(x => x.UnitsInStock == 0);
                // Return the first product whose Price > 1000
                prody = ProductsList.FirstOrDefault(x => x.UnitPrice > 1000);
                // Retrieve the second number greater than 5 
                int[] intArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var intres = intArr.Where(x => x > 5).Skip(1).FirstOrDefault();
            }
            #endregion
            #region Aggregate operatos
            {
                // Uses Count to get the number of odd numbers in the array
                int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
                var res = Arr.Where(x => x % 2 == 1).Count();
                // Return a list of customers and how many orders each has.
                var cs = CustomersList.Select(c => new
                {
                    c.CustomerID,
                    customercount = c.Orders.Count()
                });
                // Return a list of categories and how many products each has
                var cats = ProductsList.GroupBy(p => p.Category).Select(c => new { c.Key, prodcount = c.Count() });
                // Get the total of the numbers in an array.
                int[] sArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                var reres = sArr.Sum();
                // Get the total number of characters of all words in dictionary_english.txt
                string[] words = System.IO.File.ReadAllLines("dictionary_english.txt");
                dynamic chars = words.Sum(w=>w.Length);
                //Get the length of the shortest word in dictionary_english.txt
                chars = words.Min(w => w.Length);
                // Get the length of the longest word in dictionary_english.txt
                chars = words.Max(w => w.Length);
                // Get the average length of the words in dictionary_english.txt
                chars = words.Average(w => w.Length);
                //Console.WriteLine(chars);
                //foreach (var c in cats)
                //    Console.WriteLine(c);
            }
            #endregion
            #region ordering operators
            {
                //Sort a list of products by name
                var prods = ProductsList.OrderBy(p=>p.ProductName).ToList();
                //Uses a custom comparer to do a case-insensitive sort of the words in an array.
                String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                dynamic res = Arr.OrderBy(w=>w.ToLower()).ToList();
                // Sort a list of products by units in stock from highest to lowest.
                prods = ProductsList.OrderByDescending(p=>p.UnitsInStock).ToList();
                string[] strArr = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
                res = strArr.OrderBy(w=>w.Length).ThenBy(w=>w).ToList();
                // string [] Arr = {“zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine”};
                res = Arr.OrderBy(w => w.Length).ThenBy(w => w.ToLower()).ToList();
                // Sort a list of products, first by category, and then by unit price, from highest to lowest.
                res = ProductsList.OrderBy(p=>p.Category).ThenByDescending(p=>p.UnitPrice).ToList();
                // Sort first by-word length and then by a case-insensitive descending sort of the words in an array
                res = Arr.OrderBy(w => w.Length).ThenByDescending(w => w.ToLower()).ToList();
                // Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
                res = strArr.Where(w => w[1] == 'i').Reverse().ToList();
                //foreach (var p in res)
                    //Console.WriteLine(p);
            }
            #endregion
            #region transformation operators
            {
                //Return a sequence of just the names of a list of products.
                dynamic seq = ProductsList.Select(p => p.ProductName).ToList();
                // Produce a sequence of the uppercase and lowercase versions of each word in the original array
                String[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
                seq = words.Select(w => new {upper = w.ToUpper(),lower = w.ToLower()}).ToList();
                // Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
                seq = ProductsList.Select(p => new {p.ProductName,Price = p.UnitPrice}).ToList();
                // Determine if the value of int in an array matches their position in the array.
                int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                seq = Arr.Select((x, i) => (x == i) );
                //Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB
                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };
                seq = numbersA.SelectMany(a => numbersB, (a, b) => new {a, b}).Where(p=>p.a<p.b);
                //Select all orders where the order total is less than 500.00.
                seq = CustomersList.SelectMany(c => c.Orders).Where(o => o.Total < 500m).ToList();
                // select all orders where the order was made in 1998 or later
                seq = CustomersList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998).ToList();
                foreach (var p in seq) Console.WriteLine(p);
            }
            #endregion

        }
    }
}