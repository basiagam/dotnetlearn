using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gadzety.Models
{
    public class Kategoria
    {
        [Key]
        [Display(Name = "Id kategorii:")]
        public int IdKategoria { get; set; }
        [Display(Name = "Nazwa kategorii:")]
        [Required]
        public string Nazwa { get; set; }

        public virtual ICollection<Towar> Towary { get; set; }
        //public virtual Kategoria Kategoria { get; set; }
        //public int IdKategoria { get; set; }
    }
}