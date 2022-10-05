using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using HW05.Models;

namespace HW05.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection myConnection = new SqlConnection("Data Source=INFB1-07\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");


        public ActionResult Index()
        {
            //List<BooksViewModel> bookList = new List<BooksViewModel>();
            try
            {
                myConnection.Open();

                //Read table
                SqlCommand myCommand = new SqlCommand(
                    "SELECT books.bookId, books.name, books.typeId, types.nname, books.pagecount, books.point FROM books INNER JOIN types ON books.typeId = types.typeId", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while(myReader.Read())
                {
                    BooksViewModel book = new BooksViewModel();
                    book.bookID = (int)myReader["bookId"];
                    book.bookName = myReader["name"].ToString();
                    book.Type.ID = (int)myReader["typeId"];
                    book.Type.Name = myReader["nname"].ToString();
                    book.pageCount = (int)myReader["pagecount"];
                    book.point = (int)myReader["point"];
                    Books.bookList.Add(book);
                    //var orderByID = bookList.OrderByDescending(s => s.bookID);
                }
            }
            catch(Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            
            return View(Books.bookList);
        }

        public ActionResult BasicSearch(string searchText)
        {
            try
            {
                myConnection.Open();

                SqlCommand myBasicSearch = new SqlCommand(
                    "SELECT books.bookId, books.name, books.typeId, types.nname, books.pagecount, books.point FROM books INNER JOIN types ON books.typeId = types.typeId WHERE books.name LIKE '%" +searchText+ "%' ", myConnection);
                SqlDataReader myReader = myBasicSearch.ExecuteReader();
                Books.bookList.Clear();
                while (myReader.Read())
                {
                    BooksViewModel book = new BooksViewModel();
                    book.bookID = (int)myReader["bookId"];
                    book.bookName = myReader["name"].ToString();
                    book.Type.ID = (int)myReader["typeId"];
                    book.Type.Name = myReader["nname"].ToString();
                    book.pageCount = (int)myReader["pagecount"];
                    book.point = (int)myReader["point"];
                    Books.bookList.Add(book);
                }
            }
            catch(Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally 
            {
                myConnection.Close();
            }
            
            return View("Index", Books.bookList);
        }

        public ActionResult BookDetails()
        {

            try
            {
                myConnection.Open();

                //Read data
                SqlCommand myCommand = new SqlCommand(
                    "SELECT borrows.borrowId, borrows.takenDate, borrows.broughtDate, students.name, students.surname FROM borrows INNER JOIN books ON borrows.bookId = books.bookId", myConnection);

            }
            catch
            {

            }
            finally
            {

            }
            
            return View();
        }

        public ActionResult Students()
        {

            return View();
        }
    }
}