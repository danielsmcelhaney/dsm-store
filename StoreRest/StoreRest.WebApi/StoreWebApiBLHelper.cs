using StoreRest.WebApi.Models;
using StoreRestBL;
using StoreRestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreRest.WebApi
{
  public class StoreWebApiBLHelper
  {
    private readonly BLSoapHelper blsh = new BLSoapHelper();
    private readonly StoreRestWebMapper map = new StoreRestWebMapper();


    public List<productDto> GetProducts()
    {
      List<productDao> p = blsh.GetProducts();
      List<productDto> pd = new List<productDto>();
      foreach (var item in p)
      {
        pd.Add(map.ProductDaoToProductDto(item));
      }
      return pd;
    }

    public List<orderDto> GetOrders()
    {
      List<orderDao> o = blsh.GetOrders();
      List<orderDto> od = new List<orderDto>();
      foreach (var item in o)
      {
        od.Add(map.OrderDaoToOrderDto(item));
      }
      return od;
    }

    public bool AddProduct(productDto pd)
    {
      return blsh.AddProduct(map.ProductDtoToProductDao(pd));
    }

    public bool AddOrder(orderDto od)
    {
      return blsh.AddOrder(map.OrderDtoToOrderDao(od));
    }


    public bool DeleteProduct(productDto pd)
    {
      return blsh.DeleteProduct(map.ProductDtoToProductDao(pd));
    }

    public bool DeleteOrder(orderDto od)
    {
      return blsh.DeleteOrder(map.OrderDtoToOrderDao(od));
    }

  }
}