using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeNow_Admin.Models
{
    public class AccountModel
    {
        public class LoginRequestModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string GrantType = "password";
        }
    }
}