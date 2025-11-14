using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ice_Store
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            FLogin flogin = new FLogin();
            flogin.ShowDialog();

            if (flogin.durum == "basarili")
                aktifkul.Text = flogin.aktifkullanici;
            else
                this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            FMusteri musteri = new FMusteri();
            musteri.ShowDialog();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FPersonel pers = new FPersonel();
            pers.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FDepoIslemleri fdi = new FDepoIslemleri();
            fdi.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            FLocaHareketRapor asd = new FLocaHareketRapor();
            asd.ShowDialog();
        }
    }
}
