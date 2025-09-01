namespace Assignment3
{
    internal class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>
        {
            new Book("123", "C# in Depth", new string[] {"Jon Skeet"}, new DateTime(2019, 3, 23), 49.99m),
            new Book("456", "CLR via C#", new string[] {"Jeffrey Richter"}, new DateTime(2012, 2, 14), 59.99m)
        };

            // a. User Defined Delegate
            BookDelegate d1 = new BookDelegate(BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks(books, d1);

            // b. BCL Delegates (Func)
            Func<Book, object> d2 = BookFunctions.GetAuthours;
            LibraryEngine.ProcessBooks(books, new BookDelegate(d2));

            // c. Anonymous Method
            BookDelegate d3 = delegate (Book b) { return b.ISBN; };
            LibraryEngine.ProcessBooks(books, d3);

            // d. Lambda Expression
            BookDelegate d4 = (b) => b.PublicationDate.ToShortDateString();
            LibraryEngine.ProcessBooks(books, d4);
        }
    }
}
