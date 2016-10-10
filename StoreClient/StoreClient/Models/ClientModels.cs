using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreClient.Models
{
  public class ProductListModel
  {
    public List<ProductModel> lpm { get; set; }
  }

  public class ProductModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Discount { get; set; }

  }

  public class OrderListModel
  {
    public List<OrderModel> lom { get; set; }
  }

  public class OrderModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public List<ProductModel> products { get; set; }
    public decimal totalPrice { get; set; }
  }

}