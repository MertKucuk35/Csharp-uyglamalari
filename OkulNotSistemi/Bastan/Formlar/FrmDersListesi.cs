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
    public partial class FrmDersListesi : Form
    {
        ogrencisinavEntities db = new ogrencisinavEntities();
        public FrmDersListesi()
        {
            InitializeComponent();
        }

        private void FrmDersListesi_Load(object sender, EventArgs e)
        {
            var dersler=from x in db.dersler select new {x.ders_id,x.ders_ad};
            dataGridView1.DataSource =dersler.ToList();
        }
    }
}
