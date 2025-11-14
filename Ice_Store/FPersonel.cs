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
    public partial class FPersonel : Form
    {
        public FPersonel()
        {
            InitializeComponent();
        }
        int secilen_id;
        private void PersonelSil(int personelid)
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
                cmd.CommandText = "PersonelSil";

                cmd.Parameters.AddWithValue("@personelid", personelid);

                int i = cmd.ExecuteNonQuery();

                if (i == 0)
                {
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
      
        private void Temizle()
        {
            secilen_id = 0;
            txtTel.Text = "";
            txtSoyad.Clear();
            txtAd.Clear();
            txtkulad.Text = "";
            txtsifre.Clear();
            cbYetki.SelectedIndex = -1 ;
            dvgPersonel.ClearSelection();
        }

        private void PersonelEkle(string adi, string soyadi, string teli,int yetkiid, string kulad,string sifre)
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
                cmd.CommandText = "PersonelEkle";

                cmd.Parameters.AddWithValue("@ad", adi);
                cmd.Parameters.AddWithValue("@soyad", soyadi);
                cmd.Parameters.AddWithValue("@tel", teli);
                cmd.Parameters.AddWithValue("@yetkiid", yetkiid);
                cmd.Parameters.AddWithValue("@kulad", kulad);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                int i = cmd.ExecuteNonQuery();

                if (i == 0)
                {
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
      
        private void PersonelGuncelle(int personelid, string adi, string soyadi, string teli, int yetkiid, string kulad, string sifre)
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
                cmd.CommandText = "PersonelGuncelle";

                cmd.Parameters.AddWithValue("@personelid", personelid);
                cmd.Parameters.AddWithValue("@ad", adi);
                cmd.Parameters.AddWithValue("@soyad", soyadi);
                cmd.Parameters.AddWithValue("@tel", teli);
                cmd.Parameters.AddWithValue("@yetkiid", yetkiid);
                cmd.Parameters.AddWithValue("@kulad", kulad);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                int i = cmd.ExecuteNonQuery();

                if (i == 0)
                {
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
      
        private void PersonelListele(int personelid)
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
                cmd.CommandText = "PersonelListele";

                cmd.Parameters.AddWithValue("@personelid", personelid);

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

        private void FPersonel_Load(object sender, EventArgs e)
        {
            YetkiListele(-1);
            PersonelListele(-1);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbYetki.SelectedValue.ToString()) > 0 && txtAd.Text != "" && txtSoyad.Text != "" && txtTel.Text != "(   )      _")
            {
                PersonelEkle(txtAd.Text, txtSoyad.Text, txtTel.Text, Convert.ToInt32(cbYetki.SelectedValue.ToString()),txtkulad.Text,txtsifre.Text);
                PersonelListele(-1);
                Temizle();
            }

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FPersonelAra fpa = new FPersonelAra();
            fpa.ShowDialog();


            PersonelListele(fpa.secilen_personel_id);
            secilen_id = fpa.secilen_personel_id;


            txtAd.Text = dvgPersonel.Rows[0].Cells[1].Value.ToString();
            txtSoyad.Text = dvgPersonel.Rows[0].Cells[2].Value.ToString();
            txtTel.Text = dvgPersonel.Rows[0].Cells[3].Value.ToString(); 
            cbYetki.SelectedValue = Convert.ToInt32(dvgPersonel.Rows[0].Cells[4].Value.ToString());
            txtkulad.Text = dvgPersonel.Rows[0].Cells[6].Value.ToString();
            txtsifre.Text = dvgPersonel.Rows[0].Cells[7].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilen_id > 0)
            {
                DialogResult cevap = MessageBox.Show("Emin misin?", "Silme Onayı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    PersonelSil(secilen_id);
                    PersonelListele(-1);
                    Temizle();
                }
            }
            else
                MessageBox.Show("Lütfen bir müşteri seçiniz");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilen_id > 0 && Convert.ToInt32(cbYetki.SelectedValue.ToString()) > 0 && txtAd.Text != "" && txtSoyad.Text != "" && txtTel.Text != "(   )      _")
                {
                    PersonelGuncelle(secilen_id, txtAd.Text, txtSoyad.Text, txtTel.Text, Convert.ToInt32(cbYetki.SelectedValue.ToString()), txtkulad.Text, txtsifre.Text);
                    PersonelListele(-1);
                    Temizle();
            }
        }

        private void dvgPersonel_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                secilen_id = Convert.ToInt32(dvgPersonel.Rows[e.RowIndex].Cells[0].Value.ToString());

                txtAd.Text = dvgPersonel.Rows[0].Cells[1].Value.ToString();
                txtSoyad.Text = dvgPersonel.Rows[0].Cells[2].Value.ToString();
                txtTel.Text = dvgPersonel.Rows[0].Cells[3].Value.ToString();
                cbYetki.SelectedValue = Convert.ToInt32(dvgPersonel.Rows[0].Cells[4].Value.ToString());
                txtkulad.Text = dvgPersonel.Rows[0].Cells[6].Value.ToString();
                txtsifre.Text = dvgPersonel.Rows[0].Cells[7].Value.ToString();

            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
