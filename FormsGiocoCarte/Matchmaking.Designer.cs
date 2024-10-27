namespace FormsGiocoCarte
{
    partial class Matchmaking
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
            MatchmakingPicBox = new PictureBox();
            panel1 = new Panel();
            button2 = new Button();
            label1 = new Label();
            ServerPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MatchmakingPicBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ServerPnl
            // 
            ServerPnl.BorderStyle = BorderStyle.Fixed3D;
            ServerPnl.Controls.Add(button1);
            ServerPnl.Controls.Add(MatchmakingPicBox);
            ServerPnl.Location = new Point(33, 29);
            ServerPnl.Name = "ServerPnl";
            ServerPnl.Size = new Size(734, 392);
            ServerPnl.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("SimSun", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(202, 227);
            button1.Name = "button1";
            button1.Size = new Size(304, 97);
            button1.TabIndex = 1;
            button1.Text = "Join Matchmaking";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MatchmakingPicBox
            // 
            MatchmakingPicBox.Location = new Point(202, 16);
            MatchmakingPicBox.Name = "MatchmakingPicBox";
            MatchmakingPicBox.Size = new Size(304, 81);
            MatchmakingPicBox.TabIndex = 0;
            MatchmakingPicBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(33, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(734, 392);
            panel1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Font = new Font("SimSun", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(204, 230);
            button2.Name = "button2";
            button2.Size = new Size(304, 97);
            button2.TabIndex = 2;
            button2.Text = "Leave Matchmaking";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(278, 147);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(177, 28);
            label1.TabIndex = 0;
            label1.Text = "In queue...";
            // 
            // Matchmaking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 461);
            Controls.Add(panel1);
            Controls.Add(ServerPnl);
            Name = "Matchmaking";
            Text = "Matchmaking";
            Load += Matchmaking_Load;
            ServerPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MatchmakingPicBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ServerPnl;
        private PictureBox MatchmakingPicBox;
        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}