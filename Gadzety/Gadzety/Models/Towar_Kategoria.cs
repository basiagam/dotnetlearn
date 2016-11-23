namespace Gadzety.Models
{
    public class Towar_Kategoria
    {
        public int Id { get; set; }
        public int KategoriaId { get; set; }
        public int TowarId { get; set; }
        public virtual Kategoria Kategoria { get; set; }
        public virtual Towar Towar { get; set; }
    }
}