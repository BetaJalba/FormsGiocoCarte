using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FormsGiocoCarte
{
    internal class CServer
    {
        EndPoint remoteEndPoint;
        CClient socketToServer;
        public string players { get; private set; }

        public CServer(EndPoint remoteEndPoint) 
        {
            this.remoteEndPoint = remoteEndPoint;
            socketToServer = new CClient(remoteEndPoint, false);
            do
            {
                players = AutoSend("get players");
            } while (players == "-1");
        }

        private string AutoSend(string request)
        {
            socketToServer.Send(request);
            return socketToServer.GetLastListen();
        }

        public void Disconnect() 
        {
            socketToServer.Send("end connection");
        }
    }
}
