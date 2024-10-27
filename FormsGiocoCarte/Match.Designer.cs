namespace FormsGiocoCarte
{
    partial class Match
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
            panel1 = new Panel();
            label5 = new Label();
            panel5 = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1948, 952);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(117, 417);
            label5.Name = "label5";
            label5.Size = new Size(142, 106);
            label5.TabIndex = 6;
            label5.Text = "VS";
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(label4);
            panel5.Location = new Point(1567, 375);
            panel5.Name = "panel5";
            panel5.Size = new Size(250, 233);
            panel5.TabIndex = 5;
            // 
            // label4
            // 
            label4.Location = new Point(12, 13);
            label4.Name = "label4";
            label4.Size = new Size(224, 204);
            label4.TabIndex = 0;
            label4.Text = "e il tuo turno\r\nadesso ti attacco\r\nseleziona carta\r\nseleziona nemico\r\nfase battaglia\r\nrisultati battaglia\r\nturno nemico";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SimSun", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1567, 328);
            label3.Name = "label3";
            label3.Size = new Size(93, 30);
            label3.TabIndex = 4;
            label3.Text = "Info:";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Location = new Point(560, 328);
            panel4.Name = "panel4";
            panel4.Size = new Size(929, 280);
            panel4.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Location = new Point(209, 661);
            panel2.Name = "panel2";
            panel2.Size = new Size(1596, 289);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SimSun", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 302);
            label2.Name = "label2";
            label2.Size = new Size(311, 40);
            label2.TabIndex = 1;
            label2.Text = "Nemico anonimo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 605);
            label1.Name = "label1";
            label1.Size = new Size(479, 40);
            label1.TabIndex = 0;
            label1.Text = "Tu (giocatore anonimo)";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Location = new Point(223, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(1596, 289);
            panel3.TabIndex = 3;
            // 
            // Match
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1972, 976);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Match";
            Text = "Match";
            Load += Match_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Panel panel5;
        private Label label4;
        private Label label3;
        private Panel panel4;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Panel panel3;
    }
}