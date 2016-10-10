using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSoap.Data.Models
{
  public interface IModel
  {
    string getId();
    string getName();

  }

  public class product : IModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Discount { get; set; }

    public string getId()
    {
      return Id;
    }

    public string getName()
    {
      return Name;
    }
  }

  public class order : IModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public List<product> products { get; set; }
    public decimal totalPrice { get; set; }

    public string getId()
    {
      return Id;
    }

    public string getName()
    {
      return Name;
    }
  }
}
