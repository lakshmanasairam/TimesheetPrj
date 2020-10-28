using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static TimesheetPrj.Models.Signin;

namespace TimesheetPrj.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation

        [HttpGet]
        public JsonResult IsUsernameExist(string Username)
        {
            bool isExist = SigninStaticData.UserList.Where(u => u.Username.ToLowerInvariant().Equals(Username.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
    }
}