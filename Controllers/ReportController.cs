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
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult ReportList()
        {

            IEnumerable<ReportModel> reportList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL"]);
                var response = client.GetAsync(string.Format("api/help/reports/get?page=1&limit={0}", 10));
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsAsync<IList<ReportModel>>();
                    content.Wait();
                    reportList = content.Result;
                }

            }

            return View(reportList);
        }
    }
}