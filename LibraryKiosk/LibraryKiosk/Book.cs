using System;
using System.Xml.Linq;

namespace LibraryKiosk

{
    /// <summary>
    /// class stores data from books.csv and print method
    /// class inherits IComparable 
    /// </summary>
    public class Book: IComparable<Book>

    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        /// <summary>
        /// method to print books in books.csv
        /// </summary>
        public void Print()
        {
            Console.WriteLine();
        }

        public int CompareTo(Book? other)
        {
            throw new NotImplementedException();

        }
    }

}

