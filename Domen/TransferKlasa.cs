using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public enum Operacije { Kraj = 1 }

    [Serializable]//moraju sve klase da budu ovakve
    public class TransferKlasa
    {
        public Operacije Operacija;
        public Object TransferObjekat;
        public Object Rezultat;


    }
}
