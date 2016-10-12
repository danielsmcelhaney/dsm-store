using Newtonsoft.Json;
using StoreRest.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreRest.WebApi.Controllers
{
    public class ProductController : ApiController
    {
    private readonly StoreWebApiBLHelper rblh = new StoreWebApiBLHelper();

    
    public HttpResponseMessage Get()
    {
      List<productDto> lpd = rblh.GetProducts();
      return Request.CreateResponse(HttpStatusCode.OK, lpd);
    }

    
    public HttpResponseMessage Post([FromBody]productDto p)
    {
     
      if (rblh.AddProduct(p))
      {
        return Request.CreateResponse(HttpStatusCode.OK);
      }
      else
      {
        return Request.CreateResponse(HttpStatusCode.InternalServerError);
      }
    }

    
    public HttpResponseMessage Delete(productDto p)
    {
      if (rblh.DeleteProduct(p))
      {
        return Request.CreateResponse(HttpStatusCode.OK);
      }
      else
      {
        return Request.CreateResponse(HttpStatusCode.InternalServerError);
      }
    }

  }
}

