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
    public partial class kayitol : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
        public kayitol()
        {
            InitializeComponent();
        }

        private void kayitol_FormClosed(object sender, FormClosedEventArgs e)
        {
            uyegiris frm = new uyegiris();
            frm.Show();
        }

        private void kayitol_Load(object sender, EventArgs e)
        {
            SqlCommand yukle = new SqlCommand("select * from sorular", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(yukle) ;
           DataTable tablo=new DataTable();
            adapte.Fill(tablo);
            comboBox1.DisplayMember="soru";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null & textBox2.Text != null & textBox3.Text != null & textBox4.Text != null & textBox5.Text != null & textBox6.Text != null & textBox4.Text == textBox5.Text)
            {
                baglanti.Open();
                SqlCommand ekle = new SqlCommand("insert into uye(ad,soyad,dgmtrh,uyelikbts,mail,sifre,cinsiyet,soruno,cevap) values(@Ad,@Soyad,@Dgmtrh,dateadd( day ,@Gun, getdate()),@Mail,@Sifre,@Cinsiyet,@Soruno,@Cevap)", baglanti);
                  ekle.Parameters.AddWithValue("@Ad",textBox1.Text);
                  ekle.Parameters.AddWithValue("@Soyad",textBox2.Text);
                  ekle.Parameters.AddWithValue("@Dgmtrh",dateTimePicker1.Text);
                if(radioButton1.Checked)
                    ekle.Parameters.AddWithValue("@Gun", 30);
                if (radioButton2.Checked)
                    ekle.Parameters.AddWithValue("@Gun", 90);
                if (radioButton3.Checked)
                    ekle.Parameters.AddWithValue("@Gun", 180);
                  ekle.Parameters.AddWithValue("@Mail",textBox3.Text);
                  ekle.Parameters.AddWithValue("@Sifre", textBox4.Text);
                if(radioButton4.Checked)
                    ekle.Parameters.AddWithValue("@Cinsiyet",0);
                else
                    ekle.Parameters.AddWithValue("@Cinsiyet",1);
              
               ekle.Parameters.AddWithValue("@Soruno", comboBox1.SelectedValue);
               ekle.Parameters.AddWithValue("@Cevap", textBox6.Text);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı");
            }
            else
                MessageBox.Show("Bilgilerinizi Kontrol Edin");
        }
    }
}
