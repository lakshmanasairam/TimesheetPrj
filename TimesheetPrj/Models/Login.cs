using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetPrj.Models
{
    public class Login
    {
        public int id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


    }
}