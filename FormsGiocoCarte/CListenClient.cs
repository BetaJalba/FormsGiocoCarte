using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace FormsGiocoCarte
{
    public class CListenClient : CSendClient
    {
        byte[] buffer;

        public IPEndPoint EndPoint
        {
            get
            {
                if (Socket != null && Socket.Connected)
                    return (IPEndPoint)Socket.RemoteEndPoint;
                return new IPEndPoint(IPAddress.None, 0);
            }
        }

        public delegate void DisconnectedEventHandler(CListenClient sender); //handler per gli eventi
        public event DisconnectedEventHandler Disconnected;
        public delegate void ReceivedEventHandler(byte[] message, CListenClient e);
        public event ReceivedEventHandler OnReceive;

        public CListenClient()
        {
            buffer = new byte[4096];
        }

        public void Close()
        {
            if (Socket != null)
            {
                Socket.Disconnect(false);
                Socket.Close();
            }
        }

        public void ReceiveAsync()
        {
            Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receiveCallBack, Socket);
        }

        private void receiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket s = (Socket)ar.AsyncState;
                int rec = s.EndReceive(ar);

                if (rec == 0)
                {
                    if (Disconnected != null)
                    {
                        buffer = new byte[4096];
                        Disconnected(this);
                        return;
                    }
                }
                else if (OnReceive != null)
                {
                    OnReceive(buffer, this);
                }

                buffer = new byte[4096];
                s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, receiveCallBack, s);
            }
            catch (SocketException e)
            {
                switch (e.SocketErrorCode)
                {
                    case SocketError.ConnectionAborted:
                    case SocketError.ConnectionReset:
                        if (Disconnected != null)
                        {
                            Disconnected(this);
                            return;
                        }
                        break;
                }
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (NullReferenceException)
            {
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
