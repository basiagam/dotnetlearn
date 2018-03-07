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
            }
            
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
    }
}
