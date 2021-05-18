using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeNow_Admin.Models;
using System.Web.Configuration;
using System.Net.Http;
namespace TradeNow_Admin.Controllers
{
    public class RegisterController : Controller
    {
        // POST: Register
        public ActionResult RiderLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RiderLogin(Register registerRiders)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.BaseAddress = new Uri("https://ptsv2.com/");
                var postJob = client.PostAsJsonAsync<Register>("/api/Account/Register", registerRiders);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError(string.Empty, "Server Error");
                return View(registerRiders);
        }
    }
}