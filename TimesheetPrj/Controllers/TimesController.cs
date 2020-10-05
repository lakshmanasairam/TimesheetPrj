using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetPrj.Models;
using TimesheetPrj.ViewModel;

namespace TimesheetPrj.Controllers
{
    [HandleError(View ="View")]
    public class TimesController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public TimesController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if(dbContext!=null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Times
        public ActionResult Index()
        {
            List<Time> times = GetTimes();
            return View(times);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new TimeSheetViewModel
            {
                Time = new Time(),
                Status= GetStatus()
            };
            return View("Create",viewModel);
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
           
            return RedirectToAction("Index", "Times");
        }


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
                new SelectListItem{Text="NotCompleted",Value="NotCompleted"}
            };
        }
        
        public ActionResult Display()
        {
            return View();
        }

    }
}