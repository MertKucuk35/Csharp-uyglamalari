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
using Bastan.Entity;
namespace Bastan.Formlar
{
    public partial class FrmNotlar : Form
    {
     public void  ortalama()
        {
            byte sinav1, sinav2, sinav3, quiz1, quiz2, proje;
            double ortalama;
            sinav1 = Convert.ToByte(txtSınav1.Text);
            sinav2 = Convert.ToByte(txtSınav2.Text);
            sinav3 = Convert.ToByte(txtSınav3.Text);
            quiz1 = Convert.ToByte(txtQuiz1.Text);
            quiz2 = Convert.ToByte(txtQuiz2.Text);
            proje = Convert.ToByte(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + quiz1 + quiz2 + proje) / 6;
            txtOrtalama.Text = ortalama.ToString();
           
        }
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

            comboBox2.DisplayMember = "ders_ad";
            comboBox2.ValueMember = "ders_id";
            comboBox2.DataSource = db.dersler.ToList();

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
          //  ortalama();
          //  not.ortalama = Convert.ToByte(txtOrtalama.Text);
            db.notlar.Add(not);
            db.SaveChanges();
            MessageBox.Show("Başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            ortalama();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.notgetir8();
            // ya da
            // var deger = from x in select new          
         //{ ÖğrenciAdı=x.ogrenciadı+" "+x.ogrencisoyadı  bu sekilde ograd+' '+ogrsoyad ın entity hali yazılır
        //}  
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.notgetir9(Convert.ToInt16(comboBox2.SelectedValue));
            dataGridView1.Columns["ders"].Visible = false;
            dataGridView1.Columns["ogrenci"].Visible = false;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=db.notgetir7(txtOgrNo.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtQuiz1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtQuiz2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            

           
            
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
           
         int   notid = Convert.ToInt16(txtid.Text);
        
         var notbilgisi = db.notlar.Find(notid);
            notbilgisi.sinav1 = Convert.ToInt16(txtSınav1.Text);
            notbilgisi.sinav2 = Convert.ToInt16(txtSınav2.Text);
            notbilgisi.sinav3 = Convert.ToInt16(txtSınav3.Text);
            notbilgisi.quiz1 = Convert.ToInt16(txtQuiz1.Text);
            notbilgisi.quiz2 = Convert.ToInt16(txtQuiz2.Text);
            notbilgisi.proje = Convert.ToInt16(txtProje.Text);
            db.SaveChanges();
            MessageBox.Show("Başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
