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
namespace Bastan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         ogrencisinavEntities db = new ogrencisinavEntities();
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=ogrencisinav;User ID=sert;Password=mert");
        

        private void btnresim_Click(object sender, EventArgs e)
        {
           
          //  resim.Filter = "*.jpg | *.png";
           if( openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
           {
               txtresim.Text = openFileDialog1.FileName;
            //   pictureBox1.ImageLocation = txtresim.Text;
           }
            
        }

        

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtad.Text.Length >= 2 && txtad.Text.Length <= 25 && txtsoyad.Text.Length >= 2 && txtsoyad.Text.Length <= 25 && txtsifre.Text == txtsifretekrar.Text && txtsifre.Text != "" && txtsifretekrar.Text != "")
            {
                ogrenciler ogr = new ogrenciler();
                ogr.ogr_ad = txtad.Text;
                ogr.ogr_soyad = txtsoyad.Text;
                if (radioButton1.Checked)
                    ogr.ogr_cinsiyet = false;
                if (radioButton2.Checked)
                    ogr.ogr_cinsiyet = true;
                ogr.ogr_numara = txtnumara.Text;
                ogr.ogr_sifre = txtad.Text;
                ogr.ogr_mail = txtmail.Text;
               ogr.ogr_resim = txtresim.Text;
               ogr.bolum = Convert.ToInt16(comboBox1.SelectedValue);

                db.ogrenciler.Add(ogr);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Sifrenizi Kontrol Edin","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtresim_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsifretekrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnumara_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand bolum = new SqlCommand("select * from bolumler", baglanti);
            SqlDataAdapter adaptebolum = new SqlDataAdapter(bolum);
            DataTable tablobolum = new DataTable();
            adaptebolum.Fill(tablobolum);
            comboBox1.ValueMember = "bolum_id";
            comboBox1.DisplayMember = "bolum_ad";
            comboBox1.DataSource = tablobolum;
        }
    }
}
