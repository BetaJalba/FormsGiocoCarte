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
using Clients;

namespace FormsGiocoCarte
{
    public partial class ServerPanel : UserControl
    {
        EndPoint endPoint;
        int count;
        public ServerPanel(EndPoint endPoint, int count)
        {
            this.endPoint = endPoint;
            this.count = count;

            InitializeComponent();
        }

        private async void ServerPanel_Load(object sender, EventArgs e)
        {
            CountLbl.Text = count.ToString();
            IpLbl.Text = (endPoint as IPEndPoint).Address.ToString();
        }

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            Matchmaking matchmaking = new Matchmaking(endPoint);
            matchmaking.ShowDialog();
        }
    }
}
