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
    public partial class FPersonelAra : Form
    {
        public FPersonelAra()
        {
            InitializeComponent();
        }
        public int secilen_personel_id;
        private void PersonelLikeListele(int yetkiid,string ad, string soyad, string tel)
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
                cmd.CommandText = "PersonelLikeListele";

                cmd.Parameters.AddWithValue("@yetkiid", yetkiid);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@tel", tel);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dvgPersonel.DataSource = dt;
                dvgPersonel.ClearSelection();


                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }

        private void YetkiListele(int yetkiid)
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
                cmd.CommandText = "YetkiListele";

                cmd.Parameters.AddWithValue("@yetkiid", yetkiid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cbYetki.DataSource = dt;
                cbYetki.DisplayMember = "aciklama";
                cbYetki.ValueMember = "id";
                cbYetki.SelectedIndex = -1;

                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }


        private void FPersonelAra_Load(object sender, EventArgs e)
        {
            YetkiListele(-1);
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            string ad, soyad;
            try
            {
                if (txtAd.Text == "") ad = " ";
                else ad = txtAd.Text;

                if (txtSoyad.Text == "") soyad = " ";
                else soyad = txtSoyad.Text;

                if (txtTel.Text == "(   )    -" && cbYetki.SelectedValue == null)
                PersonelLikeListele(-1, ad, soyad, "");
            else if (txtTel.Text == "(   )    -" && cbYetki.SelectedValue != null)
                PersonelLikeListele(Convert.ToInt32(cbYetki.SelectedValue.ToString()), ad, soyad, "");
            else if (txtTel.TextLength == 14 && cbYetki.SelectedValue == null)
                PersonelLikeListele(-1, ad, soyad, txtTel.Text);
            else if (txtTel.TextLength == 14 && cbYetki.SelectedValue != null)
                PersonelLikeListele(Convert.ToInt32(cbYetki.SelectedValue.ToString()), ad, soyad, txtTel.Text);
            }
            catch
            {

            }


        /*
         tel    yetki
         ------------
         boş    boş
         boş    dolu
         dolu   boş 
         dolu   dolu
         */
        
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (secilen_personel_id > -1)
            {
                this.Close();
            }
        }

        private void dvgPersonel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                secilen_personel_id = Convert.ToInt32(
                dvgPersonel.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()); // seçilen satırın idsini alır

                this.Close();
            }
        }

        private void dvgPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                secilen_personel_id = Convert.ToInt32(
                  dvgPersonel.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()); // seçilen satırın idsini alır


            }
        }
    }
}
