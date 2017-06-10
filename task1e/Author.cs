using System;
using System.Collections.Generic;

namespace task1e
{
    public class Author : IComparable, ICountingBooks
    {
        private string name { get; set; }
        private List<Book> books { get; set; }

        public Author()
        {
        }

        public Author(string n, List<Book> b)
        {
            name = n;
            books = b;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Author otherAuthor = obj as Author;
            if (otherAuthor != null)
                return this.books.Count.CompareTo(otherAuthor.books.Count);
            else
                throw new ArgumentException("Object is not a Author");
        }

        public int getNumberBooks()
        {
            return books.Count;
        }

        public override string ToString()
        {
            return name + ", number books: " + books.Count;
        }

    }
}
