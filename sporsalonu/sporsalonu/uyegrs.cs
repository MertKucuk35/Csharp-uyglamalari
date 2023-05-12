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
    public partial class uyegiris : Form
    {
        public uyegiris()
        {
            InitializeComponent();
        }
        string sifre = "";
        public string giris;
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
        private void uyegiris_Load(object sender, EventArgs e)
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
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifredegistir frm = new sifredegistir();
            frm.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayitol frm2 = new kayitol();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !=null & textBox2.Text != null & textBox3.Text==sifre)
            {
                baglanti.Open();
            if(radioButton1.Checked)
            {
                SqlCommand admingrs = new SqlCommand(" select * from admin where adminad=@Adminad and sifre=@Sifre", baglanti);
                  admingrs.Parameters.AddWithValue("@Adminad",textBox1.Text);
                 admingrs.Parameters.AddWithValue("@Sifre",textBox2.Text);
              SqlDataReader oku = admingrs.ExecuteReader();
                if(oku.Read())
                {
                    giris = textBox1.Text;                  
                    adminmenu adminfr = new adminmenu();
                adminfr.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Bilgilerinizi Kontrol Edin");
            }



            if(radioButton2.Checked)
            {
                 SqlCommand uyegrs = new SqlCommand(" select * from uye where mail=@Mail and sifre=@Sifre", baglanti);
                  uyegrs.Parameters.AddWithValue("@Mail",textBox1.Text);
                 uyegrs.Parameters.AddWithValue("@Sifre",textBox2.Text);
               SqlDataReader oku = uyegrs.ExecuteReader();
                if(oku.Read())
                {
                    giris = textBox1.Text;
                    uyemenu uyefr = new uyemenu();
                uyefr.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Bilgilerinizi Kontrol Edin");
            }

            }

            baglanti.Close();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Admin Adı";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Mail";
        }
    }
}
