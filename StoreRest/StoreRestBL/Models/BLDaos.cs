using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRestBL.Models
{
  public class productDao
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Discount { get; set; }

  }

  public class orderDao
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public List<productDao> products { get; set; }
    public decimal totalPrice { get; set; }

  }
}
