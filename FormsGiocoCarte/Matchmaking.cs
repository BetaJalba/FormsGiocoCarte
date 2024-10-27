using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormsGiocoCarte
{
    public partial class Matchmaking : Form
    {
        public Matchmaking(EndPoint ep)
        {
            InitializeComponent();
            serverEp = ep;
        }

        private async void Matchmaking_Load(object sender, EventArgs e)
        {
            LoadForm();
            SetupClient();
            await Task.Run(checkIfPaired);
            CreaMatch();
        }

        EndPoint serverEp;
        CClient client;
        string newPort;
        private Task checkIfPaired() 
        {
            while (true && !client.GetLastListen().Contains("port:"))
            {
                Task.Delay(200);
            }

            newPort = client.GetLastListen();

            serverEp = new IPEndPoint((serverEp as IPEndPoint).Address, int.Parse(newPort.Substring(6, 5)));
            client.Send("end connection");

            return Task.FromResult(0);
        }

        private void CreaMatch() 
        {
            label1.Text = "Opponent trovato!!\nIngresso match...";

            Task.Delay(1000).Wait();
            Match match = new Match(serverEp, int.Parse(newPort.Substring(0,1)));
            match.ShowDialog();
        }

        private void SetupClient()
        {
            client = new CClient(serverEp, true);
        }

        private void LoadForm()
        {
            string images;

            //form
            images = PathToImages() + @"\yugiohbackgroundmain.jpg";
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile(images);

            //panel
            ServerPnl.BackColor = Color.FromArgb(150, 20, 0, 50);
            panel1.BackColor = Color.FromArgb(150, 20, 0, 50);
            panel1.Visible = false;

            //label
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);

            //picture boxes
            images = PathToImages() + @"\matchmakingmain.png";
            MatchmakingPicBox.BackColor = Color.FromArgb(0, 255, 255, 255);
            MatchmakingPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MatchmakingPicBox.ImageLocation = images;
        }

        private string PathToImages()
        {
            DirectoryInfo tempDirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            return tempDirInfo.Parent.Parent.Parent.FullName + @"\Resources\Images";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Send("leave queue");
            ServerPnl.Visible = true;
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Send("enter queue");
            ServerPnl.Visible = false;
            panel1.Visible = true;
        }
    }
}
