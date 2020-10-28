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

        [Display(Name ="Story #")]
        [Required]
        public string Role { get; set; }


        [Required]
        [Display(Name ="IT #")]
        public string Experience { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        [Display(Name ="Assigned Date")]
        public DateTime AsDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        [Display(Name ="Completed Date")]
        public DateTime ComDate { get; set; }


        [Required]
        public string Status { get; set; }

        
        [Required]
        [Display(Name ="Task Description")]
        public string Taskdes { get; set; }

    }
}