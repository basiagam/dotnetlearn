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

        
    }
}
