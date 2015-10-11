#region

using System.Runtime.Serialization;

#endregion

namespace WcfService
{
    [DataContract]
    public class Position
    {
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        [DataMember]
        public double X { get; set; }

        [DataMember]
        public double Y { get; set; }
    }
}