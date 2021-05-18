using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeNow_Admin.Models
{
    public class Register
    {
     
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string FName { get; set; }
            public string UserType { get; set; }
        }

}