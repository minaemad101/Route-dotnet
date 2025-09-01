using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public delegate object BookDelegate(Book b);

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, Date: {PublicationDate.ToShortDateString()}, Price: {Price}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string[] GetAuthours(Book B) 
        {
            return B.Authors;
        }
        public decimal GetPrice(Book B)
        {
            return B.Price;
        }

    }
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, BookDelegate fptr)
        {
            foreach (Book b in bList)
            {
                Console.WriteLine(fptr(b));
            }
        }
    }


}
