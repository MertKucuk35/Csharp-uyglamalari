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
namespace sporsalonu
{
    public partial class adminmesaj : Form
    {
        public adminmesaj()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand okunmamis = new SqlCommand("select * from uyemesajlari where okunma=0", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(okunmamis);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand okunmamis = new SqlCommand("select * from uyemesajlari where okunma=1", baglanti);
            SqlDataAdapter adapte = new SqlDataAdapter(okunmamis);
            DataTable tablo = new DataTable();
            adapte.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listBox1.Items.Clear();
            label3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            label4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            listBox1.Items.Add(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminmesaj_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminid = "";
            string yaniti = "";
            for (int i = 0; i < richTextBox1.Lines.LongLength; i++)
                yaniti = yaniti + richTextBox1.Lines[i] + " ";

                baglanti.Open();
            SqlCommand admin = new SqlCommand("select id from admin where adminad=@Ad", baglanti);
            admin.Parameters.AddWithValue("@Ad", textBox1.Text);
            SqlDataReader okuyucu = admin.ExecuteReader();
            if (okuyucu.Read() & textBox1.Text != null)
                adminid = okuyucu[0].ToString();
            baglanti.Close();

            baglanti.Open();
            SqlCommand yanit = new SqlCommand("insert into mesajcevap(mesajid,userid,adminid,yanit) values(@Mesajid,@Userid,@Adminid,@Yanit)", baglanti);
            yanit.Parameters.AddWithValue("@Mesajid", label3.Text);
            yanit.Parameters.AddWithValue("@Userid", label4.Text);
            yanit.Parameters.AddWithValue("@Adminid", adminid);
            yanit.Parameters.AddWithValue("@Yanit", yaniti);
            yanit.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            SqlCommand okundu = new SqlCommand("update uyemesajlari set okunma=1 where id=@Id",baglanti);
            okundu.Parameters.AddWithValue("@Id",label3.Text);
            okundu.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Yanit gönderildi");
        }
    }
}
