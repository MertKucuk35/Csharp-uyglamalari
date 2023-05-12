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
    public partial class stokislem : Form
    {
        public stokislem()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel4_Click(object sender, EventArgs e)
        {
            istatistikstok istfrm = new istatistikstok();
            istfrm.Show();
            this.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            urunislem urnfrm = new urunislem();
            urnfrm.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
