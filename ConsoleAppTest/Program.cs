#region

using System;
using System.Windows.Media;
using ConsoleAppTest.ServiceReference1;

#endregion

namespace ConsoleAppTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start");
            using (ServiceGameClient _client = new ServiceGameClient("WSDualHttpBinding_IServiceGame"))
            {

                _client.Open();
                Console.WriteLine("Connected to server.");

                Console.WriteLine("Enter your login:");
                string login = Console.ReadLine();
                _client.Login(login, Colors.Red);
                _client.SendCoord(5, 5);

                bool dontExit = true;
                while (dontExit)
                {
                    string command = string.Empty;
                    command = Console.ReadLine();
                    switch(command)
                    {
                        case "update":
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Players on server:");
                            foreach (Player player in _client.GetAllPlayers())
                            {
                                Console.WriteLine(player.Login);
                            }
                            break;
                        case "exit":
                            dontExit = false;
                            break;
                        default:
                            break;
                    }
                    
                }






                _client.Close();
            }




            /*
            using (ServiceGameClient _client = new ServiceGameClient("WSDualHttpBinding_IServiceGame"))
            {
                _client.Open();
                _client.Login("System", Colors.Yellow);
                _client.SendCoord(20, 20);
                foreach (Player player in _client.GetAllPlayers())
                {
                    Console.WriteLine(player.Login);
                }
                _client.GetPositionPlayer("Dante");
                _client.Close();
            }

            */


            Console.ReadLine();

        }
    }
}