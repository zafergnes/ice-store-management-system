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

        private void MusteriLikeListele(string ad , string soyad , string tel)
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
                cmd.Parameters.AddWithValue("@tel", "");

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dvgMusteri.DataSource = dt;
                dvgMusteri.ClearSelection();


                cmd.Dispose();
                conn.Close();
            }

            catch (Exception)
            {

                throw;
            }
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            MusteriLikeListele(txtAd.Text,txtSoyad.Text,txtTel.Text);
           
        }
    }
}
