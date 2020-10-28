using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetPrj.Models;
using TimesheetPrj.ViewModel;
using ClassLibrary;
using static TimesheetPrj.Models.Signin;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TimesheetPrj.Controllers
{
    [HandleError(View = "View")]
    [RoutePrefix("Times")]
    public class TimesController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public TimesController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: Times

        [HttpGet]
        public ActionResult Create()
        {
            Time tes = new Time()
            {
                AsDate = DateTime.Today.Date,
                ComDate = DateTime.Today.Date
            };
            TimeSheetViewModel viewModel = new TimeSheetViewModel
            {
                Time = tes,
                Status = GetStatus()
            };
            return View("Create", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Time time)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new TimeSheetViewModel
                {
                    Time = new Time(),
                    Status = GetStatus()
                };
                return View("Create", viewmodel);
            }
            dbContext.times.Add(time);
            dbContext.SaveChanges();
            return RedirectToAction("Get", "Times");

        }

        //[HttpGet]
        //public ActionResult DisplayAll()
        //{
            
        //    return View();
        //}

        [NonAction]
        public List<Time> GetTimes()
        {
            return dbContext.times.ToList();
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetStatus()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="Select Status"},
                new SelectListItem{Text="Completed",Value="Completed"},
                new SelectListItem{Text="InProgress",Value="InProgress"}
            };
        }

        [HttpGet]
        public ActionResult Display()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            //Signin model = new Signin();
            return View();
        }


        [HttpPost]
        public ActionResult Register(Signin signin)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            ViewData.Add("Message1", "You have registered sucessfully,you can signup");
            dbContext.signins.Add(signin);
            dbContext.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult Display(Datatable datatable)
        {
            Timeprj sai = new Timeprj();
            if (ModelState.IsValid)
            {
                bool x = sai.Validate(datatable);
                if (x == true)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    ViewData.Add("Message", "Please enter correct username and password");
                    return View();
                }
            }
            return View();
        }

      
        public ActionResult Get()
        {
            var times = (from Time in dbContext.times select Time).ToList();
            return View(times);
        }
        
        [Route("Result/{start}/{end}")]
        public ActionResult Result(DateTime?start,DateTime?end)
        {
            string maincon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            string sqlquery = "select * from Times where AsDate between'" + start + "'and'" + end + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds,"Times");
            List<Time> times = new List<Time>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                times.Add(new Time
                {
                    Role= Convert.ToString(dr["Role"]),
                    Experience = Convert.ToString(dr["Experience"]),
                    AsDate = Convert.ToDateTime(dr["AsDate"]),
                    ComDate= Convert.ToDateTime(dr["ComDate"]),
                    Status = Convert.ToString(dr["Status"]),
                    Taskdes = Convert.ToString(dr["Taskdes"]),
                });
            }
            con.Close();
            ModelState.Clear();
            return View(times);
        }
    }
}