namespace FormsGiocoCarte
{
    partial class Card
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            HpLbl = new Label();
            AtkLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = Properties.Resources.cardbowman;
            pictureBox1.Location = new Point(13, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 132);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Nome:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.cardhp;
            pictureBox2.Location = new Point(0, 175);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 73);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.cardatk;
            pictureBox3.Location = new Point(73, 172);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(77, 73);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 152);
            label2.Name = "label2";
            label2.Size = new Size(131, 20);
            label2.TabIndex = 4;
            label2.Text = "Gandalf Maestro II";
            // 
            // HpLbl
            // 
            HpLbl.AutoSize = true;
            HpLbl.BorderStyle = BorderStyle.Fixed3D;
            HpLbl.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HpLbl.Location = new Point(13, 196);
            HpLbl.Name = "HpLbl";
            HpLbl.Size = new Size(50, 27);
            HpLbl.TabIndex = 5;
            HpLbl.Text = "100";
            HpLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AtkLbl
            // 
            AtkLbl.AutoSize = true;
            AtkLbl.BorderStyle = BorderStyle.Fixed3D;
            AtkLbl.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AtkLbl.Location = new Point(93, 196);
            AtkLbl.Name = "AtkLbl";
            AtkLbl.Size = new Size(38, 27);
            AtkLbl.TabIndex = 6;
            AtkLbl.Text = "30";
            AtkLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Card
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AtkLbl);
            Controls.Add(HpLbl);
            Controls.Add(label2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Card";
            Size = new Size(150, 245);
            Load += Card_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label2;
        private Label HpLbl;
        private Label AtkLbl;
    }
}
