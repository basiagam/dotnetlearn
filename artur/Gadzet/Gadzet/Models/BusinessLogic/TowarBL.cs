using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gadzet.Models.BusinessLogic
{
    public class TowarBL
    {
        private GadzetContext db = new GadzetContext();

        /// <summary>
        /// Metoda oblicza aktualny stan towaru.
        /// </summary>
        /// <param name="idTowar">Identyfikator towaru</param>
        /// <returns>Aktualny stan</returns>
        /// 
        public int AktualnyStanTowaru(int idTowar)
        {
            int aktualnyStan = (from s in db.TowarStany
                                where
                                s.IdTowar == idTowar
                                select s.Stan).Sum();
            if (db.ZamowieniePozycje.Any(x => x.IdTowar == idTowar))
            {
                aktualnyStan = aktualnyStan - (from z in db.ZamowieniePozycje
                                               where
                                               z.IdTowar == idTowar
                                               select z.Ilosc).Sum();
            }
            return aktualnyStan;
        } 
    }
}