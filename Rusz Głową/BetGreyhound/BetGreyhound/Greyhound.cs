using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetGreyhound
{
    public class Greyhound
    {
        public int StartingPosition; // miejsce gdzie zaczyna sie pictureBox
        public int RacetrackLegth;//jak długa jest trasa
        public PictureBox MyPictureBox = null;
        public int Location = 0; //położenie na torze
        public Random MyRandom;

        public bool Run()
        {
            //przesu się do przodu losowo o 1,2,3 lub 4 punkty
            //zaktualizuj położenie PictureBox na formularzu
            //zwróć true jeśli wygrałem wyścig
            return true;
        }

        public void TakeStartingPosition()
        {
            //wyzeruj położenie i ustaw na linii startowej
        }

    }
}
