namespace BetGreyhound
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor; //facet który zawarł zakład

        public string GetDescription()
        {
            //zwraca string, który określa, kto obstawił wyścig, jak dużo pieniędzy
            //postawił i na którego psa ("Janek postawił 8zł na psa numer4"
            //Jeżeli ilość jest równa zero, zakład nie został zawarty
            //("Janek nie zawarł zakładu")
            if (Bettor != null)
            {
                return Bettor.Name + " stawia " + Amount + " zł na charta nr " + Dog;
            }
            else return Bettor.Name + " nie zawarł jeszcze zakładu";
        }

        public int payOut(int Winner)
        {
            if (Dog == Winner)
                return Amount;
            else
                return -Amount;
        }
    }
}