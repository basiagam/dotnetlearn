using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gadzet.Models.ViewModels
{
    public class TowarViewModel
    {
        [Key]
        public int IdTowar { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        [Display(Name = "VIP Towar")]
        public bool VIPTowar { get; set; }
        [Display(Name = "Towar promocyjny")]
        public bool TowarPromocyjny { get; set; }
        public IEnumerable<string> Zdjecia { get; set; }
        public decimal AktualnyStan { get; set; }
    }
}