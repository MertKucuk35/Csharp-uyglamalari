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
namespace Alisveris
{
    public partial class urunalma : Form
    {
        public urunalma()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        DataSet1TableAdapters.urunlerTableAdapter urun = new DataSet1TableAdapters.urunlerTableAdapter();
        
       DataSet1TableAdapters.musteriTableAdapter musteri = new DataSet1TableAdapters.musteriTableAdapter();
       
        private void urunalma_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember="urun_ad";
            comboBox1.ValueMember="id";
            comboBox1.DataSource=urun.urunara();

            comboBox2.DisplayMember="isim";
            comboBox2.ValueMember="msuteri_id";
            comboBox2.DataSource=musteri.musteribilgi();

            dataGridView1.DataSource = urun.urunget();
            dataGridView1.Columns["alis_fiyat"].Visible = false;
            dataGridView1.Columns["marka_no"].Visible = false;
            dataGridView1.Columns["stok"].Visible = false;
            dataGridView1.Columns["tur_no"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("exec satisraporlari", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns[0].Visible = true;
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand urunara = new SqlCommand("exec urunara @urunad",baglanti);
            urunara.Parameters.AddWithValue("@urunad", textBox2.Text);
            SqlDataAdapter urunadapte = new SqlDataAdapter(urunara);
            DataTable uruntablo = new DataTable();
            urunadapte.Fill(uruntablo);
            dataGridView1.DataSource = uruntablo;
            dataGridView1.Columns[0].Visible = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            numericUpDown1.Value = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = (numericUpDown1.Value * Convert.ToDecimal(textBox5.Text)).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = (numericUpDown1.Value * Convert.ToDecimal(textBox5.Text)).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand satinal = new SqlCommand("exec alis @urun,@musteri,@adet", baglanti);
              satinal.Parameters.AddWithValue("@urun", comboBox1.SelectedValue.ToString());
              satinal.Parameters.AddWithValue("@musteri",comboBox2.SelectedValue.ToString());
              satinal.Parameters.AddWithValue("@adet",numericUpDown1.Value.ToString());
              satinal.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Urun Satin Alinmiştir");
        }
    }
}
