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

namespace FormdaEczaneUygulaması
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.;Database=eczanedb;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ilac", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ilac (ilacKodu, ilacAdi, fiyat, adet, fotograf) VALUES (@ilacKodu, @ilacAdi, @fiyat, @adet, @fotograf)", con);
                cmd.Parameters.AddWithValue("@ilacKodu", txtIlacKodu.Text);
                cmd.Parameters.AddWithValue("@ilacAdi", txtIlacAdi.Text);
                cmd.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(txtFiyat.Text));
                cmd.Parameters.AddWithValue("@adet", Convert.ToInt32(txtAdet.Text));
                cmd.Parameters.AddWithValue("@fotograf", txtFotografYolu.Text);
                cmd.ExecuteNonQuery();
                VerileriYukle();
                VerileriTemizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE ilac SET ilacKodu = @ilacKodu, ilacAdi = @ilacAdi, fiyat = @fiyat, adet = @adet, fotograf = @fotograf WHERE siraNo = @siraNo", con);
                cmd.Parameters.AddWithValue("@siraNo", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@ilacKodu", txtIlacKodu.Text);
                cmd.Parameters.AddWithValue("@ilacAdi", txtIlacAdi.Text);
                cmd.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(txtFiyat.Text));
                cmd.Parameters.AddWithValue("@adet", Convert.ToInt32(txtAdet.Text));
                cmd.Parameters.AddWithValue("@fotograf", txtFotografYolu.Text);
                cmd.ExecuteNonQuery();
                VerileriYukle();
                VerileriTemizle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ilac WHERE siraNo = @siraNo", con);
                cmd.Parameters.AddWithValue("@siraNo", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                VerileriYukle();
                VerileriTemizle();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtIlacKodu.Text = row.Cells[1].Value.ToString();
                txtIlacAdi.Text = row.Cells[2].Value.ToString();
                txtFiyat.Text = row.Cells[3].Value.ToString();
                txtAdet.Text = row.Cells[4].Value.ToString();
                txtFotografYolu.Text = row.Cells[5].Value.ToString();
                pictureBox1.ImageLocation = txtFotografYolu.Text;
            }
        }

        private void btnFotografSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFotografYolu.Text = ofd.FileName;
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            VerileriTemizle();
        }

        private void VerileriTemizle()
        {
            txtIlacKodu.Clear();
            txtIlacAdi.Clear();
            txtFiyat.Clear();
            txtAdet.Clear();
            txtFotografYolu.Clear();
            pictureBox1.Image = null;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ilac WHERE ilacAdi LIKE @arama OR ilacKodu LIKE @arama", con);
                da.SelectCommand.Parameters.AddWithValue("@arama", "%" + txtArama.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

       
    }
}
