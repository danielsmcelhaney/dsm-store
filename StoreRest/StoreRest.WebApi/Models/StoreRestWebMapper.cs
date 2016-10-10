using StoreRestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreRest.WebApi.Models
{
  public class StoreRestWebMapper
  {
    public productDao ProductDtoToProductDao(productDto pd)
    {
      productDao p = new productDao();
      p.Id = pd.Id;
      p.Name = pd.Name;
      p.Price = pd.Price;
      p.Discount = pd.Discount;
      return p;
    }

    public productDto ProductDaoToProductDto(productDao p)
    {
      productDto pd = new productDto();
      pd.Id = p.Id;
      pd.Name = p.Name;
      pd.Price = p.Price;
      pd.Discount = p.Discount;
      return pd;
    }

    public orderDao OrderDtoToOrderDao(orderDto od)
    {
      orderDao o = new orderDao();
      o.Id = od.Id;
      o.Name = od.Name;
      o.products = new List<productDao>();
      foreach (var item in od.products)
      {
        o.products.Add(ProductDtoToProductDao(item));
      }
      o.totalPrice = od.totalPrice;
      return o;
    }

    public orderDto OrderDaoToOrderDto(orderDao o)
    {
      orderDto od = new orderDto();
      od.Id = o.Id;
      od.Name = o.Name;
      od.products = new List<productDto>();
      foreach (var item in o.products)
      {
        od.products.Add(ProductDaoToProductDto(item));
      }
      od.totalPrice = o.totalPrice;
      return od;
    }

  }
}