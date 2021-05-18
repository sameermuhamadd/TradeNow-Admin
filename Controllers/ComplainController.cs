using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TradeNow_Admin.Models;

namespace TradeNow_Admin.Controllers
{
    public class ComplainController : Controller
    {
        // GET: Complain
        public ActionResult ComplainList()
        {
            IEnumerable<ComplainModel> complainList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL"]);
                var response = client.GetAsync(string.Format("api/help/complain/get?page=1&limit={0}", 10));
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsAsync<IList<ComplainModel>>();
                    content.Wait();
                    complainList = content.Result;
                }
                
            }
            
            return View(complainList);
         
        }
        public ActionResult ComplainDetail()
        {

            return View();
        }
    }
}