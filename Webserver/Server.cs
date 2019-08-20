namespace Webserver
{
    public class Server
    {
        private Http_Listener http_Listener;

        public Server()
        {
            http_Listener = new Http_Listener();
        }
        public void Run()
        {
            http_Listener.StartListening();
            http_Listener.OnConnectionReceived();
        }

    }
}
