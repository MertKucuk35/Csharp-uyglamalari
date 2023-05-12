using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uruntakib_entity
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        alisverisEntities db = new alisverisEntities();
        private void Form2_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.urunler
                           select new
                           {
                               x.id,
                               x.urun_ad,
                               x.stok,
                               x.alis_fiyat,
                               x.satisfiyat,
                               x.markalar.marka_ad,
                               x.urun_tur.Tur,
                               x.marka_no,
                               x.tur_no
                           };
                      
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns["marka_no"].Visible = false;
            dataGridView1.Columns["tur_no"].Visible = false;

            comboBox1.DisplayMember = "Tur";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = db.urun_tur.ToList();

            comboBox2.DisplayMember = "marka_ad";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = db.markalar.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.urunler
                           select new
                           {
                               x.id,
                               x.urun_ad,
                               x.stok,
                               x.alis_fiyat,
                               x.satisfiyat,
                               x.markalar.marka_ad,
                               x.urun_tur.Tur,
                               x.marka_no,
                               x.tur_no
                           };

            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns["marka_no"].Visible = false;
            dataGridView1.Columns["tur_no"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue=Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            comboBox2.SelectedValue = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urunler urun = new urunler();
            urun.urun_ad = textBox2.Text;
            urun.marka_no = (short)(comboBox2.SelectedValue);
            urun.tur_no = (short)(comboBox1.SelectedValue);
            urun.alis_fiyat = Convert.ToDecimal(textBox3.Text);
            urun.satisfiyat = Convert.ToDecimal(textBox4.Text);
            urun.stok = Convert.ToInt16(numericUpDown1.Value);
            db.urunler.Add(urun);
            db.SaveChanges();
            MessageBox.Show("Başarıyla Kaydedildi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox1.Text);
            var sil = db.urunler.Find(id);
            db.urunler.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox1.Text);
            var x = db.urunler.Find(id);
            x.urun_ad = textBox2.Text;
            x.marka_no = (short)(comboBox2.SelectedValue);
            x.tur_no = (short)(comboBox1.SelectedValue);
            x.alis_fiyat = Convert.ToDecimal(textBox3.Text);
            x.satisfiyat = Convert.ToDecimal(textBox4.Text);
            x.stok = Convert.ToInt16(numericUpDown1.Value);
          
            db.SaveChanges();
            MessageBox.Show("Başarıyla Güncellendi");
            
        }
    }
}
