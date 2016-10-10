﻿using Newtonsoft.Json;
using StoreClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace StoreClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
          string url = "";
          try
          {
           url = "http://localhost/StoreRest/api/product";
            using (HttpClient client = new HttpClient())
            {
              client.BaseAddress = new Uri(url);
              client.DefaultRequestHeaders.Accept.Clear();
              //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
              System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
               if (response.IsSuccessStatusCode)
               {
                 var p = await response.Content.ReadAsStringAsync();
                 //convert List of Snippets into objects
               ProductListModel s = new ProductListModel();
                s.lpm = JsonConvert.DeserializeObject<List<ProductModel>>(p);
                ViewBag.Results = s.lpm.Count.ToString();
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
       
  }
 }
