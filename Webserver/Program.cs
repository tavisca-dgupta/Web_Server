using System;
using System.Threading.Tasks;

namespace Webserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Server server = new Server();
            server.Run();
            Console.ReadKey();
        }
    }
}
