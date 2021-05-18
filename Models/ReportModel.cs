using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeNow_Admin.Models
{
    public class ReportModel
    {
        public int Report_Id { get; set; }
        public int Ad_Id { get; set; }
        public string User_Id { get; set; }
        public string Report_Reason { get; set; }
        public DateTime Date_Reported { get; set; }
    }
}