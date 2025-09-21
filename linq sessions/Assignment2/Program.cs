using Assignment2.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static Assignment2.ListGenerator;
namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region aggregate operators
            {
                //Get the total units in stock for each product category.
                dynamic res = ProductsList.GroupBy(p => p.Category).Select(g => new {g.Key, numunits = g.Sum(p=>p.UnitsInStock)}).ToList();
                // Get the cheapest price among each category's products
                res = ProductsList.GroupBy(p => p.Category).Select(g => new {g.Key, minprice = g.Min(p=>p.UnitPrice)}).ToList();
                // Get the products with the cheapest price in each category (Use Let)
                res = from p in ProductsList
                      group p by p.Category into g
                      let minprice = g.Min(x => x.UnitPrice)
                      from prod in g
                      where prod.UnitPrice == minprice
                      select new
                      {
                          g.Key,
                          prod.ProductName,
                          prod.UnitPrice
                      };
                // Get the most expensive price among each category's products.
                res = from p in ProductsList
                      group p by p.Category into g
                      select new
                      {
                          g.Key,
                          maxprice = g.Max(x => x.UnitPrice)
                      };
                //Get the products with the most expensive price in each category.
                res = from p in ProductsList
                      group p by p.Category into g
                      let maxprice = g.Max(p => p.UnitPrice)
                      from prod in g
                      where prod.UnitPrice == maxprice
                      select new
                      {
                          g.Key,
                          prod.ProductName,
                          prod.UnitPrice
                      };
                //Get the average price of each category's products.
                res = ProductsList.GroupBy(p => p.Category).Select(g => new { g.Key, groupavg = g.Average(p => p.UnitPrice)}).ToList();
                //foreach (var item in res)
                //    Console.WriteLine(item);
            }
            #endregion
            #region set operators
            {
                // Find the unique Category names from Product List
                dynamic res = ProductsList.Select(p=>p.Category).Distinct().ToList();
                //Produce a Sequence containing the unique first letter from both product and customer names.
                res = ProductsList.Select(p => p.ProductName[0]).Union(CustomersList.Select(c => c.CustomerName[0]));
                //Create one sequence that contains the common first letter from both product and customer names.
                res = ProductsList.Select(p => p.ProductName[0]).Intersect(CustomersList.Select(c => c.CustomerName[0]));
                //Create one sequence that contains the first letters of product names that are not also first letters of customer names.
                res = ProductsList.Select(p => p.ProductName[0]).Except(CustomersList.Select(c => c.CustomerName[0]));
                // Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
                res = ProductsList.Select(p => p.ProductName.Substring(p.ProductName.Length - 3)).Concat(CustomersList.Select(c => c.CustomerName.Substring(c.CustomerName.Length - 3)));

                //foreach (var item in res)
                //    Console.WriteLine(item);
            }
            #endregion
            #region partitioning operators
            {
                // Get the first 3 orders from customers in Washington
                dynamic res = CustomersList.Where(c => c.Address.ToLower() == "washington").Take(3);
                //  Get all but the first 2 orders from customers in Washington.
                res = CustomersList.Where(c => c.Address.ToLower() == "washington").Skip(2);
                // Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                res = numbers.TakeWhile((x, i) => x > i);
                //Get the elements of the array starting from the first element divisible by 3.
                res = numbers.SkipWhile(x => x % 3 != 0);
                //Get the elements of the array starting from the first element less than its position.
                res = numbers.SkipWhile((x, i) => x > i);
            //    foreach (var item in res)
            //    Console.WriteLine(item);
            }
            #endregion
            #region quantifiers
            {
                //Determine if any of the words in dictionary_english.txt contain the substring 'ei'.
                string[] words = System.IO.File.ReadAllLines("dictionary_english.txt");
                dynamic res = words.Where(w => w.Contains("ei")).Any();
                //Console.WriteLine(res);
                //  Return a grouped a list of products only for categories that have at least one product that is out of stock.
                res = ProductsList.GroupBy(p=>p.Category).Where(g=>g.Any(p=>p.UnitsInStock==0));
                // Return a grouped a list of products only for categories that have all of their products in stock.
                res = ProductsList.GroupBy(p=>p.Category).Where(g=>g.All(p=>p.UnitsInStock!=0));
                //foreach (var item in res)
                //    Console.WriteLine(item);

            }
            #endregion
            #region grouping operators
            {
                //Use group by to partition a list of numbers by their remainder when divided by 5
                List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                var res = numbers.GroupBy(x => x % 5);
                //Uses group by to partition a list of words by their first letter.
                string[] words = System.IO.File.ReadAllLines("dictionary_english.txt");
                var ans = words.GroupBy(w => w[0]);
                //foreach(var x in ans)
                //    Console.WriteLine(x.Key);
                // Use Group By with a custom comparer that matches words that are consists of the same Characters Together

            }
            #endregion
        }
    }
}
