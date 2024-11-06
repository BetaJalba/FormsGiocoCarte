using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Clients;

namespace FormsGiocoCarte
{
    public class CSendClient
    {
        public delegate void OnConnectEventHandler(CSendClient sender, bool connected);
        public event OnConnectEventHandler? OnConnect;

        public delegate void OnSendEventHandler(CSendClient sender, int sent);
        public event OnSendEventHandler? OnSend;

        public delegate void OnDisconnectEventHandler(CSendClient sender);
        public event OnDisconnectEventHandler? OnDisconnect;

        public Socket? Socket; //socket del mittente

        public bool Connected
        {
            get
            {
                if (Socket != null)
                    return Socket.Connected;
                return false;
            }
        }

        public CSendClient()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ipAddress, int port)
        {
            if (Socket == null)
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Socket.BeginConnect(ipAddress, port, connectCallBack, null);
        }

        void connectCallBack(IAsyncResult ar)
        {
            try
            {
                Socket.EndConnect(ar);

                if (OnConnect != null)
                    OnConnect(this, Connected);
            }
            catch { }
        }

        public void Send(ComandiClient command, string data)
        {
            byte[] toSend = Encoding.ASCII.GetBytes((int)command + data);
            Socket.BeginSend(toSend, 0, toSend.Length, SocketFlags.None, sendCallBack, Socket);
        }

        public void Send(ComandiServer command, string data)
        {
            byte[] toSend = Encoding.ASCII.GetBytes((int)command + data);
            Socket.BeginSend(toSend, 0, toSend.Length, SocketFlags.None, sendCallBack, Socket);
        }

        public void Send(ComandiMatch command, string data)
        {
            byte[] toSend = Encoding.ASCII.GetBytes((int)command + data);
            Socket.BeginSend(toSend, 0, toSend.Length, SocketFlags.None, sendCallBack, Socket);
        }

        void sendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket s = (Socket)ar.AsyncState;
                int sent = s.EndSend(ar);

                if (OnSend != null)
                    OnSend(this, sent);
            }
            catch (Exception e)
            {
                Console.WriteLine("Send error! " + e.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Socket != null && Socket.Connected)
                {
                    Socket.Shutdown(SocketShutdown.Both);
                    Socket.Close();
                    Socket = null;

                    if (OnDisconnect != null)
                    {
                        OnDisconnect(this);
                    }
                }
            }
            catch { }
        }
    }
}
