using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetPrj.Models;

namespace TimesheetPrj.ViewModel
{
    public class TimeSheetViewModel
    {
        public Time Time { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }

    }
}