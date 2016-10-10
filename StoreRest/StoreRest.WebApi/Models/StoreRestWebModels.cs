using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreRest.WebApi.Models
{
  public class productDto
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Discount { get; set; }

  }

  public class orderDto
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public List<productDto> products { get; set; }
    public decimal totalPrice { get; set; }

  }
}