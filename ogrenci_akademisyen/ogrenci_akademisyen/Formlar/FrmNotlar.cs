using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ogrenci_akademisyen.Entity;

namespace ogrenic_akademisyen.Formlar
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=ogrencisinav;User ID=sert;Password=mert");
        ogrencisinavEntities db = new ogrencisinavEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "ders_ad";
            comboBox1.ValueMember = "ders_id";
            comboBox1.DataSource = db.dersler.ToList();
        
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            notlar not = new notlar();
            not.sinav1 = Convert.ToByte(txtSınav1.Text);
            not.sinav2 = Convert.ToByte(txtSınav2.Text);
            not.sinav3 = Convert.ToByte(txtSınav3.Text);
            not.quiz1 = Convert.ToByte(txtQuiz1.Text);
            not.quiz2 = Convert.ToByte(txtQuiz2.Text);
            not.proje = Convert.ToByte(txtProje.Text);
            not.ders = Convert.ToInt16(comboBox1.SelectedValue);
            not.ogrenci = Convert.ToInt16(txtOgrenci.Text);
            db.notlar.Add(not);
            db.SaveChanges();
            MessageBox.Show("Başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            byte sinav1, sinav2, sinav3,quiz1, quiz2, proje;
            double ortalama;
            sinav1 = Convert.ToByte(txtSınav1.Text);
            sinav2 = Convert.ToByte(txtSınav2.Text);
            sinav3 = Convert.ToByte(txtSınav3.Text);
            quiz1 = Convert.ToByte(txtQuiz1.Text);
            quiz2 = Convert.ToByte(txtQuiz2.Text);
            proje = Convert.ToByte(txtProje.Text);
            ortalama = (sinav1+sinav2+sinav3+quiz1+quiz2+proje)/6;
            txtOrtalama.Text = ortalama.ToString();
        }

      
    }
}
