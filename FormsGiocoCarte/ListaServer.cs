﻿using System;
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

namespace FormsGiocoCarte
{
    public partial class ListaServer : Form
    {
        public ListaServer()
        {
            InitializeComponent();
        }

        private void ListaServer_Load(object sender, EventArgs e)
        {
            LoadForm();
            InizializeServerList();
        }

        private void LoadForm()
        {
            string images;

            //form
            images = PathToImages() + @"\yugiohbackgroundmain.jpg";
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile(images);

            //picture boxes
            images = PathToImages() + @"\serverlistmain.png";
            ServerListPicBox.BackColor = Color.FromArgb(0, 255, 255, 255);
            ServerListPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ServerListPicBox.ImageLocation = images;
        }

        private string PathToImages()
        {
            DirectoryInfo tempDirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            return tempDirInfo.Parent.Parent.Parent.FullName + @"\Resources\Images";
        }
        private string PathToFiles()
        {
            DirectoryInfo tempDirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            return tempDirInfo.Parent.Parent.Parent.FullName + @"\Resources\Files";
        }

        List<string> serverIps;
        private void InizializeServerList()
        {
            CUser ServerListClient = new CUser();

            string filepath = PathToFiles() + @"\ServerList.json";

            File.Create(filepath).Close();

            Task.Delay(250).Wait();
            ServerListClient.Send(ComandiServer.GetServers, "");
            File.WriteAllText(filepath, ServerListClient.GetLastListen());
            ServerListClient.Send(ComandiServer.Disconnect, "");

            serverIps = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(filepath)); //il verdino mente come al solito

            int startingHeight = 10;
            int padding = 10;

            for (int i = 0; i < serverIps.Count; i++)
            {
                ServerPanel tempPanel = new ServerPanel(new IPEndPoint(IPAddress.Parse(serverIps[i].Split([':'])[0]), int.Parse(serverIps[i].Split([':'])[1])), i + 1);
                tempPanel.Parent = ServPnl;
                tempPanel.Location = new Point(padding, startingHeight);
                startingHeight += tempPanel.Height + 10;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = ServPnl.Controls.Count - 1; i >= 0; i--)
            {
                ServPnl.Controls[i].Dispose();
            }

            InizializeServerList();
        }
    }
}
