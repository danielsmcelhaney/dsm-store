using StoreSoap.Data;
using StoreSoap.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StoreSoap.Soap
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoreDataSoap" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select StoreDataSoap.svc or StoreDataSoap.svc.cs at the Solution Explorer and start debugging.
  public class StoreDataSoap : IStoreDataSoap
  {
    XmlHelper<product> ph = new XmlHelper<product>(@"c:\products.xml");
    XmlHelper<order> oh = new XmlHelper<order>(@"c:\orders.xml");

    public bool AddOrder(order o)
    {

      if (oh.addItem(o))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool AddProduct(product p)
    {

      if (ph.addItem(p))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool DeleteOrder(order o)
    {

      if (oh.deleteItem(o))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool DeleteProduct(product p)
    {

      if (ph.deleteItem(p))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public List<order> GetOders()
    {
      List<order> lo = oh.deserializeList();
      return lo;
    }

    public List<product> GetProducts()
    {
      List<product> lp = ph.deserializeList();
      return lp;
    }
  }
}

