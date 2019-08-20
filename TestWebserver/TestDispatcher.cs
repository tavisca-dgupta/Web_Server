using System;
using System.Net;
using System.Net.Sockets;
using Webserver;
using Xunit;

namespace TestWebserver
{
    public class TestDispatcher
    {
        [Fact]
        public void Test_When_Website_Added_To_WebAppMap()
        {
            //arrange
            RequestDispatcher dispatcher = new RequestDispatcher();
            Socket _webServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint _localEndPoint = new IPEndPoint(IPAddress.Any, 8080);
            _webServerSocket.Bind(_localEndPoint);
            _webServerSocket.Listen(10);
            Socket senderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //assert
            Assert.False(dispatcher.Dispatch(senderSocket));


        }
    }

}
