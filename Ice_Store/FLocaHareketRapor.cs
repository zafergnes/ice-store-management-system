using Microsoft.Office.Interop.Excel;
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
    public partial class FLocaHareketRapor : Form
    {
        public FLocaHareketRapor()
        {
            InitializeComponent();
        }
        public int depoislemid = -1;

        private void DepoIslemleriLikeListele(int urunsahibiid, int urunid, int locaid)
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
                cmd.CommandText = "DepoIslemleriLikeListele";

                cmd.Parameters.AddWithValue("@urunsahibiid", urunsahibiid);
                cmd.Parameters.AddWithValue("@urunid", urunid);
                cmd.Parameters.AddWithValue("@locaid", locaid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                System.Data.DataTable dt = new System.Data.DataTable();

                da.Fill(dt);

                dvgUrunHareket.DataSource = dt;
                dvgUrunHareket.ClearSelection();


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

                System.Data.DataTable dt = new System.Data.DataTable();

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
        private void UrunSahibiListele(int musteriid)
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

                System.Data.DataTable dt = new System.Data.DataTable();

                da.Fill(dt);

                cbUrunSahibi.DataSource = dt;
                cbUrunSahibi.DisplayMember = "adsoyad";
                cbUrunSahibi.ValueMember = "id";
                cbUrunSahibi.SelectedIndex = -1;
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

                System.Data.DataTable dt = new System.Data.DataTable();

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
        private void FLocaHareketRapor_Load(object sender, EventArgs e)
        {
            LocaListele(-1);
            UrunSahibiListele(-1);
            UrunTurListele(-1);
        }

        private void cbUrunSahibi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // raporlama kısmını geliştiriniz
            // silinen ve güncellenen combobox ekleyin. stroed procedure içinde filtreleyin.

            try
            {
                if (cbUrunSahibi.SelectedIndex > -1 || cbUrun.SelectedIndex > -1 || cbLoca.SelectedIndex > -1)
                {
                    int urunid, urunsahibiid, locaid;

                    if (cbUrunSahibi.SelectedIndex > -1)
                        urunsahibiid = Convert.ToInt32(cbUrunSahibi.SelectedValue.ToString());
                    else
                        urunsahibiid = -1;

                    if (cbUrun.SelectedIndex > -1)
                        urunid = Convert.ToInt32(cbUrun.SelectedValue.ToString());
                    else
                        urunid = -1;

                    if (cbLoca.SelectedIndex > -1)
                        locaid = Convert.ToInt32(cbLoca.SelectedValue.ToString());
                    else
                        locaid = -1;

                    DepoIslemleriLikeListele(urunsahibiid, urunid, locaid);
                }
            }
            catch
            {

            }

        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            //Workbook workbook = excel.Workbooks.Add(Missing);
            //  Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            Workbook workbook = new Workbook();

            Worksheet worksheet = workbook.Worksheets.Add("WriteToCells");

            int baslamakolonu = 1;
            int baslamasatiri = 1;
           // for (int j = 0; j < dvgUrunHareket.Columns.Count; j++)
          //  {
                worksheet.Range[1, 1].Value = "Hello, World";


            //}
            workbook.SaveToFile("WriteDataToCells.xlsx", ExcelVersion.Version2016);

            // Dispose resources
            workbook.Dispose();

            */
        }
    }
}
