using System;
using System.ComponentModel.DataAnnotations;

namespace Gadzety.Models
{
    public class TowarStan
    {
        [Key]
        public int IdTowarStan { get; set; }
        public int IdTowar { get; set; }
        public virtual Towar Towar { get; set; }
        public int Stan { get; set; }
        public DateTime DataDodania { get; set; }
    }
}