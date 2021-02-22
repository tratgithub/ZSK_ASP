using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSK_ASP.Models
{
    public class ZSKListe
    {
        private static List<ZSKEinheiten> einheitenliste = new List<ZSKEinheiten>();
        public static IEnumerable<ZSKEinheiten> Einheitenliste => einheitenliste;
        public static void AddZSKListe(ZSKEinheiten zsk)
        {
            einheitenliste.Add(zsk);
        }

        public static void ClearZSKListe()
        {
            einheitenliste.Clear();
        }


    }
}
