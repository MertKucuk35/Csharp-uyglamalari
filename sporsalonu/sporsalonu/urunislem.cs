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
namespace sporsalonu
{
    public partial class urunislem : Form
    {
        public urunislem()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
        private void urunislem_Load(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            baglanti.Open();
            SqlCommand yukle = new SqlCommand("select * from markalar", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(yukle);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            comboBox1.DisplayMember = "Tur";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = tablo;
            baglanti.Close();

            baglanti.Open();
            SqlCommand yukle2 = new SqlCommand("select * from markalar", baglanti);
            SqlDataAdapter adapte2 = new SqlDataAdapter(yukle2);
            DataTable tablo2 = new DataTable();
            adapte.Fill(tablo2);
            comboBox2.DisplayMember = "marka_ad";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = tablo2;
            baglanti.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            button1.Text = "Kaydet";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            button1.Text = "Güncelle";
        }
    }
}
