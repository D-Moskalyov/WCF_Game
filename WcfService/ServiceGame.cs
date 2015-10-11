#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Media;

#endregion

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceGame" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceGame : IServiceGame
    {
        private static readonly List<Player> Players = new List<Player>();
        private bool _isAuthorize;
        private Player _player;

        public bool Login(string login, Color color)
        {
            if (Players.FindIndex(x => x.Login == login) >= 0)
            {
                _player = Players.Find(x => x.Login == login);
                Console.ForegroundColor = ConsoleColor.Blue;
                _player.X = 0;
                _player.Y = 0;
                Console.WriteLine("Return {0}", _player.Login);
                Console.ResetColor();
            }
            else
            {
                _player = new Player(login, color);
                Players.Add(_player);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login {0}", login);
                Console.ResetColor();
            }
            _isAuthorize = true;
            return _isAuthorize;
        }

        public void SendCoord(double x, double y)
        {
            if (!_isAuthorize) return;

            _player.X = x;
            _player.Y = y;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} SendCoord : ({1},{2})", _player.Login, x, y);
            Console.ResetColor();
        }

        public List<Player> GetAllPlayers()
        {
            if (!_isAuthorize) return Players;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} GetAllPlayers", _player.Login);
            Console.ResetColor();
            return Players.FindAll(x => x.Login != _player.Login);
        }

        public Position GetPositionPlayer(string login)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} GetPositionPlayer : ({1})", _player.Login, login);
            Console.ResetColor();
            IEnumerable<Position> positions = (from p in Players
                where p.Login == login
                select new Position(p.X, p.Y)).ToList();

            return positions.Any() ? positions.First() : new Position(-1, -1);
        }

        public void Test()
        {

        }

        public Point GetPoint()
        {
            return new Point(5,5);
        }
    }
}