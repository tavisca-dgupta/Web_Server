using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Webserver
{
    public class Http_Listener
    {
        private Socket _webServerSocket;
        private IPEndPoint _localEndPoint;
        private RequestDispatcher _requestDispatcher;

        public Http_Listener()
        {
            _requestDispatcher = new RequestDispatcher();
        }
        public Socket StartListening()
        {
            _webServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _localEndPoint = new IPEndPoint(IPAddress.Any, 8888);
            _webServerSocket.Bind(_localEndPoint);
            _webServerSocket.Listen(10);
            Console.WriteLine("Server started!!!!!!!!!");
            return _webServerSocket;
        }

        public void OnConnectionReceived()
        {
            try
            {
                new Thread(_ =>
                {
                    while (true)
                    {
                        Socket senderSocket = _webServerSocket.Accept();
                        Console.WriteLine("connected");
                        _requestDispatcher.Dispatch(senderSocket);
                        senderSocket.Shutdown(SocketShutdown.Both);
                        senderSocket.Close();
                    }
                }).Start();

            }
            catch (Exception)
            {
                Console.WriteLine("unable to connect to server");
            }
        }
    }
}
