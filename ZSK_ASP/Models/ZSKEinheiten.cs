using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSK_ASP.Models
{
    public class ZSKEinheiten
    {
        public int Ziegen { get; set; }

        public int Schafe { get; set; }

        public int Kuehe { get; set; }

        public int KleineZiegen { get; set; }

        public int Rest { get; set; }

        public int Euro { get; set; }

        public int PreisZiegen = 500;

        public int PreisSchafe = 650;

        public int PreisKuehe = 2800;

        public int PreisKlZiegen = 50;


    }
}
