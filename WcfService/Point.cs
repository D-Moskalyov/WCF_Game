using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WcfService
{
  [DataContract]
  public  class Point
    {
      
      public Point(int a, int b)
      {
          x = a;
      }

      int x;

      [DataMember]
      public int X
      {
          get { return x; }
          set { x = value; }
      }
        int y;


    }
}
