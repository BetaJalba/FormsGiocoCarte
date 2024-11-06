using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsGiocoCarte
{
    public partial class Card : UserControl
    {
        CPersonaggio personaggio { get; set; }
        public Card(CPersonaggio personaggio)
        {
            this.personaggio = personaggio;
            //LoadCard();
            InitializeComponent();
        }

        private void LoadCard()
        {
            if (personaggio is CGuerriero)
                pictureBox1.Image = Image.FromFile(PathToImages() + @"\cardknight.png");
            else if (personaggio is CArciere)
                pictureBox1.Image = Image.FromFile(PathToImages() + @"\cardbowman.png");
            else
                pictureBox1.Image = Image.FromFile(PathToImages() + @"\cardmage.png");

            AtkLbl.Text = personaggio.attacca().ToString(); //no, non gestisco il caso in cui il mago faccia tanto danno per favore no nonoonnoooO
            HpLbl.Text = personaggio.punti_vita.ToString();
            label2.Text = personaggio.nome.ToString();
        }
        private void Card_Load(object sender, EventArgs e)
        {
            LoadCard();
        }

        private string PathToImages()
        {
            DirectoryInfo tempDirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            return tempDirInfo.Parent.Parent.Parent.FullName + @"\Resources\Images";
        }

        public void UpdateValues()
        {
            HpLbl.Text = personaggio.getVita().ToString();
        }

        public void PrendiDanno(int danno)
        {
            personaggio.ricevi_danno(danno);
        }

        public int Attacca()
        {
            return personaggio.attacca();
        }

        public bool eVivo()
        {
            if (personaggio.e_vivo())
                return true;
            return false;
        }
    }
}
