using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using HW05.Models;

namespace HW05.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students

        SqlConnection myConnection = new SqlConnection("Data Source=INFB1-07\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");
        public ActionResult Students()
        {
            try
            {
                myConnection.Open();

                //Read data
                SqlCommand myCommand = new SqlCommand(
                    "SELECT studentId, name, surname, class, point FROM students", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StudentsViewModel student = new StudentsViewModel();
                    student.sID = (int)myReader["studentId"];
                    student.sName = myReader["name"].ToString();
                    student.sSurname = myReader["surname"].ToString();
                    student.sClass = myReader["class"].ToString();
                    student.sPoint = (int)myReader["point"];
                    Books.studentList.Add(student);
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
            
            return View(Books.studentList);
        }

        public ActionResult SimpleSearch(string searchName)
        {
            try
            {
                myConnection.Open();

                SqlCommand myBasicSearch = new SqlCommand(
                    "SELECT studentId, name, surname, class, point FROM students WHERE students.name LIKE '%" +searchName+ "%' ", myConnection);
                SqlDataReader myReader = myBasicSearch.ExecuteReader();
                Books.studentList.Clear();
                while (myReader.Read())
                {
                    StudentsViewModel student = new StudentsViewModel();
                    student.sID = (int)myReader["studentId"];
                    student.sName = myReader["name"].ToString();
                    student.sSurname = myReader["surname"].ToString();
                    student.sClass = myReader["class"].ToString();
                    student.sPoint = (int)myReader["point"];
                    Books.studentList.Add(student);
                    //var orderByID = bookList.OrderByDescending(s => s.bookID);
                }
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return View("Students", Books.studentList);
        }
        }
    }