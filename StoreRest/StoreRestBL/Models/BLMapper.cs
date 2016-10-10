using StoreRestBL.StoreDASoap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRestBL.Models
{
  class BLMapper
  {

    public product ProductDaoToProduct(productDao pd)
    {
      product p = new product();
      p.Id = pd.Id;
      p.Name = pd.Name;
      p.Price = pd.Price;
      p.Discount = pd.Discount;
      return p;
    }

    public productDao ProductToProductDao(product p)
    {
      productDao pd = new productDao();
      pd.Id = p.Id;
      pd.Name = p.Name;
      pd.Price = p.Price;
      pd.Discount = p.Discount;
      return pd;
    }

    public order OrderDaoToOrder(orderDao od)
    {
      order o = new order();
      o.Id = od.Id;
      o.Name = od.Name;
      o.totalPrice = od.totalPrice;
      List<product> lp = new List<product>();
      foreach (var item in od.products)
      {
        lp.Add(ProductDaoToProduct(item));
      }
      o.products = lp.ToArray();
      return o;
    }

    public orderDao OrderToOrderDao(order o)
    {
      orderDao od = new orderDao();
      od.Id = o.Id;
      od.Name = o.Name;
      od.products = new List<productDao>();
      foreach (var item in o.products)
      {
        od.products.Add(ProductToProductDao(item));
      }
      od.totalPrice = o.totalPrice;
      return od;
    }

  }
}


  }
}
