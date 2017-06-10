using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1e
{
    public class Department : IComparable, ICountingBooks
    {
        private string name;
        private List<Book> books;

        public Department()
        {
        }

        public Department(string n, List<Book> b)
        {
            name = n;
            books = b;
        }

        public string DepartmentName
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

            Department otherDepartment = obj as Department;
            if (otherDepartment != null)
                return this.books.Count.CompareTo(otherDepartment.books.Count);
            else
                throw new ArgumentException("Object is not a Department");
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
