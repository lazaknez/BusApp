using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;



namespace Klijent
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater;

        public bool PoveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1",45678);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public void Kraj()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.Kraj;
            //slanje
            formater.Serialize(tok, transfer);

        }
        public List<Stanica> VratiSveStanice()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.VratiSveStanice;
            //slanje
            formater.Serialize(tok, transfer);


            transfer = formater.Deserialize(tok) as TransferKlasa;

            return transfer.Rezultat as List<Stanica>;

        }
        public int SacuvajLiniju(Linija l)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.SacuvajLiniju;
            //slanje
            formater.Serialize(tok, transfer);


            transfer = formater.Deserialize(tok) as TransferKlasa;

            return (int)transfer.Rezultat ;

        }

    }
}
