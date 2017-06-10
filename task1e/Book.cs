using System;

namespace task1e
{
    public class Book : IComparable
    {
        private string authorName;
        private string name;
        private int numberPage;

        public Book()
        {
        }

        public Book(string an, string bn, int np)
        {
            authorName = an;
            name = bn;
            numberPage = np;
        }

        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberPage
        {
            get { return numberPage; }
            set { numberPage = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Book otherBook = obj as Book;
            if (otherBook != null)
                return this.numberPage.CompareTo(otherBook.numberPage);
            else
                throw new ArgumentException("Object is not a Book");
        }

        public override string ToString()
        {
            return name + ", " + numberPage + ", " + authorName;
        }

    }
}
