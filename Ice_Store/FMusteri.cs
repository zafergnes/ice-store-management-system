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
        int secilen_id;
        private void Temizle()
        {
            secilen_id = 0;
            txtTel.Text = "";
            txtSoyad.Clear();
            txtAd.Clear();
            dvgMusteri.ClearSelection();
        }
        private void MusteriSil(int musteriid)
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
                cmd.CommandText = "MusteriSil";

                cmd.Parameters.AddWithValue("@musteriid", musteriid);

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

        private void MusteriEkle(string adi, string soyadi, string teli)
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

                cmd.Parameters.AddWithValue("@ad", adi);
                cmd.Parameters.AddWithValue("@soyad", soyadi);
                cmd.Parameters.AddWithValue("@tel", teli);

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
        private void MusteriGuncelle(int musteriid, string adi, string soyadi, string teli)
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
                cmd.CommandText = "MusteriGuncelle";

                cmd.Parameters.AddWithValue("@musteriid", musteriid);
                cmd.Parameters.AddWithValue("@ad", adi);
                cmd.Parameters.AddWithValue("@soyad", soyadi);
                cmd.Parameters.AddWithValue("@tel", teli);

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

                dvgMusteri.Columns["adsoyad"].Visible = false;
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
            if (txtAd.Text != "" && txtSoyad.Text != "" && txtTel.Text != "(   )      _")
            {
                MusteriEkle(txtAd.Text, txtSoyad.Text, txtTel.Text);
                MusteriListele(-1);
                Temizle();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FMusteriAra fma = new FMusteriAra();
            fma.ShowDialog();

            //MessageBox.Show(fma.secilen_musteri_id+ " ");
            MusteriListele(fma.secilen_musteri_id);
            secilen_id = fma.secilen_musteri_id;


            txtAd.Text = dvgMusteri.Rows[0].Cells[1].Value.ToString();
            txtSoyad.Text = dvgMusteri.Rows[0].Cells[2].Value.ToString();
            txtTel.Text = dvgMusteri.Rows[0].Cells[3].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilen_id > 0)
            {
                DialogResult cevap = MessageBox.Show("Emin misin?", "Silme Onayı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    MusteriSil(secilen_id);
                    MusteriListele(-1);
                    Temizle();
                }
            }
            else
                MessageBox.Show("Lütfen bir müşteri seçiniz");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilen_id > 0 && txtAd.Text != "" && txtSoyad.Text != "" && txtTel.Text != "(   )      _")
            {
                MusteriGuncelle(secilen_id, txtAd.Text, txtSoyad.Text, txtTel.Text);
                MusteriListele(-1);
                Temizle();
            }
        }

        private void dvgMusteri_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                secilen_id = Convert.ToInt32(dvgMusteri.Rows[e.RowIndex].Cells[0].Value.ToString());

                txtAd.Text = dvgMusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoyad.Text = dvgMusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTel.Text = dvgMusteri.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }


}
