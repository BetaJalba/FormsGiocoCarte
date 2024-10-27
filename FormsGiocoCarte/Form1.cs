namespace FormsGiocoCarte
{
    public partial class ServerMenu : Form
    {
        public ServerMenu()
        {
            InitializeComponent();
        }

        private void ServerMenu_Load(object sender, EventArgs e)
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

            //panel
            panel1.BackColor = Color.FromArgb(150, 20, 0, 50);

            //picture boxes
            images = PathToImages() + @"\yugiohlogomain.png";
            LogoPicBox.BackColor = Color.FromArgb(0, 255, 255, 255);
            LogoPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoPicBox.ImageLocation = images;

            images = PathToImages() + @"\yugiohlogosecondary.png";
            LogoSecondaryPicBox.Parent = LogoPicBox;
            LogoSecondaryPicBox.BackColor = Color.FromArgb(0, 255, 255, 255);
            LogoSecondaryPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //LogoSecondaryPicBox.BackgroundImageLayout = ImageLayout.Stretch;
            LogoSecondaryPicBox.ImageLocation = images;
        }

        private string PathToImages()
        {
            DirectoryInfo tempDirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            return tempDirInfo.Parent.Parent.Parent.FullName + @"\Resources\Images";
        }

        private void InizializeServerList()
        {

        }

        private void SingleBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Non sei venuto per questo\naka non ancora supportato");
        }

        private void MultiBtn_Click(object sender, EventArgs e)
        {
            ListaServer listaServer = new ListaServer();

            listaServer.ShowDialog();
        }
    }
}
