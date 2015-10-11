#region

using System;
using System.ServiceModel;
using WcfService;

#endregion

namespace HostConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof (ServiceGame)))
            {
                host.Open();
                Console.WriteLine("Start server");
                Console.WriteLine("==========================");

                Console.ReadLine();
                host.Close();
            }
        }
    }
}