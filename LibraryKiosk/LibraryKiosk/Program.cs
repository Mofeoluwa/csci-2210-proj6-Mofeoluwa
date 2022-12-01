////////////////////////////////////////////////////////////////////////
// Name:Mofeoluwa Jide-Jegede
// Course: CSCI 2210-001 - Data Structures
// Assignment: Project 6
// Description: Library Kiosk
// Created: November 21, 2022
// Pulled From Nuget Package
// @ https://nuget.info/packages/adjunct-System.DataStructures.AvlTree/2.0.0
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryKiosk;

/// <summary>
/// Driver codes
/// </summary>

class Program
{
    /// <summary>
    /// main method to read books.csv and parse the data
    /// </summary>
    /// <param name="args"></param>

    public static void Main(string[] args)
    {
        string path = @"/Users/mofeoluwajide-jegede/Downloads/books.csv";


       // streamreader to read the books.csv file from given path
        using (StreamReader sr = new StreamReader(path))
        {
            // AVL tree to store books
            AvlTree <Book> tree = new AvlTree<Book>();
            int i = 1;
            string line;

            //list containing lines from the books.csv file
            List<string> lines;

            //function to store the each book data into the different properties
            while ((line = sr.ReadLine()) != null)
            {
                lines = ReadCSV(line);
                Book book = new Book();
                book.Title = lines[0];
                book.Author = lines[1];
                book.Pages = Int32.Parse(lines[2]);
                book.Publisher = lines[3];
                i++;
                book.Print();
                
                //Add book to AVL tree
                tree.Add(book);

          
            }

            // Function to search for book using the title
            string TitleforSearch = "";

            List<Book> listofbooks = tree.GetInorderEnumerator().ToList();
            foreach (Book book in listofbooks)
            {
                if (book.Title==TitleforSearch)
                {
                    tree.Remove(book);
                }
               
            }
            // Function to print book
            foreach (Book book in tree)
            {
                book.Print();
            }
            };

       

        //Function to parse book data into different parts
        List<string> ReadCSV(string linesinCSV)
        {
            string[] BookParts = linesinCSV.Split(",");
            List<string> cleanBookParts = new List<string>();
            string cleanString = string.Empty;
            for (int i = 0; i < BookParts.Length; i++)
            {
                cleanString += BookParts[i];
                if (cleanString.StartsWith("\"") && !cleanString.EndsWith("\""))
                {
                    continue;
                }
                cleanBookParts.Add(cleanString.Replace("\"", String.Empty));
                cleanString = String.Empty;
            }
            return cleanBookParts;
        }

    } 
}

