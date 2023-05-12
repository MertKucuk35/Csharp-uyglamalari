using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uruntakib_entity
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
        alisverisEntities db = new alisverisEntities();
        private void Form3_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            label2.Text = db.musteri.Count().ToString();
            label4.Text = db.urun_tur.Count().ToString();
            label6.Text = db.urunler.Count().ToString();
            label8.Text = db.urunler.Count(x=>x.tur_no==1).ToString();//x öyleki
            label10.Text = db.urunler.Sum(x => x.stok).ToString();
            label12.Text = db.satislar.Count(x => x.tarih == bugun).ToString();
            label14.Text = db.satislar.Where(x=>x.tarih == bugun).Sum(y => y.toplam).ToString();

            label16.Text = (from x in db.urunler orderby x.satisfiyat descending
                                select x.urun_ad).FirstOrDefault();//firstordefault ilk sıradaki ürün adını seçeçek
            label18.Text = (from x in db.urunler
                            orderby x.satisfiyat 
                            select x.urun_ad).FirstOrDefault();

            label20.Text=db.satislar.Sum(x=>x.toplam).ToString();

            label22.Text = (from x in db.urunler orderby x.stok descending select x.urun_ad).FirstOrDefault();
            label24.Text = (from x in db.urunler orderby x.stok  select x.urun_ad).FirstOrDefault();
        }
    }
}
