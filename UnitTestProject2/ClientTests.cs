using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1e;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void TestGetBiggestDepartment()
        {
            Book book = new Book("H.Shildt", "c# in depth", 111);
            Book book2 = new Book("Remark", "Black tomb", 222);
            List<Book> books = new List<Book>();
            books.Add(book);
            books.Add(book2);
            List<Book> iTBook = new List<Book>();
            iTBook.Add(book);
            Department department = new Department("All books", books);
            Department departmentIT = new Department("IT books", iTBook);
            List<Department> departments = new List<Department>();
            departments.Add(department);
            departments.Add(departmentIT);
            Library library = new Library(departments);
            Client client = new Client();
            Department theBiggestDepartment = client.getBiggestDepartment(library);
            Assert.AreEqual("All books", theBiggestDepartment.DepartmentName);
        }
    }
}
