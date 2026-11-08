using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace catgame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Proqramdan çıxış edilsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        int num;
        int count = 0;
        string img = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img") + "\\";

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            Random r = new Random();
            num = r.Next(1, 8);
            while (num == 2)
            {
                num = r.Next(1, 8);
            }

            SetAllImages(img + "sual.png");
            label1.Text = "Xal: 0";
        }

        private void CheckBoxClick(PictureBox pb, int boxNumber)
        {
            if (num == boxNumber)
            {
                pb.ImageLocation = img + "bomb.png";
                try
                {
                    SoundPlayer s = new SoundPlayer(img + "bomb.wav");
                    s.Play();
                }
                catch
                {
                    SystemSounds.Beep.Play();
                }
                MessageBox.Show("Oyun bitdi");
            }
            else
            {
                pb.ImageLocation = img + "cat.png";
                pb.Enabled = false;
                count++;
                label1.Text = "Xal: " + count.ToString();

                if (count == 5)
                {
                    MessageBox.Show("Oyunu qazandınız, Yeni oyun üçün ok düyməsinə basın");
                    ResetGame();
                }
            }
        }

        private void ResetGame()
        {
            count = 0;
            label1.Text = "Xal: 0";
            Random r = new Random();
            num = r.Next(1, 8);
            while (num == 2)
            {
                num = r.Next(1, 8);
            }

            SetAllImages(img + "sual.png");

            pictureBox1.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
        }

        private void SetAllImages(string imagePath)
        {
            pictureBox1.ImageLocation = imagePath;
            pictureBox3.ImageLocation = imagePath;
            pictureBox4.ImageLocation = imagePath;
            pictureBox5.ImageLocation = imagePath;
            pictureBox6.ImageLocation = imagePath;
            pictureBox7.ImageLocation = imagePath;
        }

        private void pictureBox1_Click(object sender, EventArgs e) => CheckBoxClick(pictureBox1, 1);
        private void pictureBox3_Click(object sender, EventArgs e) => CheckBoxClick(pictureBox3, 3);
        private void pictureBox4_Click(object sender, EventArgs e) => CheckBoxClick(pictureBox4, 4);
        private void pictureBox5_Click(object sender, EventArgs e) => CheckBoxClick(pictureBox5, 5);
        private void pictureBox6_Click(object sender, EventArgs e) => CheckBoxClick(pictureBox6, 6);
        private void pictureBox7_Click(object sender, EventArgs e) => CheckBoxClick(pictureBox7, 7);

        private void button1_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}