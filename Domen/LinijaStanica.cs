using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class LinijaStanica
    {
        Linija linija;
        Stanica stanica;

        [Browsable(false)]
        public Linija Linija { get => linija; set => linija = value; }
        [DisplayName("Naziv medjustanice:")]
        public Stanica Stanica { get => stanica; set => stanica = value; }
    }
}
