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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
            groupBox3.Hide();
            button2.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Hide();
            groupBox1.Show();
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox3.Show();
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select * from markalar", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(listele);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into markalar(marka_ad) values(@markaad)", baglanti);
            ekle.Parameters.AddWithValue("@markaad", textBox3.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla eklendi");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("update markalar set marka_ad=@markaad where id=@Id ", baglanti);
            ekle.Parameters.AddWithValue("@markaad", textBox2.Text);
            ekle.Parameters.AddWithValue("@Id", textBox1.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("update markalar set marka_ad=@markaad where id=@Id ", baglanti);
            ekle.Parameters.AddWithValue("@markaad", textBox2.Text);
            ekle.Parameters.AddWithValue("@Id", textBox1.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla güncellendi");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SqlCommand ara = new SqlCommand("select * from markalar where id=@Id ", baglanti);
            ara.Parameters.AddWithValue("@Id", Microsoft.VisualBasic.Interaction.InputBox("Id", "Aranacak Id no girin", "", 10, 10));
            SqlDataAdapter adapte = new SqlDataAdapter(ara);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from markalar  where id=@Id ", baglanti);
            sil.Parameters.AddWithValue("@Id", Microsoft.VisualBasic.Interaction.InputBox("Id", "Silinecek Id no girin", "", 10, 10));
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla silindi");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
