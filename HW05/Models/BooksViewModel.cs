using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class BooksViewModel
    {

        //Properties
        public int bookID { get; set; }

        public string bookName { get; set; }

        public int pageCount { get; set; }

        public int point { get; set; }

        public int authorID { get; set; }
        public TypeViewModel descrip { get; set; }

        public TypeViewModel identif { get; set; }

       // public AuthorsViewModel aID { get; set; }
        //public AuthorsViewModel aName { get; set; }
        //public AuthorsViewModel aSurname { get; set; }

        public BooksViewModel()
        {
            descrip = new TypeViewModel();
            identif = new TypeViewModel();
            //aID = new AuthorsViewModel();
           // aName = new AuthorsViewModel();
            //aSurname = new AuthorsViewModel();
        }
    }
}