using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadzety.Models
{
    public class Towar
    {
        [Key]
        public int IdTowar { get; set; }
        [Required(ErrorMessage = "Nazwa towaru jest wymagana")]
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage ="Cena towaru jest wymagana")]
        [DataType(DataType.Currency,ErrorMessage ="Wartość w polu 'Cena' jest nieprawidłowa. Wartość musi być liczbą.")]
        public decimal Cena { get; set; }

        [Display(Name ="Towar promocyjny")]
        public bool TowarPromocyjny { get; set; }

        [Display(Name = "Towar polecany")]
        public bool TowarPolecany { get; set; }

        public int IdKategoria { get; set; }
        public virtual Kategoria Kategoria { get; set; }


        public virtual ICollection<TowarZdjecie> TowarZdjecia { get; set; }
        public virtual ICollection<TowarStan> TowarStany { get; set; }

    }
}