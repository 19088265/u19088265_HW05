using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HW05.Models;

namespace HW05.Models
{
    public class BorrowService
    {
        public string stuName { get; set; }
        public Nullable<int> borrowID { get; set; }
        public Nullable<int> takenDate { get; set; }
        public Nullable<int> broughtDate { get; set; }
    
    }
}