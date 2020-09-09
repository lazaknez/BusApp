using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Stanica
    {
        public override string ToString()
        {
            return nazivStanice;
        }

        int stanicaID;
        string nazivStanice;

        public int StanicaID { get => stanicaID; set => stanicaID = value; }
        public string NazivStanice { get => nazivStanice; set => nazivStanice = value; }
    }
}
