using Gadzety.Models;
using System.ComponentModel.DataAnnotations;

namespace Gadzety.Models
{
    public class TowarZdjecie
    {
        [Key]
        public int IdTowarZdjecie { get; set; }
        public string Url { get; set; }
        public int IdTowar { get; set; }
        public virtual Towar Towar { get; set; }
    }
}