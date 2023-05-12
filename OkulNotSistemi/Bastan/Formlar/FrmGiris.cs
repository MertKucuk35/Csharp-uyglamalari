using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bastan.Formlar
{
    public partial class FrmGiris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=ogrencisinav;User ID=sert;Password=mert");
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand giris = new SqlCommand("select ogr_numara,ogr_sifre from ogrenciler where ogr_numara=@no and ogr_sifre=@sifre ", baglanti);
            if (giris.Connection.State != ConnectionState.Open)
            {
                giris.Connection.Open();
            }
            giris.Parameters.AddWithValue("@no", txtnumara.Text);
            giris.Parameters.AddWithValue("@sifre", txtsifre.Text);
            SqlDataReader okuyucu = giris.ExecuteReader();
            if (okuyucu.Read())
            {
                FrmOgrenciPanel frmogrpnl = new FrmOgrenciPanel();
                frmogrpnl.numara = okuyucu[0].ToString();
                frmogrpnl.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Kontrol edin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                okuyucu.Close();
                baglanti.Close();
            }
        }

        private void txtnumara_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtnumara_TextChanged(object sender, EventArgs e)
        {
            if(txtnumara.Text=="00000" && txtsifre.Text=="000")
            {
                FrmHarita frmhrt = new FrmHarita();
                frmhrt.Show();
                this.Hide();
            }
        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {
            if (txtnumara.Text == "00000" && txtsifre.Text == "000")
            {
                FrmHarita frmhrt = new FrmHarita();
                frmhrt.Show();
                this.Hide();
            }
        }
    }
}
