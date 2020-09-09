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


namespace Server
{
    public class Server
    {
        Socket soket;


        public bool PokreniServer()
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any,45678);
                soket.Bind(ep);

                ThreadStart ts = Osluskuj;
                new Thread(ts).Start();

                return true;
            }
            catch (Exception)
            {

                return false; 
            }


        }

        public bool ZaustaviServer()
        {
            try
            {
                soket.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        void Osluskuj()
        {
            try
            {
                while (true)
                {
                    soket.Listen(8);
                    Socket klijent = soket.Accept();
                    NetworkStream tok = new NetworkStream(klijent);
                    new NitKlijenta(tok);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}
