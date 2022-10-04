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

        public BooksViewModel()
        {
            descrip = new TypeViewModel();
            identif = new TypeViewModel();
            
        }
    }
}