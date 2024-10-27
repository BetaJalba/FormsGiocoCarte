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

namespace FormsGiocoCarte
{
    public partial class ServerPanel : UserControl
    {
        EndPoint endPoint;
        CServer server;
        int count;
        public ServerPanel(EndPoint endPoint, int count)
        {
            this.endPoint = endPoint;
            server = new CServer(endPoint);
            this.count = count;

            InitializeComponent();
        }

        private void ServerPanel_Load(object sender, EventArgs e)
        {
            CountLbl.Text = count.ToString();
            IpLbl.Text = (endPoint as IPEndPoint).Address.ToString();
            PlayerLbl.Text = server.players + "/16"; //ogni server ha max 16 giocatori
            server.Disconnect();
        }

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            Matchmaking matchmaking = new Matchmaking(endPoint);
            matchmaking.ShowDialog();
        }
    }
}
