using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domen;
using System.Data;
using System.Data.SqlClient;


namespace Server
{
    public class Broker
    {
        SqlCommand komanda;
        SqlConnection konekcija;
        SqlTransaction transakcija;


        void KonektujSe()
        {
            konekcija = new SqlConnection(@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=Autostanica;Integrated Security=True");
            komanda = konekcija.CreateCommand();
        }

        Broker()
        {
            KonektujSe();
        }

        static Broker instanca;

        public static Broker DajSesiju()
        {
            if (instanca == null)
                instanca = new Broker();
            return instanca;

        }

        //method

        public List<Stanica> VratiSveStanice()
        {
            List<Stanica> lista = new List<Stanica>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Stanica";
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Stanica nova = new Stanica();
                    nova.StanicaID = citac.GetInt32(0);
                    nova.NazivStanice = citac.GetString(1);
                    lista.Add(nova);
                }
                citac.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        public int SacuvajLiniju(Linija l)
        {
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("",konekcija,transakcija);


                if (ProveriLiniju(l))
                {
                    return -1;
                }
                komanda.CommandText = "Insert into Linija(NazivLinije,PocetnaStanica,KrajnjaStanica) values ('"+l.NazivLinije+"',"+l.PocetnaStanica.StanicaID+ "," + l.KrajnjaStanica.StanicaID + ")";
                komanda.ExecuteNonQuery();


                l.LinijaID = VratiSifruLinije();
                foreach (LinijaStanica ls in l.Medjustanice)
                {
                    komanda.CommandText = "Insert into LinijaStanica values("+l.LinijaID+","+ls.Stanica.StanicaID+")";
                    komanda.ExecuteNonQuery();
                }
                transakcija.Commit();
                return 1;
            }
            catch (Exception)
            {
                transakcija.Rollback();
                return 0;
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

        }

        public bool ProveriLiniju(Linija l)
        {
            List<Linija> isteLinije = new List<Linija>();
            komanda.CommandText = "Select * from Linija where NazivLinije = '"+l.NazivLinije+"'";
            SqlDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                Linija li = new Linija();
                li.LinijaID = citac.GetInt32(0);
                isteLinije.Add(li);
            }
            citac.Close();


            foreach (Linija li in isteLinije)
            {
                if (ProveriMedjustanicu(l,li))
                {
                    return true;
                }
            }
            return false;

        }

        public bool ProveriMedjustanicu(Linija l, Linija li)
        {
            List<int> listID = new List<int>();
            komanda.CommandText = "Select * from LinijaStanica where LinijaID = "+li.LinijaID+"";

            SqlDataReader citac = komanda.ExecuteReader();

            while (citac.Read())
            {
                listID.Add(citac.GetInt32(1));
            }
            citac.Close();


            bool postoji = true;

            foreach (LinijaStanica ls in l.Medjustanice)
            {
                if (!listID.Contains(ls.Stanica.StanicaID))
                {
                    postoji = false;
                }
            }

            foreach (int i in listID)
            {
                bool ima = false;
                foreach (LinijaStanica ls in l.Medjustanice)
                {
                    if (ls.Stanica.StanicaID==i)
                    {
                        ima = true;
                    }
                }
                if (!ima)
                    postoji = false;
                
            }

            return postoji;

        }

        public int VratiSifruLinije()
        {
            try
            {
                komanda.CommandText = "Select max(LinijaID) from Linija";
                object o = komanda.ExecuteScalar();
                if (o == DBNull.Value)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(o);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Server form


        public List<Linija> vratiSveLinijeZaServer(string uslov)
        {
            List<Linija> lista = new List<Linija>();
            try
            {
                konekcija.Open();
                komanda.CommandText = "Select * from Linija l inner join Stanica p on l.PocetnaStanica=p.StanicaID inner join Stanica k on l.KrajnjaStanica=k.StanicaID"+uslov;
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    Linija l = new Linija();
                    l.LinijaID = citac.GetInt32(0);
                    l.NazivLinije = citac.GetString(1);

                    l.PocetnaStanica = new Stanica();
                    l.PocetnaStanica.StanicaID = citac.GetInt32(4);
                    l.PocetnaStanica.NazivStanice = citac.GetString(5);

                    l.KrajnjaStanica = new Stanica();
                    l.KrajnjaStanica.StanicaID = citac.GetInt32(6);
                    l.KrajnjaStanica.NazivStanice = citac.GetString(7);
                    lista.Add(l);
                }
                citac.Close();


                foreach (Linija l in lista)
                {
                    VratiSveMedjuStaniceZaLiniju(l);
                }


                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (konekcija!=null)
                {
                    konekcija.Close();
                }
            }

        }
        public void VratiSveMedjuStaniceZaLiniju(Linija l)
        {
            
            try
            {
               
                komanda.CommandText = "Select * from LinijaStanica ls inner join Stanica s on ls.StanicaID = s.StanicaID where ls.linijaID = "+l.LinijaID+"";
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    LinijaStanica ls = new LinijaStanica();
                    ls.Linija = l;

                    ls.Stanica = new Stanica();
                    ls.Stanica.StanicaID = citac.GetInt32(2);
                    ls.Stanica.NazivStanice = citac.GetString(3);
                    l.Medjustanice.Add(ls);
                }
                citac.Close();
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }








    }
}
