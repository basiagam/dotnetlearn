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
            //ustaw moje pole tekstowe na opis zakładu a napis obok pola wyboru tak
            //aby pokazywał np. "Janek ma 43zł"
            MyButton.Text = Name + " ma " + Cash + "zł";
        }


        public void ClearBet()
        {
            MyLabel.Text = Name + " nie zawarł zakładu";
        }

        public bool PlaceBet(int amount, int DogToWin)
        {
            //ustal nowy zakład i przechowaj go w polu MyBet
            //zwróć true, jeżeli facet ma wystarczającą illość pieniędzy aby obstawić
            if (Cash >= amount && MyBet==null)
            {
                MyBet = new Bet() { Amount = amount, Dog = DogToWin, Bettor = this };
                MyLabel.Text = Name + " stawia " + MyBet.Amount + " zł na charta nr " + MyBet.Dog;
                return true;
            }
            return false; 
        }

        public void Collect(int Winner)
        {
            if (MyBet != null) //jesli zawarto zaklad
            {
                int amount = MyBet.payOut(Winner); //oblicz pule pieniedzy (+ czy -)
                Cash += amount;
                MyBet = null; //wyzeruj zaklad(nowe rozdanie)
                ClearBet();
                UpdateLabels();
            }
        }

    }
}
