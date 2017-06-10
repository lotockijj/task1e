using System.Collections.Generic;

namespace task1e
{
    public class Library : ICountingBooks
    {
        private List<Department> departments;
        public static int id = 0;

        public Library()
        {
        }

        public Library(List<Department> d)
        {
            departments = d;
            id++;
        }

        public List<Department> Departments
        {
            get { return departments; }
            set { departments = value; }
        }

        public int getNumberBooks()
        {
            int numberBooks = 0;
            for (int i = 0; i < departments.Count; i++)
            {
                numberBooks += departments[i].getNumberBooks();
            }
            return numberBooks;
        }
    }
}
