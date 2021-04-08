using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using TradeNow_Admin.Models;
using Newtonsoft.Json;

namespace TradeNow_Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ViewOrder()
        {
            IEnumerable<OrderModel> orderList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL"]);
                var response = client.GetAsync(string.Format("api/order/history?page=1&limit={0}",10));
                response.Wait();
                
                var result = response.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsAsync<IList<OrderModel>>();
                    content.Wait();
                    orderList = content.Result;
                }
            }
            return View(orderList);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
