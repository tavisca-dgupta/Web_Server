using System;
using System.Linq;
using System.Net.Sockets;
using Webserver;
using Xunit;

namespace TestWebserver
{
    public class TestWebApp
    {
        [Fact]
        public void Test_Process_Request_And_Send_Response()
        {
            Socket senderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            WebApp webApp = new WebApp("/google.com", "C://WebPages/google", senderSocket);

        }
    }

}
