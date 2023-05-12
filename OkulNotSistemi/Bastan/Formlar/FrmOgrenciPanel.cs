using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bastan.Entity;
namespace Bastan.Formlar
{
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }
        public string numara;
        ogrencisinavEntities db = new ogrencisinavEntities();
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "bolum_id";
            comboBox1.DisplayMember = "bolum_ad";
            comboBox1.DataSource = db.bolumler.ToList();

            txtnumara.Text = numara;
            txtad.Text = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y=>y.ogr_ad).FirstOrDefault();
            txtsoyad.Text = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_soyad).FirstOrDefault();
           
            if (db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_cinsiyet).FirstOrDefault() == false)
                radioButton1.Checked=true;
            if (db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_cinsiyet).FirstOrDefault() == true)
                radioButton2.Checked = true;
                
            txtsifre.Text = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_sifre).FirstOrDefault();
            txtSifreTekrar.Text = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_sifre).FirstOrDefault();
            txtmail.Text = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_mail).FirstOrDefault();
            txtresim.Text = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.ogr_resim).FirstOrDefault();
            comboBox1.SelectedValue = db.ogrenciler.Where(x => x.ogr_numara == numara).Select(y => y.bolum).FirstOrDefault();

            dataGridView1.DataSource = db.notgetir7(numara);
            dataGridView1.Columns["ders"].Visible = false;
            dataGridView1.Columns["ogrenci"].Visible = false;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtsifre.Text == txtSifreTekrar.Text)
            {
                var tur = from x in db.ogrenciler select new { x.ogr_id, x.ogr_numara };

                var id = db.ogrenciler.Find(tur.Where(x => x.ogr_numara == numara).Select(y => y.ogr_id).FirstOrDefault());

                id.ogr_sifre = txtsifre.Text;

                db.SaveChanges();
                MessageBox.Show("Şifre başarıyla güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Şifreler aynı değiller", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
