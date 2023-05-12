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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        string sifre = "";
        private void Form1_Load(object sender, EventArgs e)
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
                label3.Text = sifre;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from admin where kullanici_ad=@Ad and sifre=@Sifre", baglanti);
            sorgu.Parameters.AddWithValue("@Ad", textBox1.Text);
            sorgu.Parameters.AddWithValue("@Sifre", textBox2.Text);
            SqlDataReader oku = sorgu.ExecuteReader();
            if (oku.Read() & sifre == textBox3.Text)
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Bilgilerinizi Konrol Edin");
            baglanti.Close();



           
          
        }
    }
}
