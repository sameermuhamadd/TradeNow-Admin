using System.Collections.Generic;
namespace TradeNow_Admin.Models
{
    public class ViewModel
    {
        public IEnumerable<ComplainModel> Complains { get; set; }
        public IEnumerable<OrderModel> Orders { get; set; }
        public IEnumerable<ReportModel> Reports { get; set; }

    }

}