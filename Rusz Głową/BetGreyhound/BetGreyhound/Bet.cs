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
            return "a";
        }

        public int payOut(int Winner)
        {
            //parametrem jest zwycięzca wyścigu. Jeżeli pies wygrał,
            //zwróć wartość postawioną. W przeciwnym razie zwróć wartość 
            //postawioną ze znakiem minus
            return 1;
        }
    }
}