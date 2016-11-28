using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadzety.Models.ViewModels
{
    public class TowarViewModel
    {
        public int IdTowar { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }

        [Display(Name ="Towar promocyjny")]
        public bool TowarPromocyjny { get; set; }

        [Display(Name = "Towar polecany")]
        public bool TowarPolecany { get; set; }

        public int IdKategoria { get; set; }
        public virtual Kategoria Kategoria { get; set; }


        public IEnumerable<string> Zdjecia { get; set; }
        public decimal AktualnyStan { get; set; }

    }
}