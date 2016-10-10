using StoreRestBL.Models;
using StoreRestBL.StoreDASoap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRestBL
{
  class BLSoapHelper
  {
    private readonly StoreDataSoapClient c = new StoreDataSoapClient();
    BLMapper map = new BLMapper();

    public List<productDao> GetProducts()
    {
      product[] ap = c.GetProducts();
      List<product> lp = ap.ToList();
      List<productDao> lpd = new List<productDao>();
      foreach (var item in lp)
      {
        lpd.Add(map.ProductToProductDao(item));
      }
      return lpd;
    }

    public bool AddProduct(productDao pd)
    {
      return c.AddProduct(map.ProductDaoToProduct(pd));
    }

    public bool DeleteProduct(productDao pd)
    {
      return c.DeleteProduct(map.ProductDaoToProduct(pd));
    }

    public List<orderDao> GetOrders()
    {
      order[] ao = c.GetOders();
      List<order> lo = new List<order>();
      List<orderDao> lod = new List<orderDao>();
      lo = ao.ToList();
      foreach (var item in lo)
      {
        lod.Add(map.OrderToOrderDao(item));
      }
      return lod;
    }

    public bool AddOrder(orderDao od)
    {
      return c.AddOrder(map.OrderDaoToOrder(od));
    }

    public bool DeleteOrder(orderDao od)
    {
      return c.DeleteOrder(map.OrderDaoToOrder(od));
    }

  }
}

