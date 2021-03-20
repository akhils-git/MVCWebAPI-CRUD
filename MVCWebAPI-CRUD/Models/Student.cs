using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebAPI_CRUD.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Malayalam { get; set; }
        public string English { get; set; }
        public string Hindi { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Total { get; set; }
        public decimal? Average { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}