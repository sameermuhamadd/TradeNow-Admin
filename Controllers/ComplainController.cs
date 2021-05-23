using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        public ActionResult Details(int id)
        {
           
         //   IEnumerable<ComplainModel> complainList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL"]);
                var response = client.GetAsync(string.Format("api/help/complain/detail?id={0}", id));
                response.Wait();

                var result = response.Result;
                var content = result.Content.ReadAsAsync<ComplainModel>();
                ComplainModel complain = new ComplainModel();
                if (result.IsSuccessStatusCode)
                {
                    complain = content.Result;
                    
                    return PartialView(complain);
                }
                return View(complain);

            }
            
        }
    }
}