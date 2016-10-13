using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadzet.Models.Sklep
{
    public class Handlowiec
    {
        [Key]
        public int IdHandlowiec { get; set; }
        [Required(ErrorMessage = "Pole imię jest wymagane.")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Pole e-mail jest wymagane.")]
        [EmailAddress(ErrorMessage = "Zły format adresu e-mail.")]
        [Display(Name = "e-mail")]
        public string Email { get; set; }
        public string UserId { get; set; }
        public bool HandlowiecVIP { get; set; }
    }
}