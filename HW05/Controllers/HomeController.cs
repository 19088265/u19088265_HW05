﻿using System;
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
        SqlConnection myConnection = new SqlConnection("Data Source=HOPGD-43\\SYSARCH1;Initial Catalog=Library;Integrated Security=True");


        public ActionResult Index()
        {
            List<BooksViewModel> bookList = new List<BooksViewModel>();
            try
            {
                myConnection.Open();

                //Read table
                SqlCommand myCommand = new SqlCommand(
                    "SELECT books.bookId, books.name, books.pagecount, books.point, books.authorId, books.typeId, types.name FROM books INNER JOIN types ON books.typeId = types.typeID", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while(myReader.Read())
                {
                    BooksViewModel book = new BooksViewModel();
                    book.bookID = (int)myReader["bookId"];
                    book.bookName = myReader["name"].ToString();
                    book.pageCount = (int)myReader["pagecount"];
                    book.point = (int)myReader["point"];
                    book.authorID = (int)myReader["authorId"];
                    book.identif.id = (int)myReader["typeId"];
                    book.descrip.name = myReader["name"].ToString();
                    bookList.Add(book);
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
            
            return View(bookList);
        }

        public ActionResult BookDetails()
        {

            return View();
        }

        public ActionResult Students()
        {

            return View();
        }
    }
}