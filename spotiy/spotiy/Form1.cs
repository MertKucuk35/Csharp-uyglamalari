using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spotiy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer1.Ctlcontrols.pause();
           
        }
        string link = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if(openfiledialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                this.link = openfiledialog.FileName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = link;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog klasor = new FolderBrowserDialog();
            if(klasor.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                string secilen = klasor.SelectedPath;
                DirectoryInfo secileninici = new DirectoryInfo(secilen);
                FileInfo[] sonuc =secileninici.GetFiles();
                
                foreach(FileInfo  dosya in sonuc)
                {
                    if (dosya.Extension == ".mp3" || dosya.Extension == ".mp4")
                    {
                        listBox1.Items.Add( dosya);
                        listBox2.Items.Add(secilen+"\\"+dosya);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text=listBox1.Items[listBox1.SelectedIndex].ToString();
           link = listBox2.Items[listBox1.SelectedIndex].ToString();
           button3_Click(button3, new EventArgs());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
           
        }

      
    }
}
