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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select urun_tur.Tur as turu, count(urunler.id) as Kayitli_Urunler ,min(satisfiyat) as en_ucuz,max(satisfiyat) as en_pahali,sum(stok) as toplam_stok  from urunler inner join urun_tur on (urun_tur.id=urunler.tur_no) group by urun_tur.Tur ", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select count(id) as Kayitli_Turler  from urun_tur ", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select count(id) as Kayitli_Markalar  from markalar ", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select marka_ad,Tur,count(urunler.id) as Kayitli_Urunler ,min(satisfiyat) as en_ucuz,max(satisfiyat) as en_pahali,sum(stok) as toplam_stok  from urunler inner join markalar on (markalar.id=urunler.marka_no) inner join urun_tur on (urun_tur.id=urunler.tur_no) where markalar.id=(select id from markalar where marka_ad=@Marka) group by marka_ad,Tur  ", baglanti);
         listele.Parameters.Add("@Marka",Microsoft.VisualBasic.Interaction.InputBox("Marka adi","Aradiginiz marka adini girin","",10,10));
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
    }
}
//select marka_ad,Tur,count(urunler.id) as Kayitli_Urunler ,min(satisfiyat) as en_ucuz,max(satisfiyat) as en_pahali,sum(stok) as toplam_stok  from urunler inner join markalar on (markalar.id=urunler.marka_no) inner join urun_tur on (urun_tur.id=urunler.tur_no) group by marka_ad,Tur 