using Newtonsoft.Json;
using StoreClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace StoreClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public async Task<ActionResult> Index()
        {
          string url = "";
          try
          {
           url = "http://localhost/StoreRest/api/product";
            using (HttpClient client = new HttpClient())
            {
              client.BaseAddress = new Uri(url);
              client.DefaultRequestHeaders.Accept.Clear();
              HttpResponseMessage response = await client.GetAsync(url);
               if (response.IsSuccessStatusCode)
               {
                 var p = await response.Content.ReadAsStringAsync();
                 ProductListModel s = new ProductListModel();
                s.lpm = JsonConvert.DeserializeObject<List<ProductModel>>(p);
                return View(s.lpm);
               }
               else
              {
                ViewBag.Results = "0";
               return View(new List<ProductModel>());
              }
            } //end using System.Net.Http.HttpClient client
         }
           catch (Exception)
         {
           ViewBag.Results = "0";
           return View(new List<ProductModel>());
        }
        } //end public async Results method
       
    [HttpGet]
    public ActionResult AddProduct()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct(ProductModel p)
    {
      HttpClient c = new HttpClient();
      var ps = JsonConvert.SerializeObject(p);
      StringContent hc = new StringContent(ps);
      var r = await c.PostAsync("http://localhost/StoreRest/api/product", hc);
      if(r.IsSuccessStatusCode)
      {
        return View("TransactionComplete");
      }
      else
      {
        return View("TransactionFail");
      }
      
    }

  }
 }
