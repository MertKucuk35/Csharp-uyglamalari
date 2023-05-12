using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sporsalonu
{
    public partial class adminmenu : Form
    {
        public adminmenu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            uyeislem uyeislemfr = new uyeislem();
            uyeislemfr.Show();
            this.Hide();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            stokislem stokfr = new stokislem();
            stokfr.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            adminmesaj mesajfr = new adminmesaj();
            mesajfr.Show();
            this.Hide();
        }
    }
}
