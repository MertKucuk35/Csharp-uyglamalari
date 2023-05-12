using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bastan.Formlar
{
    public partial class FrmHarita : Form
    {
        public FrmHarita()
        {
            InitializeComponent();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
        }

        private void pnlBolumListesi_Click(object sender, EventArgs e)
        {
            FrmBolumListesi frmblmliste = new FrmBolumListesi();
            frmblmliste.Show();
            this.Hide();
           
        }

        private void pnlDersListesi_Click(object sender, EventArgs e)
        {
            FrmDersListesi frmdersliste = new FrmDersListesi();
            frmdersliste.Show();
            this.Hide();
        }

        private void pnlNotlarFormu_Click(object sender, EventArgs e)
        {
            FrmNotlar frmnotlar = new FrmNotlar();
            frmnotlar.Show();
            this.Hide();
        }

        private void pnlBolumEkle_Click(object sender, EventArgs e)
        {
            FrmBolumEkle frmblmekle = new FrmBolumEkle();
            frmblmekle.Show();
            this.Hide();
        }

        private void pnlOgrenciKayit_Click(object sender, EventArgs e)
        {
            Form1 ogrekle = new Form1();
            ogrekle.Show();
            this.Hide();
        }

        private void pnlCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
