using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FormsGiocoCarte
{
    public class CClient
    {
        protected Socket _clientSocket;
        public EndPoint _remoteEndPoint { get; set; }
        protected List<string> _listenHistory = new List<string>();
        private string message;
        private bool listenTask;
        byte[] receivedBuffer;

        public CClient(int port, bool listenTask)
        {
            this.listenTask = listenTask;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Start(port);
        }

        public CClient(EndPoint _remoteEndPoint, bool listenTask)
        {
            this.listenTask = listenTask;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._remoteEndPoint = _remoteEndPoint;
            LoopConnect(_remoteEndPoint);
        }

        private void Start(int port)
        {
            Console.WriteLine("Searching for server...\nSearching for server IP...");
            GetServerIPAndLocalEndPoint(port);
        }

        private void GetServerIPAndLocalEndPoint(int port)
        {
            string domain = "myserverhostgcarte.ddns.net";
            IPAddress[] addresses = Dns.GetHostAddresses(domain);
            string serverIp = string.Empty;

            foreach (var address in addresses)
            {
                serverIp += address.ToString();
            }

            Console.WriteLine("Server IP found!\nCreating remote endpoint...");

            _remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
            LoopConnect(_remoteEndPoint);
        }

        public void LoopConnect(EndPoint endPoint)
        {
            int attempts = 0;

            while (!_clientSocket.Connected && attempts < 16)
            {
                try
                {
                    Console.WriteLine($"Connection attempt {attempts}...");
                    _clientSocket.Connect(endPoint);
                }
                catch (SocketException)
                {
                    attempts++;
                    Task.Delay(500).Wait(); //aspetta prima di riprovare
                }
            }

            if (_clientSocket.Connected)
            {
                Console.WriteLine("Connected!");
                Listen();
            }
            else
                throw new SocketException();
        }

        public void Send(string request)
        {
            message = request;
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            _clientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallBack, _clientSocket);
            
        }

        private void SendCallBack(IAsyncResult ar) 
        {
            var socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

        private void Listen()
        {
            if (_clientSocket.Connected)
            {
                receivedBuffer = new byte[1024];
                _clientSocket.BeginReceive(receivedBuffer, 0, receivedBuffer.Length, SocketFlags.None, ReceiveCallBack, _clientSocket);
            }
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int receive = -1;
            try 
            {
                receive = socket.EndReceive(ar);
            }
            catch 
            {
                Console.WriteLine("Error, closing connection");
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }

            if (receive > 0)
            {
                byte[] data = new byte[receive];
                Array.Copy(receivedBuffer, data, receive); //non per riferimento
                _listenHistory.Add(Encoding.ASCII.GetString((byte[])data.Clone()));
                RefreshListenHistory();
            }

            Task.Delay(100).Wait();
            try
            {
                socket.BeginReceive(receivedBuffer, 0, receivedBuffer.Length, SocketFlags.None, ReceiveCallBack, _clientSocket);
            }
            catch
            {
                return;
            }
        }

        public string GetLastListen()
        {
            try
            {
                return _listenHistory[_listenHistory.Count - 1];
            }
            catch
            {
                return "-1";
            }
        }

        public string GetSecondToLastListen() 
        {
            try
            {
                return _listenHistory[_listenHistory.Count - 2];
            }
            catch
            {
                return "-1";
            }
        }

        private void RefreshListenHistory()
        {
            if (_listenHistory.Count > 4)
            {
                _listenHistory.RemoveAt(0);
            }
        }

        public bool Connected()
        {
            if (_clientSocket.Connected)
                return true;
            return false;
        }
    }
}
