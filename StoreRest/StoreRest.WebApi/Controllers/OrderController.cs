using StoreRest.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreRest.WebApi.Controllers
{
    public class OrderController : ApiController
    {
    private readonly StoreWebApiBLHelper rblh = new StoreWebApiBLHelper();

    [HttpGet]
    public HttpResponseMessage Get()
    {
      return Request.CreateResponse(HttpStatusCode.OK, rblh.GetOrders());
    }

    [HttpPost]
    public HttpResponseMessage Post(orderDto o)
    {
      if (rblh.AddOrder(o))
      {
        return Request.CreateResponse(HttpStatusCode.OK);
      }
      else
      {
        return Request.CreateResponse(HttpStatusCode.InternalServerError);
      }
    }

    [HttpDelete]
    public HttpResponseMessage Delete(orderDto o)
    {
      if (rblh.DeleteOrder(o))
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

