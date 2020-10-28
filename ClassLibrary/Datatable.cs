using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Datatable
    {
        [Required(ErrorMessage ="please enter user name")]
      
        public string username { get; set; }

        [Required(ErrorMessage ="Please enter password")]
        public string password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
