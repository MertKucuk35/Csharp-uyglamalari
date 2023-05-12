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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        alisverisEntities db = new alisverisEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "sehir";
            comboBox1.DataSource = db.sehirler.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.musteri.ToList();
            var degerler = from x in db.musteri
                           select new
                           {
                               x.musteri_id,x.ad,x.soyad,x.sehir_no,x.bakiye
                              

                           };

            dataGridView1.DataSource = degerler.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri bilgi = new musteri();
            bilgi.ad = textBox2.Text;
            bilgi.soyad = textBox3.Text;
            bilgi.sehir_no = (short)(comboBox1.SelectedValue);
            bilgi.bakiye = Convert.ToDecimal(textBox5.Text);
           
            db.musteri.Add(bilgi);
            db.SaveChanges(); //executenonequery nin entity hali
            MessageBox.Show("Başarıyla Kaydedildi");
        }

        private void button3_Click(object sender, EventArgs e)
        {  
            
           int id = Convert.ToInt16(textBox1.Text);
           var x = db.musteri.Find(id);
            db.musteri.Remove(x);//o satırın tüm kayıtlarını tutar
            db.SaveChanges();
            MessageBox.Show("Musteri başarıyla silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox1.Text);
            var x = db.musteri.Find(id);
            x.ad = textBox2.Text;
            x.soyad = textBox3.Text;
            x.sehir_no = (short)(comboBox1.SelectedValue);
            x.bakiye = Convert.ToDecimal(textBox5.Text);
            db.SaveChanges();
            MessageBox.Show("Başarıyla güncellendi");
        }
    }
}
