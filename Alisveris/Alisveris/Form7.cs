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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=alisveris;User ID=sert;Password=mert");
        private void Form7_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsayi = new SqlCommand("select count(*) from urunler", baglanti);
            SqlDataReader oku = urunsayi.ExecuteReader();
            while(oku.Read())
            {
                label2.Text = oku[0].ToString();
            }
         
        }
    }
}
