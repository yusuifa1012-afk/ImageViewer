namespace ImageViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox[] pB;
        string[] fileNames;
        int startIndex = 0;
        int endIndex = 6;
        private void Form1_Load(object sender, EventArgs e)
        {
            pB = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,pictureBox6 };
            txtRoute.Enabled = false;
            foreach (var pb in pB)
            {
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BorderStyle = BorderStyle.FixedSingle;
            }
            pbBig.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBig.BorderStyle = BorderStyle.FixedSingle;
            openFileDialog1.Multiselect = true;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                startIndex = 0;
                endIndex = 6;
                fileNames = openFileDialog1.FileNames;
                pB = new PictureBox[] {pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,pictureBox6};
                if (fileNames.Length < 6)
                {
                    for (int i = 0; i < fileNames.Length; i++) { pB[i].Image = Image.FromFile(fileNames[i]); }
                }
                else for (int i = 0; i < 6; i++)
                    {
                        pB[i].Image = Image.FromFile(fileNames[i]);
                    }
                if (fileNames.Length > 6)
                {
                    btnRight.Enabled = true;
                }
                else {btnRight.Enabled = false; }
                if (startIndex == 0)
                {
                    btnLeft.Enabled = false;
                }
                else {btnLeft.Enabled = true; }
                for (int i = 0; i < 6; i++)
                {
                    if (startIndex + i < fileNames.Length)
                    {
                        pB[i].Image = Image.FromFile(fileNames[startIndex + i]);
                    }
                    if (endIndex >= fileNames.Length)
                    {
                        btnRight.Enabled = false;
                        for (int x = 0; x < endIndex - fileNames.Length; x++)
                        {
                            pB[5 - x].Image = null;
                        }
                    }
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pB = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            if (sender == pictureBox1 && pictureBox1.Image != null)
            {
                txtRoute.Text = fileNames[startIndex];
                pbBig.Image = pictureBox1.Image;
            }
            else if (sender == pictureBox2 && pictureBox2.Image != null)
            {
                txtRoute.Text = fileNames[startIndex +1];
                pbBig.Image = pictureBox2.Image;
            }
            else if (sender == pictureBox3 && pictureBox3.Image != null)
            {
                txtRoute.Text = fileNames[startIndex + 2];
                pbBig.Image = pictureBox3.Image;
            }
            else if (sender == pictureBox4 && pictureBox4.Image != null)
            {
                txtRoute.Text = fileNames[startIndex + 3];
                pbBig.Image = pictureBox4.Image;
            }
            else if (sender == pictureBox5 && pictureBox5.Image != null)
            {
                txtRoute.Text = fileNames[startIndex + 4];
                pbBig.Image = pictureBox5.Image;
            }
            else if (sender == pictureBox6 && pictureBox6.Image != null)
            {
                txtRoute.Text = fileNames[startIndex + 5];
                pbBig.Image = pictureBox6.Image;
            }

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            pB = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            if(startIndex < 6) btnLeft.Enabled=false;
            if (startIndex == 6) 
            {
                btnLeft.Enabled = false;
                startIndex -= 6;
                endIndex -= 6;
                for(int i = 0 ; i < 6; i++)
                {
                    pB[i].Image= Image.FromFile(fileNames[startIndex + i]);
                }
            }
            else 
            {
                startIndex -= 6;
                endIndex -= 6;
                for (int i = 0; i < 6; i++)
                {
                    pB[i].Image = Image.FromFile(fileNames[startIndex + i]);
                }
            }
            if(endIndex > fileNames.Length) btnRight.Enabled=false;
            else btnRight.Enabled = true;

            


        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            pB = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            startIndex = startIndex + 6;
            endIndex += 6;
            for (int i = 0 ; i < 6; i++)
            {
                if(startIndex + i < fileNames.Length)
                {
                    pB[i].Image = Image.FromFile(fileNames[startIndex + i]);
                }
                if(endIndex>=fileNames.Length)
                {
                    btnRight.Enabled= false;
                    for (int x = 0; x < endIndex - fileNames.Length; x++)
                    {
                        pB[5-x].Image = null;
                    }
                }
            }
            if (pictureBox1.Image != Image.FromFile(fileNames[0]))
            {
                btnLeft.Enabled = true;
            }
            else { btnLeft.Enabled = false; }
        }

        private void UpdatePictureBoxes()
        {

        }
    }
}