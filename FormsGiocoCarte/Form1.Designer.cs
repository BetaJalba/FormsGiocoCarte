namespace FormsGiocoCarte
{
    partial class ServerMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            MultiBtn = new Button();
            SingleBtn = new Button();
            LogoSecondaryPicBox = new PictureBox();
            LogoPicBox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoSecondaryPicBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoPicBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(MultiBtn);
            panel1.Controls.Add(SingleBtn);
            panel1.Controls.Add(LogoSecondaryPicBox);
            panel1.Controls.Add(LogoPicBox);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 426);
            panel1.TabIndex = 0;
            // 
            // MultiBtn
            // 
            MultiBtn.Font = new Font("SimSun", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MultiBtn.Location = new Point(590, 262);
            MultiBtn.Name = "MultiBtn";
            MultiBtn.Size = new Size(166, 81);
            MultiBtn.TabIndex = 3;
            MultiBtn.Text = "Multi\r\nplayer";
            MultiBtn.UseVisualStyleBackColor = true;
            MultiBtn.Click += MultiBtn_Click;
            // 
            // SingleBtn
            // 
            SingleBtn.Font = new Font("SimSun", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SingleBtn.Location = new Point(590, 117);
            SingleBtn.Name = "SingleBtn";
            SingleBtn.Size = new Size(166, 81);
            SingleBtn.TabIndex = 2;
            SingleBtn.Text = "Single\r\nplayer";
            SingleBtn.UseVisualStyleBackColor = true;
            SingleBtn.Click += SingleBtn_Click;
            // 
            // LogoSecondaryPicBox
            // 
            LogoSecondaryPicBox.Location = new Point(304, 190);
            LogoSecondaryPicBox.Name = "LogoSecondaryPicBox";
            LogoSecondaryPicBox.Size = new Size(256, 144);
            LogoSecondaryPicBox.TabIndex = 1;
            LogoSecondaryPicBox.TabStop = false;
            // 
            // LogoPicBox
            // 
            LogoPicBox.BackgroundImageLayout = ImageLayout.None;
            LogoPicBox.Location = new Point(15, 48);
            LogoPicBox.Name = "LogoPicBox";
            LogoPicBox.Size = new Size(545, 333);
            LogoPicBox.TabIndex = 0;
            LogoPicBox.TabStop = false;
            // 
            // ServerMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "ServerMenu";
            Text = "ServerMenu";
            Load += ServerMenu_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoSecondaryPicBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox LogoPicBox;
        private PictureBox LogoSecondaryPicBox;
        private Button MultiBtn;
        private Button SingleBtn;
    }
}
