using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Clients;
using GameServer;

namespace FormsGiocoCarte
{
    public partial class Match : Form
    {
        public Match(EndPoint ep, int matchId)
        {
            gameEp = ep;
            this.matchId = matchId;
            client = new CUser(gameEp as IPEndPoint, matchId);
            client.OnUpdate += Client_OnUpdate;
            Task.Delay(500).Wait();
            InitializeComponent();
        }

        EndPoint gameEp;
        CUser client;
        int matchId;

        public CPersonaggio[]? mazzo;
        public CPersonaggio[]? mazzoNemico;

        List<string> nomiMaghi = new List<string> { "Ubaldo", "Gerry", "Cobra", "Tate", "Nasa", "Rennala", "Ranni", "Ren", "Seluvis", "Radahn" };
        List<string> nomiGuerrieri = new List<string> { "Pippo, Ippopotamo III", "Alexander", "Alexander suo figlio", "Malenia", "Sir. Gideon Ofnir", "NonSoComeScriverlo Loux", "Godfrey the other Grafted", "Soldier of God, Rick", "Meteorick Beast" };
        List<string> nomiArcieri = new List<string> { "Regina arcieri", "Arciere magico", "Levi", "Mikasa", "Eren", "Armin", "Adolfo", "Rudolfo", "Benito", "Giuseppe" };

        bool myTurn;

        private void Match_Load(object sender, EventArgs e)
        {
            mazzo = new CPersonaggio[10];
            GeneraMazzo(mazzo);
            mazzoNemico = GetMazzoNemico();
            DisegnaArena(mazzo, mazzoNemico);
            Partita(client.Starts);
        }

        bool scelto;
        string nomeScelto;

        async void Partita(bool starts) 
        {
            if (starts) 
            {
                //sceglie 2 carte
                scelto = false;
                label4.Text = "Scegli la prima carta, inizi tu!";

                int index1 = -1;

                do
                {
                    await CompletedNome(); //attende che venga scelto
                    index1 = -1;
                    for (int i = 0; i < 10; i++)
                        if (mazzo[i].nome == nomeScelto)
                            index1 = i;
                } while (index1 == -1 || !mazzo[index1].e_vivo());

                label4.Text = "Scegli la seconda carta!";

                int index2;

                do
                {
                    await CompletedNome(); //attende che venga scelto
                    index2 = -1;
                    for (int i = 0; i < 10; i++)
                        if (mazzoNemico[i].nome == nomeScelto)
                            index1 = i;
                } while (index1 == -1 || !mazzoNemico[index2].e_vivo());

                //manda messaggio

                // Comando attacco | Indice match | Indice Attaccante | Indice Difensore
                client.Send(ComandiMatch.SendMove, $"{client.MatchId}{index1}{index2}");
            }
        }

        private void Client_OnUpdate(int mazzo, int personaggio, int attaccante)
        {
            if (mazzo == 1) 
            {
                this.mazzo[personaggio].punti_vita -= mazzoNemico[attaccante].attacca();
            }
            else if (mazzo == 2) 
            {
                mazzoNemico[personaggio].punti_vita = this.mazzo[attaccante].attacca();
            }

            // controllo vincita
            bool vivo1 = false, vivo2 = false;
            for (int i = 0; i < 10; i++)
            {
                if (this.mazzo[i].e_vivo())
                    vivo1 = true;
                if (mazzoNemico[i].e_vivo())
                    vivo2 = true;
            }

            if (!vivo1)
            {
                //giocatore 2 vince
            }
            else if (!vivo2)
            {
                //giocatore 1 vince
            }
        }

        public Task CompletedNome()
        {
            return Task.CompletedTask;
        }

        void GeneraMazzo(CPersonaggio[] mazzo)
        {
            Random random = new Random();
            int scelta; //scelta nome

            for (int i = 0; i < mazzo.Length; i++)
            {
                switch (random.Next(3))
                {
                    case 0:
                        scelta = random.Next(nomiGuerrieri.Count);
                        mazzo[i] = new CGuerriero(nomiGuerrieri[scelta]);
                        nomiGuerrieri.RemoveAt(scelta);
                        break;
                    case 1:
                        scelta = random.Next(nomiMaghi.Count);
                        mazzo[i] = new CMago(nomiMaghi[scelta]);
                        nomiMaghi.RemoveAt(scelta);
                        break;
                    case 2:
                        scelta = random.Next(nomiArcieri.Count);
                        mazzo[i] = new CArciere(nomiArcieri[scelta]);
                        nomiArcieri.RemoveAt(scelta);
                        break;
                    default:
                        scelta = random.Next(nomiMaghi.Count);
                        mazzo[i] = new CMago(nomiMaghi[scelta]);
                        nomiMaghi.RemoveAt(scelta);
                        break;
                }
            }
        }

        CPersonaggio[]? GetMazzoNemico() 
        {
            Random rand = new Random();
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            //_per rendere i messaggi più contenuti_ NO AHAHAH SPEDISCO TUTTO
            CPersonaggio[]? otherMazzo = new CPersonaggio[10];

            client.Send(ComandiMatch.SendDeck, client.MatchId.ToString("0") + JsonConvert.SerializeObject(mazzo, Formatting.Indented, jset));
            Task.Delay(100).Wait();
            otherMazzo = JsonConvert.DeserializeObject<CPersonaggio[]>(client.GetLastListen(), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return otherMazzo;
        }

        void DisegnaArena(CPersonaggio[] mazzo, CPersonaggio[] mazzoNemico) 
        {

            int k = 0;
            foreach (CPersonaggio personaggio in mazzo) 
            {
                Card carta = new Card(personaggio);
                carta.Click += Carta_Click;
                carta.Parent = panel2;
                carta.Location = new Point(5 + k, 13);
                k += carta.Width + 10;
            }
            k = 0;
            foreach (CPersonaggio personaggio in mazzoNemico) 
            {
                Card carta = new Card(personaggio);
                carta.Click += CartaNemica_Click;
                carta.Parent = panel3;
                carta.Location = new Point(5 + k, 13);
                k += carta.Width + 10;
            }
        }

        private void Carta_Click(object? sender, EventArgs e)
        {
            if (scelto)
                return;
            nomeScelto = (sender as Card).Name;
            scelto = true;
            CompletedNome();
        }

        private void CartaNemica_Click(object? sender, EventArgs e)
        {
            if (!scelto)
                return;
            nomeScelto = (sender as Card).Name;
            scelto = false;
            CompletedNome();
        }
    }
}
