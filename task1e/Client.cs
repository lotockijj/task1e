using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace task1e
{
    public class Client
    {
        public static object IntermediateSerializer { get; private set; }
        public static object ExampleData { get; private set; }

        public Author getAuthorWithBiggestNumberBooks(List<Author> authors)
        {
            Author author = null;
            for (int i = 0; i < authors.Count - 1; i++)
            {
                if (authors[i].getNumberBooks() > authors[i + 1].getNumberBooks())
                {
                    author = authors[i];
                }
                else
                {
                    author = authors[i + 1];
                }
            }
            return author;
        }

        public Department getBiggestDepartment(Library library)
        {
            Department department = null;
            List<Department> departments = library.Departments;
            for (int i = 0; i < departments.Count - 1; i++)
            {
                if (departments[i].getNumberBooks() > departments[i + 1].getNumberBooks())
                {
                    department = departments[i];
                }
                else
                {
                    department = departments[i + 1];
                }
            }
            return department;
        }

        public Book getTheSmallestBook(Library library)
        {
            List<Department> departments = library.Departments;
            Book book = departments[0].Books[0];
            for (int i = 0; i < departments.Count; i++)
            {
                for (int j = 0; j < departments[i].Books.Count; j++)
                {
                    if (departments[i].Books[j].NumberPage < book.NumberPage)
                    {
                        book = departments[i].Books[j];
                    }
                }
            }
            return book;
        }

        public static void showBooksInSortedState(List<Book> books)
        {
            var list = from b in books orderby b.Name ascending select b;
            foreach (Book b in list)
            {
                Console.WriteLine(b.Name + ", " + b.AuthorName + ", " + b.NumberPage);
            }
        }

        public static void showSearchingBookByAuthor(List<Book> books, string name)
        {
            var list = books.Where(n => (n.AuthorName).Contains(name));
            foreach (Book b in list)
            {
                Console.WriteLine(b.Name + ", " + b.AuthorName + ", " + b.NumberPage);
            }
        }

        public static void createLibraryXMLFile(Library library)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";

            var sb = new StringBuilder("d:\\eleks\\library2.xml");
            XmlWriter writer = XmlWriter.Create(sb);
            writer.WriteStartDocument(true);
            writer.WriteStartElement("library");
            writer.WriteAttributeString("id", "1");
            writer.WriteElementString("department", "IT books");
            writer.WriteStartElement("book");
            writer.WriteAttributeString("name", "c# in depth");
            writer.WriteAttributeString("author", "H.Shildt");
            writer.WriteAttributeString("page", "222");
            writer.WriteEndElement();
        }

        public static void createXmlFileNext(Library library)
        {
            XmlTextWriter writer = new XmlTextWriter("library.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("library");
            writer.WriteStartElement("department");
            writer.WriteAttributeString("name", "IT books");
            writer.WriteStartElement("book");

            writer.WriteStartElement("name");
            writer.WriteString("My first book!!!");
            writer.WriteEndElement();
            writer.WriteStartElement("authourName");
            writer.WriteString("Roman");
            writer.WriteEndElement();
            //writer.WriteStartElement("number page");
            int numberPage = 111;
            writer.WriteElementString("numberPage", XmlConvert.ToString(numberPage));
            //Double price = 19.95;
            //writer.WriteElementString("price", XmlConvert.ToString(price));
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static void testCreateXmlFile()
        {
            XmlWriter xmlWriter = XmlWriter.Create("test.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("users");

            xmlWriter.WriteStartElement("user");
            xmlWriter.WriteAttributeString("age", "42");
            xmlWriter.WriteString("John Doe");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("user");
            xmlWriter.WriteAttributeString("age", "39");
            xmlWriter.WriteString("Jane Doe");

            xmlWriter.WriteEndDocument();
        }


        public static void readXmlDocument(string path)
        {
            var xml = XDocument.Load("D:\\eleks\\ConsoleApp2" +
                "\\ConsoleApp2\\bin\\Debug\\library.xml");
            Console.WriteLine("Just have read :)");
            var query = from c in xml.Root.Descendants("book")
                        select c.Element("name").Value + " " +
                               c.Element("authour name").Value + " " +
                               c.Element("numberPage").Value;
            Console.WriteLine("After query :) ");
            foreach (String name in query)
            {
                Console.WriteLine(name);
            }
        }

        static void Main(string[] args)
        {
            Book book1 = new Book("Jon Skeet", "C# in depth", 614);
            Book book2 = new Book("Jeffrey Richter", "CLR via C#", 700);
            Book book3 = new Book("H.Schildt", "C# 4.0 The Complete Reference", 511);

            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            //books.Sort();
            var list = from b in books orderby b.Name ascending select b;
            foreach (Book b in list)
            {
                Console.WriteLine(b.Name + ", " + b.AuthorName + ", " + b.NumberPage);
            }
            Console.WriteLine("Testing sort method !!! :) ");
            Client.showBooksInSortedState(books);
            Console.WriteLine("TESTING SEARCH METHOD !!!");
            Client.showSearchingBookByAuthor(books, "H.Schildt");
            list = from p in books orderby p.Name ascending select p;

            foreach (Book p in books)
            {
                Console.WriteLine(p.Name);
            }

            Author author = new Author("Remark", books);
            Console.WriteLine(author);

            Department iTbooks =
                new Department("IT books", books);

            Book book4 = new Book("Remark", "Three Comrades ", 333);
            Book book5 = new Book("Remark", "Arch of Triumph", 444);

            List<Book> books2 = new List<Book>();
            books2.Add(book4);
            books2.Add(book5);

            for (int i = 0; i < books2.Count; i++)
            {
                Console.WriteLine(books2[i]);
            }

            Author author2 = new Author("H.Schildt", books2);

            Department overseasLiterature =
                new Department("Overseas literature", books2);

            List<Department> departments = new List<Department>();
            departments.Add(iTbooks);
            departments.Add(overseasLiterature);

            Library library = new Library(departments);
            Client.createLibraryXMLFile(library);
            //Client.createLibraryXMLFileNext(library);
            //Client.readXmlDocument("library.xml");

            Console.ReadKey();
        }
    }
}