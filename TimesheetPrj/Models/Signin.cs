using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimesheetPrj.Models
{
    public class Signin
    {
        public int id { get; set; }

       // [Remote("IsUsernameExist",ErrorMessage ="User name already exist.")]
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$", 
            ErrorMessage = "Password must contain atleast 1 Upper case, 1 lower case alphabets, 1 number, " +
            "1 special character and length must be between 8-15")]
        public string password { get; set; }

        [Required (ErrorMessage ="password And confirmpassword doesnot match")]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string ConfirmPassword { get; set; }

        public static class SigninStaticData
        {
            public static List<Signin> UserList
            {
                get
                {
                    return new List<Signin>
                    {
                        new Signin
                        {
                            Username="sairam@gmail.com" ,password="sai123@S",ConfirmPassword="sai123@S"
                        }
                    };
                }
            }
        }
    }
}