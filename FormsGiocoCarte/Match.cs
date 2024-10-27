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

namespace FormsGiocoCarte
{
    public partial class Match : Form
    {
        public Match(EndPoint ep, int matchId)
        {
            gameEp = ep;
            this.matchId = matchId;
            InitializeComponent();
        }

        EndPoint gameEp;
        CClient client;
        int matchId;

        public CPersonaggio[] mazzo;
        public CPersonaggio[] mazzoNemico;

        List<string> nomiMaghi = new List<string> { "Ubaldo", "Gerry", "Cobra", "Tate", "Nasa", "Rennala", "Ranni", "Ren", "Seluvis", "Radahn" };
        List<string> nomiGuerrieri = new List<string> { "Pippo, Ippopotamo III", "Alexander", "Alexander suo figlio", "Malenia", "Sir. Gideon Ofnir", "NonSoComeScriverlo Loux", "Godfrey the other Grafted", "Soldier of God, Rick", "Meteorick Beast" };
        List<string> nomiArcieri = new List<string> { "Regina arcieri", "Arciere magico", "Levi", "Mikasa", "Eren", "Armin", "Adolfo", "Rudolfo", "Benito", "Giuseppe" };

        bool myTurn;

        private void Match_Load(object sender, EventArgs e)
        {
            client = new CClient(gameEp, true);
            client.Send(matchId.ToString());

            while (client.GetLastListen() == "-1" || !int.TryParse(client.GetLastListen(), out matchId)) 
            {
                Task.Delay(103).Wait(); 
            }

            mazzo = new CPersonaggio[10];
            GeneraMazzo(mazzo);
            mazzoNemico = GetMazzoNemico();
            DisegnaArena(mazzo, mazzoNemico);
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

        CPersonaggio[] GetMazzoNemico() 
        {
            Random rand = new Random();
            var jset = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

            //per rendere i messaggi più contenuti
            CPersonaggio[] primo = new CPersonaggio[5];
            CPersonaggio[] secondo = new CPersonaggio[5];

            Array.Copy(mazzo, primo, primo.Length);
            Array.Copy(mazzo, mazzo.Length / 2, secondo, 0, secondo.Length);

            Task.Delay(rand.Next(20000));

            client.Send($"{matchId}m:" + JsonConvert.SerializeObject(primo, Formatting.Indented, jset));
            Task.Delay(100);
            client.Send($"{matchId}m:" + JsonConvert.SerializeObject(secondo, Formatting.Indented, jset));

            while (!client.GetLastListen().Contains('[') || !client.GetSecondToLastListen().Contains('['))
                Task.Delay(150).Wait();

            CPersonaggio[] otherMazzo1 = JsonConvert.DeserializeObject<CPersonaggio[]>(client.GetSecondToLastListen(), jset);
            CPersonaggio[] otherMazzo2 = JsonConvert.DeserializeObject<CPersonaggio[]>(client.GetLastListen(), jset);

            return otherMazzo1.Union(otherMazzo2).ToArray();
        }

        void DisegnaArena(CPersonaggio[] mazzo, CPersonaggio[] mazzoNemico) 
        {
            Point myLocation = panel2.Location;
            Point enemyLocation = panel3.Location;

            int k = 0;
            foreach (CPersonaggio personaggio in mazzo) 
            {
                Card carta = new Card(personaggio);
                carta.Parent = panel2;
                carta.Location = new Point(myLocation.X + 10 + k, myLocation.Y + 10);
                k += carta.Width + 10;
            }
            k = 0;
            foreach (CPersonaggio personaggio in mazzoNemico) 
            {
                Card carta = new Card(personaggio);
                carta.Parent = panel3;
                carta.Location = new Point(enemyLocation.X + 10 + k, enemyLocation.Y + 10);
                k += carta.Width + 10;
            }
        }
    }
}
