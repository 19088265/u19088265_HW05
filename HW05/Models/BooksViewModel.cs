using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW05.Models
{
    public class BooksViewModel
    {
        public int bookID { get; set; }

        public string bookName { get; set; }

        public int pageCount { get; set; }

        public int point { get; set; }

        public int authorID { get; set; }

        public int typeID { get; set; }
    }
}