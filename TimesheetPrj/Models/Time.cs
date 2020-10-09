using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimesheetPrj.Models
{
    public class Time
    {
        public int Id { get; set; }


        [Required]
        public string Role { get; set; }


        [Required]
        public int? Experience { get; set; }


        [Required]
        public DateTime AsDate { get; set; }

        [Required]
        public DateTime ComDate { get; set; }


        [Required]
        public string Status { get; set; }

        public string Taskdes { get; set; }

    }
}