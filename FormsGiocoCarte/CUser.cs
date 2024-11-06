using Clients;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FormsGiocoCarte
{
    public class CUser
    {
        CListenClient client;
        int port = 32850;
        int matchId = 0;

        List<string> readHistory;
        public bool Starts;

        public delegate void NewMatchHandler(int matchId, int port);
        public event NewMatchHandler? OnNewMatch;
        public delegate void UpdateHanlder(int mazzo, int personaggio, int attaccante);
        public event UpdateHanlder? OnUpdate;

        public CUser()
        {
            readHistory = new List<string>(4);
            Starts = false;
            IPEndPoint endPoint = GetServerIPAndLocalEndPoint(port);
            client = new CListenClient();
            client.Connect(endPoint.Address.ToString(), endPoint.Port);

            client.OnReceive += Client_OnReceive;
            client.OnConnect += Client_OnConnect;
            client.OnDisconnect += Client_OnDisconnect;
            client.Disconnected += (sender) =>
            {
                sender.Disconnect();
            };
        }

        public CUser(IPEndPoint ep) 
        {
            readHistory = new List<string>(4);
            Starts = false;
            client = new CListenClient();
            client.Connect(ep.Address.ToString(), ep.Port);

            client.OnReceive += Client_OnReceive;
            client.OnConnect += Client_OnConnect;
            client.OnDisconnect += Client_OnDisconnect;
            client.Disconnected += (sender) =>
            {
                sender.Disconnect();
            };
        }

        public CUser(IPEndPoint ep, int matchId)
        {
            readHistory = new List<string>(4);
            this.matchId = matchId;
            client = new CListenClient();
            client.Connect(ep.Address.ToString(), ep.Port);

            client.OnReceive += Client_OnReceive;
            client.OnConnect += Client_OnConnect;
            client.OnDisconnect += Client_OnDisconnect;
            client.Disconnected += (sender) =>
            {
                sender.Disconnect();
            };
        }

        public int MatchId 
        {
            get { return matchId; }
            set { matchId = value; }
        }

        public string GetLastListen() 
        {
            Task.Delay(100).Wait();
            return readHistory[readHistory.Count - 1].ToString();
        }

        public void Send(ComandiServer comando, string message) 
        {
            client.Send(comando, message);
            Task.Delay(50).Wait();
        }

        public void Send(ComandiMatch comando, string message) 
        {
            client.Send(comando, message);
            Task.Delay(50).Wait();
        }

        private void Client_OnDisconnect(CSendClient sender)
        {
            Console.WriteLine("Client disconnesso!");
        }

        private void Client_OnReceive(byte[] message, CListenClient e)
        {
            ComandiClient comando = (ComandiClient)int.Parse(Encoding.ASCII.GetString(message).Substring(0, 1));
            string messaggio = Encoding.ASCII.GetString(message).Substring(1);

            Console.WriteLine($"Ricevuto comando: {comando}");

            //risposta base
            ComandiServer comandoRisposta = ComandiServer.Info;
            string messaggioRisposta = string.Empty;
            bool useBase = true;

            switch (comando)
            {
                case ComandiClient.Reconnect:
                    matchId = int.Parse(messaggio.Split([':'])[1]);
                    e.Disconnect();
                    OnNewMatch?.Invoke(matchId, int.Parse(messaggio.Split([':'])[3]));
                    MessageBox.Show("scattato!");
                    e.Connect(messaggio.Split([':'])[2], int.Parse(messaggio.Split([':'])[3]));
                    break;
                case ComandiClient.GetMatchId:
                    comandoRisposta = (ComandiServer)ComandiMatch.ConnectMatch;
                    messaggioRisposta = matchId.ToString();
                    useBase = false;
                    break;
                case ComandiClient.PartitaCreata:
                    //partita creata
                    Console.WriteLine("Partita creata!");
                    break;
                case ComandiClient.SendMatchId:
                    matchId = int.Parse(messaggio);
                    break;
                case ComandiClient.DecideStarts:
                    Starts = Convert.ToBoolean(Convert.ToInt16(messaggio));
                    break;
                case ComandiClient.UpdateGame:
                    OnUpdate?.Invoke(int.Parse(messaggio.Substring(0, 1)), int.Parse(messaggio.Substring(1, 1)), int.Parse(messaggio.Substring(2)));
                    break;
                case ComandiClient.Info:
                    readHistory.Add(Encoding.ASCII.GetString(message).Substring(1));
                    break;
            }

            if (messaggioRisposta.Length > 0)
            {
                if (useBase)
                    e.Send(comandoRisposta, messaggioRisposta);
                else
                    e.Send((ComandiMatch)comandoRisposta, messaggioRisposta);
            }
        }

        private void Client_OnConnect(CSendClient sender, bool connected)
        {
            if (connected)
            {
                client.Send(ComandiServer.Info, "Ciao");
                client.ReceiveAsync();
            }
        }

        private IPEndPoint GetServerIPAndLocalEndPoint(int port)
        {
            string domain = "myserverhostgcarte.ddns.net";
            IPAddress[] addresses = Dns.GetHostAddresses(domain);
            string serverIp = string.Empty;

            foreach (var address in addresses)
            {
                serverIp += address.ToString();
            }

            Console.WriteLine("Server IP found!\nCreating remote endpoint...");

            return new IPEndPoint(IPAddress.Parse(serverIp), port);
        }
    }
}
