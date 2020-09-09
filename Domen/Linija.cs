using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Linija
    {
        int linijaID;
        string nazivLinije;
        Stanica pocetnaStanica;
        Stanica krajnjaStanica;
        BindingList<LinijaStanica> medjustanice;

        public Linija()
        {
            Medjustanice = new BindingList<LinijaStanica>();
        }


        [Browsable(false)]
        public int LinijaID { get => linijaID; set => linijaID = value; }
        public string NazivLinije { get => nazivLinije; set => nazivLinije = value; }
        public Stanica PocetnaStanica { get => pocetnaStanica; set => pocetnaStanica = value; }
        public Stanica KrajnjaStanica { get => krajnjaStanica; set => krajnjaStanica = value; }
        public BindingList<LinijaStanica> Medjustanice { get => medjustanice; set => medjustanice = value; }

        [DisplayName("Medjustanice:")]
        public string MedjustaniceStringZaPrikaz
        {
            get { string rezultat = "";

                foreach (LinijaStanica ls in medjustanice)
                {
                    rezultat += ls.Stanica.NazivStanice + ", ";
                }
                
                return rezultat;
            }
        }


    }
}
