namespace FormsGiocoCarte
{
    partial class ListaServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ServerPnl = new Panel();
            button1 = new Button();
            ServPnl = new Panel();
            ServerListPicBox = new PictureBox();
            ServerPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ServerListPicBox).BeginInit();
            SuspendLayout();
            // 
            // ServerPnl
            // 
            ServerPnl.BorderStyle = BorderStyle.Fixed3D;
            ServerPnl.Controls.Add(button1);
            ServerPnl.Controls.Add(ServPnl);
            ServerPnl.Controls.Add(ServerListPicBox);
            ServerPnl.Location = new Point(35, 26);
            ServerPnl.Name = "ServerPnl";
            ServerPnl.Size = new Size(734, 392);
            ServerPnl.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(79, 170);
            button1.Name = "button1";
            button1.Size = new Size(198, 81);
            button1.TabIndex = 2;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ServPnl
            // 
            ServPnl.BorderStyle = BorderStyle.Fixed3D;
            ServPnl.Location = new Point(373, 140);
            ServPnl.Name = "ServPnl";
            ServPnl.Size = new Size(349, 241);
            ServPnl.TabIndex = 1;
            // 
            // ServerListPicBox
            // 
            ServerListPicBox.Location = new Point(202, 16);
            ServerListPicBox.Name = "ServerListPicBox";
            ServerListPicBox.Size = new Size(304, 74);
            ServerListPicBox.TabIndex = 0;
            ServerListPicBox.TabStop = false;
            // 
            // ListaServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 441);
            Controls.Add(ServerPnl);
            Name = "ListaServer";
            Text = "ListaServer";
            Load += ListaServer_Load;
            ServerPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ServerListPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ServerPnl;
        private PictureBox ServerListPicBox;
        private Panel ServPnl;
        private Button button1;
    }
}