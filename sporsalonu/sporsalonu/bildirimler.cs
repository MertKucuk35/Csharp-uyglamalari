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
    public partial class bildirimler : Form
    {
        public bildirimler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALLENWALKER;Initial Catalog=gym;User ID=sert;Password=mert");
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void bildirimler_Load(object sender, EventArgs e)
        {
           
        }
    }
}
