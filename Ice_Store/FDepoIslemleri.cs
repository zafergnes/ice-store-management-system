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
    public partial class FDepoIslemleri : Form
    {
        public FDepoIslemleri()
        {
            InitializeComponent();
        }
        int hareket_id = -1;
        private void LocaHareketSil(int id)
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
                cmd.CommandText = "LocaHareketSil";

                cmd.Parameters.AddWithValue("@id", id);

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
            hareket_id = 0;
            cbAlici.SelectedIndex = -1;
            cbBirim.SelectedIndex = -1;
            cbLoca.SelectedIndex = -1;
            cbOdemeTip.SelectedIndex = -1;
            cbParaBirim.SelectedIndex = -1;
            cbSatici.SelectedIndex = -1;
            cbUrun.SelectedIndex = -1;
            cbUrunHareket.SelectedIndex = -1;

            txtMiktar.Text = "";
            txtTutar.Text = "";

            chkKiralikmi.Checked = false;

            dvgUrunHareket.ClearSelection();
        }

        private void LocaListele(int locaid)
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
                cmd.CommandText = "LocaListele";

                cmd.Parameters.AddWithValue("@locaid", locaid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cbLoca.DataSource = dt;
                cbLoca.DisplayMember = "aciklama";
                cbLoca.ValueMember = "id";
                cbLoca.SelectedIndex = -1;

                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void saticiMusteriListele(int musteriid)
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

                cbSatici.DataSource = dt;
                cbSatici.DisplayMember = "adsoyad";
                cbSatici.ValueMember = "id";
                cbSatici.SelectedIndex = -1;


                
                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void AliciMusteriListele(int musteriid)
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

                cbAlici.DataSource = dt;
                cbAlici.DisplayMember = "adsoyad";
                cbAlici.ValueMember = "id";
                cbAlici.SelectedIndex = -1;
                cmd.Dispose();
                conn.Close();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void UrunTurListele(int urunturid)
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
                cmd.CommandText = "UrunTurListele";

                cmd.Parameters.AddWithValue("@id", urunturid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cbUrun.DataSource = dt;
                cbUrun.DisplayMember = "aciklama";
                cbUrun.ValueMember = "id";
                cbUrun.SelectedIndex = -1;
              
                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void UrunBirimListele(int urunbirimid)
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
                cmd.CommandText = "UrunBirimListele";

                cmd.Parameters.AddWithValue("@id", urunbirimid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cbBirim.DataSource = dt;
                cbBirim.DisplayMember = "aciklama";
                cbBirim.ValueMember = "id";
                cbBirim.SelectedIndex = -1;

                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void ParaBirimListele(int parabirimid)
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
                cmd.CommandText = "ParaBirimListele";

                cmd.Parameters.AddWithValue("@id", parabirimid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cbParaBirim.DataSource = dt;
                cbParaBirim.DisplayMember = "aciklama";
                cbParaBirim.ValueMember = "id";
                cbParaBirim.SelectedIndex = -1;

                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void OdemeTipListele(int odemetipid)
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
                cmd.CommandText = "OdemeTipListele";

                cmd.Parameters.AddWithValue("@id", odemetipid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cbOdemeTip.DataSource = dt;
                cbOdemeTip.DisplayMember = "aciklama";
                cbOdemeTip.ValueMember = "id";
                cbOdemeTip.SelectedIndex = -1;

                cmd.Dispose();
                conn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void AlisSatisListele(int hareketid)
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
                cmd.CommandText = "AlisSatisListele";

                cmd.Parameters.AddWithValue("@id", hareketid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dvgUrunHareket.DataSource = dt;
                dvgUrunHareket.ClearSelection();

                //dvgUrunHareket.Columns["adsoyad"].Visible = false;
                cmd.Dispose();
                conn.Close();
  
                dvgUrunHareket.Columns["urun_sahibi_musteri_id"].Visible = false;
                dvgUrunHareket.Columns["kiralikmi"].Visible = false;
                dvgUrunHareket.Columns["urun_tur_id"].Visible = false;
                dvgUrunHareket.Columns["loca_id"].Visible = false;
                dvgUrunHareket.Columns["urun_hareket_id"].Visible = false;
                dvgUrunHareket.Columns["urun_birim_id"].Visible = false;
                dvgUrunHareket.Columns["alici_satici_musteri_id"].Visible = false;
                dvgUrunHareket.Columns["odeme_tip_id"].Visible = false;
                dvgUrunHareket.Columns["para_birim_id"].Visible = false;


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.ToString());
            }
        }
        private void LocaHareketGuncelle(int hareketid, int alici_id, int birim_id, int loca_id, int odeme_tip_id, int para_birim_id,
            int satici_id, int urun_id, int urun_hareket_id, int miktar, double tutar, Boolean kiralikmi)
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
                cmd.CommandText = "LocaHareketGuncelle";

                cmd.Parameters.AddWithValue("@id", hareketid);
                cmd.Parameters.AddWithValue("@kiralikmi", kiralikmi);
                cmd.Parameters.AddWithValue("@urun_tur_id", urun_id);
                cmd.Parameters.AddWithValue("@urun_miktar", miktar);
                cmd.Parameters.AddWithValue("@saticiid", satici_id);
                cmd.Parameters.AddWithValue("@loca_id", loca_id);
                cmd.Parameters.AddWithValue("@urun_hareket_id", urun_hareket_id);
                cmd.Parameters.AddWithValue("@alici_id", alici_id);
                cmd.Parameters.AddWithValue("@urun_birim_id", birim_id);
                cmd.Parameters.AddWithValue("@odeme_tip_id", odeme_tip_id);
                cmd.Parameters.AddWithValue("@para_birim_id", para_birim_id);
                cmd.Parameters.AddWithValue("@tutar", tutar);

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

        private void AlisSatisEkle(int alici_id,int birim_id,int loca_id,int odeme_tip_id,int para_birim_id,
            int satici_id,int urun_id,int urun_hareket_id,int miktar, double tutar,Boolean kiralikmi)
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
                cmd.CommandText = "AlisSatisEkle";

                cmd.Parameters.AddWithValue("@kiralikmi", kiralikmi);
                cmd.Parameters.AddWithValue("@urun_tur_id",urun_id);
                cmd.Parameters.AddWithValue("@urun_miktar", miktar);
                cmd.Parameters.AddWithValue("@saticiid", satici_id);
                cmd.Parameters.AddWithValue("@loca_id", loca_id);
                cmd.Parameters.AddWithValue("@urun_hareket_id", urun_hareket_id);
                cmd.Parameters.AddWithValue("@alici_id", alici_id);
                cmd.Parameters.AddWithValue("@urun_birim_id", birim_id);
                cmd.Parameters.AddWithValue("@odeme_tip_id", odeme_tip_id);
                cmd.Parameters.AddWithValue("@para_birim_id", para_birim_id);
                cmd.Parameters.AddWithValue("@tutar", tutar);

              
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
        private void FDepoIslemleri_Load(object sender, EventArgs e)
        {
            LocaListele(-1);
            saticiMusteriListele(-1);
            AliciMusteriListele(-1);
            UrunTurListele(-1);
            UrunBirimListele(-1);
            ParaBirimListele(-1);
            OdemeTipListele(-1);
            AlisSatisListele(-1);
        }

        private void cbAlici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAlici.SelectedIndex>-1 && cbSatici.SelectedIndex > -1) 
            {
                try
                {
                    int secilisaticiID=0;
                    if (cbSatici.SelectedIndex>-1)
                         secilisaticiID = Convert.ToInt32(cbSatici.SelectedValue.ToString());

                    int seciliAliciID=0;
                    if (cbAlici.SelectedIndex > -1)
                         seciliAliciID = Convert.ToInt32(cbAlici.SelectedValue.ToString());

                    if (seciliAliciID == secilisaticiID)
                    {
                        MessageBox.Show("Alıcı ve satıcı aynı olamaz");
                        cbAlici.SelectedIndex = -1;
                    }
                }
                catch
                {

                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(hareket_id >0)
            {
                // güncellemek istiyordun(hareket id 0 dan büyük olduguna göre) 
                // son anda ekle butonuna bastın.
                // içinde bulunduğuın if olmasaydı, verinin yeni haliyle tekrar bir kopyası olacaktı.
                // oysaki ben burda bu hatayı engellemekte görevliyim.

                MessageBox.Show("Sanırım yanlışlığla bu duğmeye pastın. Güncelleme butonuna mı basacaktın gardaş.");
                return;
            }
            if (cbAlici.SelectedIndex>-1 && cbBirim.SelectedIndex > -1 && cbLoca.SelectedIndex > -1 && cbOdemeTip.SelectedIndex > -1 &&
                cbParaBirim.SelectedIndex > -1 && cbSatici.SelectedIndex > -1 &&
                cbUrun.SelectedIndex > -1 &&cbUrunHareket.SelectedIndex > -1 && txtMiktar.Text!= "" && txtTutar.Text!="")
            {
                Boolean kiralik = false;
                if (chkKiralikmi.Checked == true) kiralik = true;
                else kiralik = false;

                int hareket=-1;
                if (cbUrunHareket.SelectedIndex==0) hareket= 1;
                else if (cbUrunHareket.SelectedIndex == 1) hareket = 0;


                AlisSatisEkle(Convert.ToInt32(cbAlici.SelectedValue.ToString()),
                              Convert.ToInt32(cbBirim.SelectedValue.ToString()),
                              Convert.ToInt32(cbLoca.SelectedValue.ToString()),
                              Convert.ToInt32(cbOdemeTip.SelectedValue.ToString()),
                              Convert.ToInt32(cbParaBirim.SelectedValue.ToString()),
                              Convert.ToInt32(cbSatici.SelectedValue.ToString()),
                              Convert.ToInt32(cbUrun.SelectedValue.ToString()) ,
                              hareket,
                              Convert.ToInt32(txtMiktar.Text.ToString()), Convert.ToDouble(txtTutar.Text) ,
                              kiralik);
                AlisSatisListele(-1);
                //Temizle();
            }
        }

        private void cbLoca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FDepoIslemleriAra fdia = new FDepoIslemleriAra();
            fdia.ShowDialog();
           
            AlisSatisListele(fdia.depoislemid);
            hareket_id = fdia.depoislemid;
            /*
             * not: ara formu sonrasında hareket id verisine göre listelenen depo işlemlerine ait veriler içerisine
                    locaid, odeme_tip_id vb int verileri de datagridview nesnesine ekledim.
                    
                    aranan verinin güncelleme işlemi öncesinde combobox, textbox gibi nesneler içerisine doldurulması gerektiği için
                    bu verilerin id lerine ihtiyaç duydum. Bu sebeple stored procedure içinde ilgili kolonların id lerini listeledim.
                    datagrid view içinde de bunları gizledim. Bu veriler dgv da 13. kolondan başlayıp 21. kolondsa son buldu.
             
             */

            cbAlici.SelectedValue= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[13].Value.ToString());
           
            if (Convert.ToBoolean(dvgUrunHareket.Rows[0].Cells[14].Value) == true ) chkKiralikmi.Checked = true;
            else chkKiralikmi.Checked = false;

            cbUrun.SelectedValue= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[15].Value.ToString());
            cbLoca.SelectedValue= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[16].Value.ToString());
           
            cbUrunHareket.SelectedIndex= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[17].Value.ToString()) -1 ;
           
            cbBirim.SelectedValue= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[18].Value.ToString());
            cbSatici.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[19].Value.ToString());
            cbOdemeTip.SelectedValue= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[20].Value.ToString());
            cbParaBirim.SelectedValue= Convert.ToInt32(dvgUrunHareket.Rows[0].Cells[21].Value.ToString());

            txtMiktar.Text = dvgUrunHareket.Rows[0].Cells[6].Value.ToString();
            txtTutar.Text = dvgUrunHareket.Rows[0].Cells[9].Value.ToString();
        }

        private void dvgUrunHareket_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1)
            {
                hareket_id = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[0].Value.ToString());

                cbAlici.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[13].Value.ToString());

                if (Convert.ToBoolean(dvgUrunHareket.Rows[e.RowIndex].Cells[14].Value) == true) chkKiralikmi.Checked = true;
                else chkKiralikmi.Checked = false;

                cbUrun.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[15].Value.ToString());
                cbLoca.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[16].Value.ToString());

                cbUrunHareket.SelectedIndex = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[17].Value.ToString()) - 1;

                cbBirim.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[18].Value.ToString());
                cbSatici.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[19].Value.ToString());
                cbOdemeTip.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[20].Value.ToString());
                cbParaBirim.SelectedValue = Convert.ToInt32(dvgUrunHareket.Rows[e.RowIndex].Cells[21].Value.ToString());

                txtMiktar.Text = dvgUrunHareket.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtTutar.Text = dvgUrunHareket.Rows[e.RowIndex].Cells[9].Value.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (hareket_id > 0)
            {
                DialogResult cevap = MessageBox.Show("Emin misin?", "Silme Onayı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    LocaHareketSil(hareket_id);
                    AlisSatisListele(-1);
                    Temizle();
                }
            }
            else
                MessageBox.Show("Lütfen bir müşteri seçiniz");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (hareket_id > 0 && cbAlici.SelectedIndex > -1 && cbBirim.SelectedIndex > -1 && cbLoca.SelectedIndex > -1 && cbOdemeTip.SelectedIndex > -1 &&
                cbParaBirim.SelectedIndex > -1 && cbSatici.SelectedIndex > -1 &&
                cbUrun.SelectedIndex > -1 && cbUrunHareket.SelectedIndex > -1 && txtMiktar.Text != "" && txtTutar.Text != "")
             {
                Boolean kiralik = false;
                if (chkKiralikmi.Checked == true) kiralik = true;
                else kiralik = false;

                int hareket = -1;
                if (cbUrunHareket.SelectedIndex == 0) hareket = 1;
                else if (cbUrunHareket.SelectedIndex == 1) hareket = 0;




                LocaHareketGuncelle(hareket_id, Convert.ToInt32(cbAlici.SelectedValue.ToString()),
                              Convert.ToInt32(cbBirim.SelectedValue.ToString()),
                              Convert.ToInt32(cbLoca.SelectedValue.ToString()),
                              Convert.ToInt32(cbOdemeTip.SelectedValue.ToString()),
                              Convert.ToInt32(cbParaBirim.SelectedValue.ToString()),
                              Convert.ToInt32(cbSatici.SelectedValue.ToString()),
                              Convert.ToInt32(cbUrun.SelectedValue.ToString()),
                              hareket,
                              Convert.ToInt32(txtMiktar.Text.ToString()), Convert.ToDouble(txtTutar.Text),
                              kiralik);
                AlisSatisListele(-1);
                Temizle();
            }
        }
    }
}
