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
    public partial class sifredegistir : Form
    {
        public sifredegistir()
        {
            InitializeComponent();
        }
        string sifre = "";
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
        private void sifredegistir_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();

            string sayilar = "123456789";
            string harfler = "asdfghjklizxcvbnmqwertyuopASDFGHJKLZXCVBNMQWERTYUIOP";
            for (int i = 0; i < 4; i++)
            {
                int harfrakam = rastgele.Next(0, 2);
                if (harfrakam == 0)
                    sifre = sifre + harfler.Substring(rastgele.Next(0, harfler.Length), 1);
                if (harfrakam == 1)
                    sifre = sifre + sayilar.Substring(rastgele.Next(0, sayilar.Length), 1);

            }
            label3.Text = sifre;
            baglanti.Open();
            SqlCommand yukle = new SqlCommand("select * from sorular", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(yukle);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            comboBox1.DisplayMember = "soru";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = tablo;
            baglanti.Close();

        }

        private void sifredegistir_FormClosed(object sender, FormClosedEventArgs e)
        {
           uyegiris frm = new uyegiris();
           frm.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if(textBox1.Text != null & textBox2.Text==textBox3.Text & textBox4.Text==sifre &textBox6 !=null)
            { baglanti.Open();
            SqlCommand degistir=new SqlCommand("select * from uye where mail=@Mail and soruno=@Soruno and cevap=@Cevap",baglanti);
           degistir.Parameters.AddWithValue("@Mail",textBox1.Text);
             degistir.Parameters.AddWithValue("@Soruno",comboBox1.SelectedValue);
             degistir.Parameters.AddWithValue("@Cevap",textBox6.Text);
            SqlDataReader oku = degistir.ExecuteReader();
            if(oku.Read())
            {
                i = 1;
                
            }
          
            }
            else
                MessageBox.Show("Bilgileri kontrol et");
                baglanti.Close();
                if (i == 1)
                    baglanti.Open();
            { SqlCommand guncelle = new SqlCommand("update uye set sifre=@Sifre where mail=@Mail", baglanti);
                guncelle.Parameters.AddWithValue("@Sifre", textBox2.Text);
                guncelle.Parameters.AddWithValue("@Mail", textBox1.Text);
                guncelle.ExecuteNonQuery();
                MessageBox.Show("Başarıyla Değiştirildi");}
            baglanti.Close();
        }
    }
}
//Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert