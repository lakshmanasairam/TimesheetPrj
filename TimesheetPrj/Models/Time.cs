using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetPrj.Models
{
    public class Time
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public int? Experience { get; set; }

        public DateTime AsDate { get; set; }

        public DateTime ComDate { get; set; }

        public string Status { get; set; }

        public string Taskdes { get; set; }

    }
}