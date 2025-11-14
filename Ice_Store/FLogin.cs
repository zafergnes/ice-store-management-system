using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ice_Store
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        public string con_str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ice_store; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string aktifkullanici = "";
        
        public string durum = "başarısız";
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(con_str);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand sorgula = new SqlCommand("select * from personel where " +
                "" +
                "kul_ad ='" + txtKulAd.Text + "' and sifre='" + txtSifre.Text + "'",conn);
            SqlDataReader dr = sorgula.ExecuteReader();

            if(dr.Read())
            {
                durum = "basarili";
                aktifkullanici = txtKulAd.Text;
                this.Close();



            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifreniz yanlış.");

            }
        }

        private void txtKulAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                    txtSifre.Focus();
            }

        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                //btnGiris.Focus();
                btnGiris_Click(sender, e);
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
            durum = "başarısız";
        }
    }
}
