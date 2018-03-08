using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetGreyhound
{
    public partial class Form1 : Form
    {
        public Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            // tablica Guys
            GuysArray[0] = new Guy { Name = "Janek", Cash = 40, MyBet = null, MyButton = radioButton1, MyLabel = joeBetLabel };
            GuysArray[1] = new Guy { Name = "Bartek", Cash = 330, MyBet = null, MyButton = radioButton2, MyLabel = bobBetLabel };
            GuysArray[2] = new Guy { Name = "Arek", Cash = 77, MyBet = null, MyButton = radioButton3, MyLabel = alBetLabel };

            for (int i = 0; i <= 2; i++)
            {
                GuysArray[i].UpdateLabels();
            };

            //tablica Greyhounds
            greyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = racetrack.Left,
                RacetrackLegth = racetrack.Width - pictureBox1.Width,
                MyRandom = random,
                Location = 0
            };
            greyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = racetrack.Left,
                RacetrackLegth = racetrack.Width - pictureBox2.Width,
                MyRandom = random,
                Location = 0
            };
            greyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = racetrack.Left,
                RacetrackLegth = racetrack.Width - pictureBox3.Width,
                MyRandom = random,
                Location = 0
            };
            greyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = racetrack.Left,
                RacetrackLegth = racetrack.Width - pictureBox4.Width,
                MyRandom = random,
                Location = 0
            };


        }
        public void setTextForLabel(string name)
        {
            nameLabel.Text = name;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            setTextForLabel(GuysArray[0].Name);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            setTextForLabel(GuysArray[1].Name);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            setTextForLabel(GuysArray[2].Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sprawdzamy ktory z nich obstawil i tworzymy bet
            if (radioButton1.Checked)
            {
             GuysArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
             GuysArray[0].UpdateLabels();

            }
            if (radioButton2.Checked)
            {
                GuysArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                GuysArray[1].UpdateLabels();
            }
            if (radioButton3.Checked)
            {
                GuysArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                GuysArray[2].UpdateLabels();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i <= 3; i++)
            {
                if (greyhoundArray[i].Run()==true)
                {
                    timer1.Stop();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    MessageBox.Show("Wygrał pies nr " + (i+1));
                    for (int j = 0; j <= 3; j++)
                        greyhoundArray[j].TakeStartingPosition();
                    break;
                }
            }

        }
    }
}
