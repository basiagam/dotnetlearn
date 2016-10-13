using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadzet.Models.Sklep
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienie { get; set; }
        public int IdHandlowiec { get; set; }
        public virtual Handlowiec Handlowiec { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Adres jest wymagany.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Telefon jest wymagany.")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Email jest wymagany.")]
        public string Email { get; set; }
        public DateTime DataZamowienia { get; set; }
        public virtual ICollection<ZamowieniePozycja> ZamowieniePozycja{get;set;}
    }
}