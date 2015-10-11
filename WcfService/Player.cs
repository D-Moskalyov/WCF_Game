#region

using System.Runtime.Serialization;
using System.Windows.Media;

#endregion

namespace WcfService
{
    [DataContract]
    public class Player
    {
        public Player(string login, Color color)
        {
            Login = login;
            Color = color;
            X = 0;
            Y = 0;
        }

        [DataMember]
        public double X { get; set; }

        [DataMember]
        public double Y { get; set; }

        [DataMember]
        public string Login { get; private set; }

        [DataMember]
        public Color Color { get; private set; }
    }
}