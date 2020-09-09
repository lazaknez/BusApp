using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormaServer : Form
    {
        Server server;
        public FormaServer()
        {
            InitializeComponent();
            server = new Server();

            if (server.PokreniServer())
            {
                this.Text = "Server je pokrenut!";
            }
        }

        private void FormaServer_Load(object sender, EventArgs e)
        {

            Timer t = new Timer();
            t.Interval = 5000;
            t.Tick += Osvezi;
            t.Start();

        }

        private void Osvezi(object sender, EventArgs e)
        {
            string uslov = "";


            if (cbStanica.Checked)
            {
                uslov = " where l.NazivLinije like '%" + txtUnosStanice.Text + "%' or p.NazivStanice like '%" + txtUnosStanice.Text + "%' or k.NazivStanice like '%" + txtUnosStanice.Text + "%'";
            }


            dataGridView1.DataSource = Broker.DajSesiju().vratiSveLinijeZaServer(uslov);


        }
    }
}
