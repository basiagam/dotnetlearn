using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gadzety.Models
{
    public class Kategoria
    {
        public Kategoria()
        {
            this.Towar_Kategoria = new HashSet<Towar_Kategoria>();
        }
        [Key]
        [Display(Name = "Id kategorii:")]
        public int Id { get; set; }
        [Display(Name = "Nazwa kategorii:")]
        [Required]
        public string Nazwa { get; set; }

        public ICollection<Towar_Kategoria> Towar_Kategoria { get; set; }
    }
}