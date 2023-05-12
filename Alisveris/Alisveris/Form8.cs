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
namespace Alisveris
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        private void Form8_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select Tur,sum(stok) from urunler inner join urun_tur on (urun_tur.id=urunler.tur_no) group by Tur", baglanti);
            SqlDataReader okuyucu = sorgu.ExecuteReader();
            while(okuyucu.Read())
            {
                chart1.Series["Series1"].Points.AddXY(okuyucu[0],okuyucu[1]);
            }
            baglanti.Close();

        }
    }
}
