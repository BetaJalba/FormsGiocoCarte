namespace FormsGiocoCarte
{
    partial class ServerPanel
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            PlayerLbl = new Label();
            IpLbl = new Label();
            CountLbl = new Label();
            JoinBtn = new Button();
            SuspendLayout();
            // 
            // PlayerLbl
            // 
            PlayerLbl.AutoSize = true;
            PlayerLbl.Location = new Point(144, 58);
            PlayerLbl.Name = "PlayerLbl";
            PlayerLbl.Size = new Size(92, 20);
            PlayerLbl.TabIndex = 7;
            PlayerLbl.Text = "Players: 5/16";
            // 
            // IpLbl
            // 
            IpLbl.AutoSize = true;
            IpLbl.Location = new Point(3, 26);
            IpLbl.Name = "IpLbl";
            IpLbl.Size = new Size(109, 20);
            IpLbl.TabIndex = 6;
            IpLbl.Text = "IP: 192.168.10.1";
            // 
            // CountLbl
            // 
            CountLbl.AutoSize = true;
            CountLbl.Location = new Point(3, 6);
            CountLbl.Name = "CountLbl";
            CountLbl.Size = new Size(65, 20);
            CountLbl.TabIndex = 5;
            CountLbl.Text = "Server: 1";
            // 
            // JoinBtn
            // 
            JoinBtn.Location = new Point(144, 81);
            JoinBtn.Name = "JoinBtn";
            JoinBtn.Size = new Size(94, 29);
            JoinBtn.TabIndex = 4;
            JoinBtn.Text = "Join";
            JoinBtn.UseVisualStyleBackColor = true;
            JoinBtn.Click += JoinBtn_Click;
            // 
            // ServerPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PlayerLbl);
            Controls.Add(IpLbl);
            Controls.Add(CountLbl);
            Controls.Add(JoinBtn);
            Name = "ServerPanel";
            Size = new Size(241, 118);
            Load += ServerPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PlayerLbl;
        private Label IpLbl;
        private Label CountLbl;
        private Button JoinBtn;
    }
}
