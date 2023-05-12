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
using Bastan.Entity;
namespace Bastan.Formlar
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=ogrencisinav;User ID=sert;Password=mert");
        ogrencisinavEntities db = new ogrencisinavEntities();
        void listele()
        {
            var bilgi = from x in db.ogrenciler select new { x.ogr_id, x.ogr_ad, x.ogr_soyad, x.ogr_cinsiyet, x.ogr_numara, x.ogr_sifre, x.ogr_mail, x.ogr_resim, x.bolumler.bolum_ad, x.bolum, x.durum };
            dataGridView1.DataSource = bilgi.Where(z => z.durum == true).ToList();

        }
        void listelepasif()
        {
            var bilgi = from x in db.ogrenciler select new { x.ogr_id, x.ogr_ad, x.ogr_soyad, x.ogr_cinsiyet, x.ogr_numara, x.ogr_sifre, x.ogr_mail, x.ogr_resim, x.bolumler.bolum_ad, x.bolum, x.durum };
            dataGridView1.DataSource = bilgi.Where(z => z.durum == false).ToList();

        }
        
       
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns["bolum"].Visible = false;
            dataGridView1.Columns["durum"].Visible = false;
            SqlCommand bolum = new SqlCommand("select * from bolumler", baglanti);
            SqlDataAdapter adaptebolum = new SqlDataAdapter(bolum);
            DataTable tablobolum = new DataTable();
            adaptebolum.Fill(tablobolum);
            comboBox1.DisplayMember = "bolum_ad";
            comboBox1.ValueMember = "bolum_id";
            comboBox1.DataSource = tablobolum;


        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == false)
                radioButton1.Checked = true;
            if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == true)
                radioButton2.Checked = true;
            txtnumara.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtresim.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                int ogrid = Convert.ToInt16(txtid.Text);
                var bilgi = db.ogrenciler.Find(ogrid);
                bilgi.durum = false;
                db.SaveChanges();
                MessageBox.Show("Başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                errorProvider1.SetError(txtid, "Id boş bırakılamaz");
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtad.Text != "" && txtad.Text.Length >= 2 && txtad.Text.Length <= 25 && txtsoyad.Text != "" && txtsoyad.Text.Length >= 2 && txtsoyad.Text.Length <= 25 && txtmail.Text.Length >= 15 && txtmail.Text.Length <= 50 && txtmail.Text != "" && txtsifre.Text.Length >= 2 && txtsifre.Text.Length <= 10 && txtsifre.Text != "")
            {
                int ogrid = Convert.ToInt16(txtid.Text);
                var bilgi = db.ogrenciler.Find(ogrid);
                bilgi.ogr_ad = txtad.Text;
                bilgi.ogr_soyad = txtsoyad.Text;
                if (radioButton1.Checked)
                    bilgi.ogr_cinsiyet = false;
                if (radioButton2.Checked)
                    bilgi.ogr_cinsiyet = true;
                bilgi.ogr_numara = txtnumara.Text;
                bilgi.ogr_sifre = txtsifre.Text;
                bilgi.ogr_mail = txtmail.Text;
                bilgi.ogr_resim = txtresim.Text;
                bilgi.bolum = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bilgilerinizi kontrol edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void btnpasif_Click(object sender, EventArgs e)
        {
             listelepasif();
        }

        private void btnresim_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                txtresim.Text = openFileDialog1.FileName;
            }
        }

    }
}
