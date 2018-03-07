using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetGreyhound
{
   public  class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        //pola jako kontrolki formularza GUI
        public RadioButton MyButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            //TODO
            //ustaw moje pole tekstowe na opis zakładu a napis obok pola wyboru tak
            //aby pokazywał np. "Janek ma 43zł"
            if (MyBet==null)
                MyLabel.Text = Name + " nie zawarł jeszcze zakładu";
            else
                MyLabel.Text = Name + " stawia "+MyBet.Amount+" zł na charta nr "+MyBet.Dog;//TODO

            MyButton.Text = Name + " ma " + Cash + "zł";
        }

        public void ClearBet()
        {
            //wyczyść mój zakład aby był równy 0
        }

        public bool PlaceBet(int amount, int DogToWin)
        {
            //ustal nowy zakład i przechowaj go w polu MyBet
            //zwróć true, jeżeli facet ma wystarczającą illość pieniędzy aby obstawić
            return true;
        }

        public void Collect(int Winner)
        {
            //Poproś o wypłatę i zuaktualizuj ektykiety
        }

    }
}
