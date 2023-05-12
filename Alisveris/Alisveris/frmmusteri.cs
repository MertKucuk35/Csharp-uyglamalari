using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alisveris
{
    public partial class frmmusteri : Form
    {
        public frmmusteri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.musteriTableAdapter bilgi = new DataSet1TableAdapters.musteriTableAdapter();
        DataSet1TableAdapters.sehirlerTableAdapter city = new DataSet1TableAdapters.sehirlerTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = bilgi.musterilistesi();
            dataGridView1.Columns["sehir_no"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bilgi.musterikayit(textBox2.Text, textBox3.Text, Convert.ToInt16(comboBox1.SelectedValue), Convert.ToDecimal(textBox5.Text));
            MessageBox.Show("Musteri Kaydedildi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bilgi.musterisil(Convert.ToInt16(textBox1.Text));
            MessageBox.Show("Musteri Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void frmmusteri_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "sehir";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = city.sehirler();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bilgi.musteriguncelle(textBox2.Text, textBox3.Text, Convert.ToDecimal(textBox5.Text), Convert.ToInt16(comboBox1.SelectedValue),Convert.ToInt16(textBox1.Text));
            MessageBox.Show("Musteri Bilgileri Güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
       
                dataGridView1.DataSource = bilgi.adara(textBox6.Text);
            }

            if (radioButton2.Checked)
            {

                dataGridView1.DataSource = bilgi.soyadara(textBox6.Text);
            }

            if (radioButton3.Checked)
            {

                dataGridView1.DataSource = bilgi.sehirara(textBox6.Text);
            }
        }
    }
}
