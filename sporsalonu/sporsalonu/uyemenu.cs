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
    public partial class uyemenu : Form
    {
        public uyemenu()
        {
            InitializeComponent();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            uyeiletisim iletfr = new uyeiletisim();
            iletfr.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            bildirimler bilfr = new bildirimler();
            bilfr.Show();
            this.Hide();
        }
    }
}
