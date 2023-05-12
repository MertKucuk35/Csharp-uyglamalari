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
    public partial class uyeiletisim : Form
    {
        public uyeiletisim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
       
        
     
        private void uyeiletisim_Load(object sender, EventArgs e)
        {
            
   
            baglanti.Open();
            SqlCommand yukle = new SqlCommand("select * from mesajicerik", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(yukle);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            comboBox1.DisplayMember = "icerik";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { int c=0;
            string usid="";
            string mesaj = "";
            string kullanici = textBox1.Text;
           
            for (int i = 0; i < richTextBox1.Lines.LongLength; i++)
                mesaj = mesaj + richTextBox1.Lines[i]+" ";
           
            baglanti.Open();
            SqlCommand ara=new SqlCommand ("select id from uye where mail=@Mail",baglanti);
            ara.Parameters.AddWithValue("@Mail",kullanici);
            SqlDataReader oku = ara.ExecuteReader();
            if (oku.Read())
            { usid = oku[0].ToString();
            c = 1;
            }
            else
                MessageBox.Show("Mailinizi Kontrol Edin");
            baglanti.Close();
            if (c == 1)
            {
                baglanti.Open();
                SqlCommand gonder = new SqlCommand("insert into uyemesajlari(userid,tur,mesaj) values(@Userid,@Tur,@Mesaj)", baglanti);
                gonder.Parameters.AddWithValue("@Userid", usid);
                gonder.Parameters.AddWithValue("@Tur", comboBox1.SelectedValue);
                gonder.Parameters.AddWithValue("@Mesaj", mesaj);
                gonder.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Mesajınız Gönderildi");
            }

            else
                MessageBox.Show("Mailinizi Kontrol Edin");
        }
    }
}
