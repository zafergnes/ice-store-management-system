using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ice_Store
{
    public partial class FMusteri : Form
    {
        public FMusteri()
        {
            InitializeComponent();
        }
        private void MusteriEkle(string adi,string soyadi,string teli)
        {
            try
            {
                FLogin login = new FLogin();
                SqlConnection conn = new SqlConnection(login.con_str);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MusteriEkle";

                cmd.Parameters.AddWithValue("@ad",adi);
                cmd.Parameters.AddWithValue("@soyad",soyadi);
                cmd.Parameters.AddWithValue("@tel",teli);

                int i = cmd.ExecuteNonQuery();

                if (i == 0) {
                    MessageBox.Show("Başarısız");
                }
                else
                {
                    MessageBox.Show("Başarılı");
                }
                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void MusteriListele(int musteriid)
        {
            try
            {
                FLogin login = new FLogin();
                SqlConnection conn = new SqlConnection(login.con_str);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MusteriListele";

                cmd.Parameters.AddWithValue("@musteri_id", musteriid);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dvgMusteri.DataSource = dt;
                dvgMusteri.ClearSelection();

                
                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void FMusteri_Load(object sender, EventArgs e)
        {
            MusteriListele(-1);
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(txtAd.Text != "" && txtSoyad.Text !="" && txtTel.Text != "(   )      _")
            {
                MusteriEkle(txtAd.Text,txtSoyad.Text,txtTel.Text);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            
        }
    }

    
}
