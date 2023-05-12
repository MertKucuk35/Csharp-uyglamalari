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
    public partial class FrmBolumListesi : Form
    {
        public FrmBolumListesi()
        {
            InitializeComponent();
        }
        ogrencisinavEntities db = new ogrencisinavEntities();
        private void btnlistele_Click(object sender, EventArgs e)
        {


        }

        private void FrmBolumListele_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.bolumler select new { x.bolum_id, x.bolum_ad };
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns["ders"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
