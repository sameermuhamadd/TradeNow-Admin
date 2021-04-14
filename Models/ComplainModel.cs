using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeNow_Admin.Models
{
    public class ComplainModel
    {
     
            public int Complain_Id { get; set; }
            public string Complain_Type { get; set; }
            public string Complain_Description { get; set; }
            public string Complain_Satus { get; set; }
            public string User_Id { get; set; }
            public DateTime Date { get; set; }
        
    }
}