using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StoreSoap.Data
{
  public class XmlHelper<T>
  {
    List<T> l;
    private string fn;

    public XmlHelper(string fileName)
    {
      l = new List<T>();
      fn = fileName;
    }

    public bool addItem(T i)
    {
      try
      {
        XmlSerializer xs = new XmlSerializer(l.GetType());
        if (File.Exists(fn))
        {

          using (Stream s = File.OpenRead(fn))
          {

            if (s.Length == 0)
            {
              l.Clear();
            }
            else
            {
              l = (List<T>)xs.Deserialize(s);
            }
            s.Close();
            l.Add(i);
          }
        }
        else
        {
          using (Stream s = File.Create(fn))
          {
            l.Clear();
            l.Add(i);
          }
        }
        if (serializeList(l))
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch
      {
        throw;
      }
    }

    public bool deleteItem(T i)
    {
      try
      {
        l = deserializeList();

        if ((l.RemoveAll(item => item.GetType().GetMethod("getId").Invoke(item, null).ToString() == i.GetType().GetMethod("getId").Invoke(i, null).ToString() &&
         item.GetType().GetMethod("getName").Invoke(item, null).ToString() == i.GetType().GetMethod("getName").Invoke(i, null).ToString())) > 0)
        {
          serializeList(l);
          return true;
        }
        else
        {
          return false;
        }

      }
      catch
      {
        throw;
      }



    }

    public bool serializeList(List<T> ld)
    {
      try
      {
        XmlSerializer xs = new XmlSerializer(ld.GetType());
        using (Stream s = File.Open(fn, FileMode.Truncate))
        {
          xs.Serialize(s, ld);
        }
        return true;
      }
      catch
      {
        return false;
      }
    }


    public List<T> deserializeList()
    {

      try
      {
        XmlSerializer xs = new XmlSerializer(l.GetType());
        using (Stream s = File.OpenRead(fn))
        {
          if (s.Length == 0)
          {
            l.Clear();
            return l;
          }
          else
          {
            return (List<T>)xs.Deserialize(s);
          }

        }

      }
      catch
      {
        throw;
      }

    }

  }
}

