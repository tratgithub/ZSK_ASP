using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSK_ASP.Models
{
    public class DAHRSListe
    {
        private static List<DAHRSEinheiten> einheitenliste = new List<DAHRSEinheiten>();
        public static IEnumerable<DAHRSEinheiten> Einheitenliste => einheitenliste;
        public static void AddDAHRSListe(DAHRSEinheiten dahrs)
        {
            einheitenliste.Add(dahrs);
        }

        public static void ClearDAHRSListe()
        {
            einheitenliste.Clear();
        }
    }
}
