using StoreSoap.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StoreSoap.Soap
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreDataSoap" in both code and config file together.
  [ServiceContract]
  public interface IStoreDataSoap
  {
    [OperationContract]
    List<product> GetProducts();

    [OperationContract]
    bool AddProduct(product p);

    [OperationContract]
    bool DeleteProduct(product p);

    [OperationContract]
    List<order> GetOders();

    [OperationContract]
    bool AddOrder(order o);

    [OperationContract]
    bool DeleteOrder(order o);
  }
}

