using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
    public partial class FormaKlijent : Form
    {
        
        Linija linija;//Jak objekat
        Komunikacija komunikacija;

        public FormaKlijent()
        {
            InitializeComponent();
            komunikacija = new Komunikacija();
            if (komunikacija.PoveziSeNaServer())
            {
                this.Text = "Klijent je povezan!";
            }
        }

        private void FormaKlijent_Load(object sender, EventArgs e)
        {
            linija = new Linija();
            dataGridView1.DataSource = linija.Medjustanice;

            napuniCombo(cmbPocetna);
            napuniCombo(cmbMedjustanica);
            napuniCombo(cmbKrajnja);


        }

        public void napuniCombo(ComboBox cmb)
        {
            cmb.Items.Clear();
            foreach (Stanica s in komunikacija.VratiSveStanice())
            {
                cmb.Items.Add(s);
            }
            cmb.Text = "Odaberite stanicu!";
        }

        private void cmbPocetna_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                linija.PocetnaStanica = cmbPocetna.SelectedItem as Stanica;
                

                if (linija.PocetnaStanica.StanicaID==linija.KrajnjaStanica.StanicaID)
                {
                    MessageBox.Show("Nije moguce da pocetna i krajnja stanica budu iste!");
                    return;
                    napuniCombo(cmbPocetna);
                    return;
                }
                prikaziNazivLinije();
            }
            catch (Exception)
            {

                txtNazivLinije.Clear();
            }
        }

        void prikaziNazivLinije()
        {
            try
            {
                linija.NazivLinije = linija.PocetnaStanica.NazivStanice + "-" + linija.KrajnjaStanica.NazivStanice;
            }
            catch (Exception)
            {
                linija.NazivLinije = "";
            }
            txtNazivLinije.Text = linija.NazivLinije;
        }



        private void cmbKrajnja_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                linija.KrajnjaStanica = cmbKrajnja.SelectedItem as Stanica;
               

                if (linija.PocetnaStanica.StanicaID == linija.KrajnjaStanica.StanicaID)
                {
                    MessageBox.Show("Nije moguce da pocetna i krajnja stanica budu iste!");
                    return;
                    napuniCombo(cmbKrajnja);
                    return;
                }
                prikaziNazivLinije();

            }
            catch (Exception)
            {

                txtNazivLinije.Clear();
            }
        }

        private void btnDodajMedjuStanicu_Click(object sender, EventArgs e)
        {
            LinijaStanica ls = new LinijaStanica();
            ls.Linija = linija;
            ls.Stanica = cmbMedjustanica.SelectedItem as Stanica;

            try
            {
                if (ls.Stanica.StanicaID == linija.KrajnjaStanica.StanicaID || ls.Stanica.StanicaID == linija.PocetnaStanica.StanicaID)
                {
                    MessageBox.Show("Medjustanica ne sme biti ista kao pocetna ili krajnja stanica!");
                    napuniCombo(cmbMedjustanica);
                    return;
                }
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Niste odabrali pocetnu ili krajnju stanicu!");
            }
            catch (Exception) { }

            foreach (LinijaStanica lsi in linija.Medjustanice)
            {
                if (ls.Stanica.StanicaID == lsi.Stanica.StanicaID)
                {
                    MessageBox.Show("Vec ste dodali istu medjustanicu!");
                    return;
                }
            }


            linija.Medjustanice.Add(ls);

        }

        private void btnSacuvajLiniju_Click(object sender, EventArgs e)
        {
            int rezultat = komunikacija.SacuvajLiniju(linija);

            if (rezultat==0)
            {
                MessageBox.Show("Linija nije sacuvana!");
            }
            if (rezultat == -1)
            {
                MessageBox.Show("Linija nije sacuvana!\nPostoji ista linija");
            }
            if (rezultat == 1)
            {
                MessageBox.Show("Linija je sacuvana!");
            }

        }
    }
}
