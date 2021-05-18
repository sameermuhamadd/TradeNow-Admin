using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TradeNow_Admin.Models;
using Newtonsoft.Json;


namespace TradeNow_Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel.LoginRequestModel model)
        {
            IEnumerable<KeyValuePair<string, string>> credentials = new
                List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string,string>("username",model.Username),
                new KeyValuePair<string,string>("password",model.Password),
                new KeyValuePair<string,string>("grant_type",model.GrantType),
            };
            HttpContent httpContent = new FormUrlEncodedContent(credentials);
            //var credentials = new AccountModel.LoginRequestModel()
            //{
            //    Username = model.Username,
            //    Password = model.Password,
            //    GrantType = model.GrantType
            //};
            //model.Username = "adminx@tradenow.com";
            //model.Password = "Sameer123@";
            //model.GrantType = "password";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL"]);
                var response = client.PostAsync("token?", httpContent);
                if (response.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Home");
                }
                return View();
            }
            
           // return View();
        }
    }
}