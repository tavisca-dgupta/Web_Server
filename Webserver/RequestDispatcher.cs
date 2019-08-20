﻿using System.Net.Sockets;
using System.Text;

namespace Webserver
{
    public class RequestDispatcher
    {
        private WebApp _webApp;
        private WebAppList _webAppMap;
        public RequestDispatcher()
        {
            _webAppMap = new WebAppList();
        }
        public bool Dispatch(Socket senderSocket)
        {
            NetworkStream communicationChannel = new NetworkStream(senderSocket);
            byte[] byteData = new byte[1024];
            int byteDataCount = communicationChannel.Read(byteData, 0, byteData.Length);
            string request = Encoding.ASCII.GetString(byteData, 0, byteDataCount);
            string[] requestTokens = HttpRequestParser.RequestParser(request);
            string[] suburls = requestTokens[1].Split('/');
            if (suburls[1].Equals("Api"))
            {
                RestApi.SendResponse(request, requestTokens, senderSocket);
                return true;
            }
            else if (_webAppMap.IsWebAppPresent(suburls[1]))
            {
                _webApp = new WebApp("/" + suburls[1], _webAppMap.GetRootDirectory(suburls[1]), senderSocket);
                _webApp.HandleRequest(requestTokens[1]);
                return true;
            }
            else
            {
                Error.PageNotFoundError(senderSocket);
                return false;
            }
        }
    }
}
