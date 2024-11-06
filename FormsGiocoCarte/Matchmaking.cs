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
using Clients;

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
        }

        EndPoint serverEp;
        CUser client;

        public void CreaMatch(int matchId, int port) 
        {
            //label1.Text = "Opponent trovato!!\nIngresso match...";

            serverEp = new IPEndPoint((serverEp as IPEndPoint).Address, port);
            Match match = new Match(serverEp, matchId);
            match.ShowDialog();
        }

        private void SetupClient()
        {
            client = new CUser(serverEp as IPEndPoint);
            client.OnNewMatch += CreaMatch;
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
            client.Send(ComandiServer.LeaveQueue, "");
            ServerPnl.Visible = true;
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Send(ComandiServer.EnterQueue, "");
            ServerPnl.Visible = false;
            panel1.Visible = true;
        }
    }
}
