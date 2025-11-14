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
    public partial class FMusteriAra : Form
    {
        public FMusteriAra()
        {
            InitializeComponent();
        }
        public int secilen_musteri_id;
        private void MusteriLikeListele(string ad, string soyad, string tel)
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
                cmd.CommandText = "MusteriLikeListele";

                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@tel", tel);

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


        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            if (txtTel.Text == "(   )    -")
                MusteriLikeListele(txtAd.Text, txtSoyad.Text, "");
            else if (txtTel.TextLength == 14)
                MusteriLikeListele(txtAd.Text, txtSoyad.Text, txtTel.Text);
        }

        private void dvgMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                 secilen_musteri_id = Convert.ToInt32(
                 dvgMusteri.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()); // seçilen satırın idsini alır

                this.Close();
            }
        }

        private void dvgMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
               secilen_musteri_id = Convert.ToInt32(
                 dvgMusteri.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()); // seçilen satırın idsini alır


            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
         
            if (secilen_musteri_id > -1)
            {
                this.Close();
            }
        }

        private void FMusteriAra_Load(object sender, EventArgs e)
        {

        }
    }
    
}
