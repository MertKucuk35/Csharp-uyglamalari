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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
            groupBox3.Hide();
            button7.Enabled = false;
            
            SqlCommand turekle = new SqlCommand("select * from urun_tur", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(turekle);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            comboBox1.DisplayMember = "Tur";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = tablo;
            comboBox4.DisplayMember = "Tur";
            comboBox4.ValueMember = "id";
            comboBox4.DataSource = tablo;

            SqlCommand markaekle = new SqlCommand("select * from markalar  ", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(markaekle);
            DataTable markatablo = new DataTable();
            adp.Fill(markatablo);
            comboBox2.DisplayMember = "marka_ad";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = markatablo;
            comboBox3.DisplayMember = "marka_ad";
            comboBox3.ValueMember = "id";
            comboBox3.DataSource = markatablo;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select urunler.id,urun_ad,markalar.marka_ad,urun_tur.Tur,alis_fiyat,satisfiyat,stok,marka_no,tur_no from urunler inner join urun_tur on (urunler.tur_no=urun_tur.id) inner join markalar on (markalar.id=urunler.marka_no)", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
            dataGridView1.Columns["marka_no"].Visible = false;
            dataGridView1.Columns["tur_no"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into urunler(urun_ad,marka_no,tur_no,alis_fiyat,satisfiyat,stok) values(@urunad,@markano,@turno,@alisfiyat,@satisfiyat,@Stok)", baglanti);
            ekle.Parameters.AddWithValue("@urunad",textBox1.Text);
             ekle.Parameters.AddWithValue("@markano",comboBox2.SelectedValue);
             ekle.Parameters.AddWithValue("@turno", comboBox1.SelectedValue);
             ekle.Parameters.AddWithValue("@alisfiyat",textBox4.Text);
             ekle.Parameters.AddWithValue("@satisfiyat",textBox5.Text);
             ekle.Parameters.AddWithValue("@Stok", numericUpDown1.Value);
             ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Urun başarıyla eklendi");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
            groupBox1.Show();
            button8.Enabled = true;
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox1.Hide();
            button8.Enabled = false;
            button7.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update urunler set urun_ad=@urunad,marka_no=@markano,tur_no=@turno,alis_fiyat=@alisfiyat,satisfiyat=@satisfiyat,stok=@Stok where id=@Id", baglanti);
            guncelle.Parameters.AddWithValue("@urunad", textBox13.Text);
            guncelle.Parameters.AddWithValue("@markano", comboBox3.SelectedValue);
            guncelle.Parameters.AddWithValue("@turno", comboBox4.SelectedValue);
            guncelle.Parameters.AddWithValue("@alisfiyat", Convert.ToDecimal(textBox10.Text));
            guncelle.Parameters.AddWithValue("@satisfiyat", Convert.ToDecimal(textBox9.Text));
            guncelle.Parameters.AddWithValue("@Stok", numericUpDown2.Value);
            guncelle.Parameters.AddWithValue("@Id", textBox7.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Urun başarıyla Güncellendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from urunler where id=@Id", baglanti);
            sil.Parameters.AddWithValue("@Id", Microsoft.VisualBasic.Interaction.InputBox("Id", "Silmek istediğiniz ürünün Id'si", "", 10, 10));
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Basariyla silindi");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {// numeric up down ve combobox için dönüşüm gerekli
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox3.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox4.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            numericUpDown2.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
        }
    }
}
//Data Source=192.168.1.34;Initial Catalog=alisveris;User ID=sert;Password=mert