using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ogrenci_akademisyen.Entity;
namespace ogrenic_akademisyen.Formlar
{
    public partial class FrmBolumler : Form
    {
        ogrencisinavEntities db = new ogrencisinavEntities();
        public FrmBolumler()
        {
            InitializeComponent();
        }

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                errorProvider1.SetError(textBox1, "Bölüm adı boş bırakılamaz");//1.parametre çalışacağı nesne 2. parametre mesaj
            }
             
            else
            {
                bolumler blm=new bolumler();
                blm.bolum_ad=textBox1.Text;
                db.bolumler.Add(blm);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
