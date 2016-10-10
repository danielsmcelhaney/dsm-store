using Newtonsoft.Json;
using StoreClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StoreClient.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public async Task<ActionResult> Index()
        {

            string url = "";
            try
            {
              url = "http://localhost/StoreRest/api/order";
              using (HttpClient client = new HttpClient())
              {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                  var p = await response.Content.ReadAsStringAsync();
                  OrderListModel s = new OrderListModel();
                  s.lom = JsonConvert.DeserializeObject<List<OrderModel>>(p);
                  
                  return View(s.lom);
                }
                else
                {
                  ViewBag.Results = "0";
                  return View(new List<OrderModel>());
                }
              } //end using System.Net.Http.HttpClient client
            }
            catch (Exception)
            {
              ViewBag.Results = "0";
              return View(new List<OrderModel>());
            }
          }
    }
}