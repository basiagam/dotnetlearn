using System.Collections.Generic;

namespace Repozytorium.Models
{
    public class OgloszeniaZKategoriiViewModels
    {
        public IList<Ogloszenie> Ogloszenia { get; set; }
        public string NazwaKategorii { get; set; }
    }
}