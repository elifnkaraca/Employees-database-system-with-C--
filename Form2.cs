using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSql
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-JN1G6OQ7\\SQLEXPRESS;Initial Catalog=kitaplik;Integrated Security=True");
     
        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from kisiler", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand kayitEkle = new SqlCommand("insert into kisiler (KisiNo,Ad,Soyad,Meslek,Sehir,Maas) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            kayitEkle.Parameters.AddWithValue("@p1", textBox1.Text);
            kayitEkle.Parameters.AddWithValue("@p2", textBox7.Text);
            kayitEkle.Parameters.AddWithValue("@p3", textBox3.Text);
            kayitEkle.Parameters.AddWithValue("@p4", textBox4.Text);
            kayitEkle.Parameters.AddWithValue("@p5", textBox5.Text);
            kayitEkle.Parameters.AddWithValue("@p6", textBox6.Text);

            kayitEkle.ExecuteNonQuery();

            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("delete from kisiler where Ad = @adi", baglanti);
            komutsil.Parameters.AddWithValue("adi", textBox7.Text);

            komutsil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            String no = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            String ad = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            String soyad = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            String meslek = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            String sehir = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            String maas = dataGridView2.Rows[secilen].Cells[5].Value.ToString();

            textBox1.Text = no; //somut olarak gormek icin boxlara atiyorum
            textBox7.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = meslek;
            textBox5.Text = sehir;
            textBox6.Text = maas;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update kisiler set KisiNo=@p1, Ad=@p2, Soyad=@p3, Meslek=@p4, Sehir=@p5, Maas=@p6 where KisiNo=@p1", baglanti);

            komutGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", textBox7.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", textBox3.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", textBox4.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", textBox5.Text);
            komutGuncelle.Parameters.AddWithValue("@p6", textBox6.Text);

            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from kisiler where Ad = '" + textBox7.Text + "'", baglanti);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select max(Maas) from kisiler", baglanti);
            SqlDataReader oku = komut1.ExecuteReader();

            while (oku.Read())
            {
                label14.Text = oku[0].ToString();

            }

            baglanti.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select count(Ad) from kisiler", baglanti);
            SqlDataReader oku = komut1.ExecuteReader();

            while (oku.Read())
            {
                label15.Text = oku[0].ToString();

            }

            baglanti.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select sum(Maas) from kisiler", baglanti);
            SqlDataReader oku = komut1.ExecuteReader();

            while (oku.Read())
            {
                label16.Text = oku[0].ToString();

            }

            baglanti.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select avg(Maas) from kisiler", baglanti);
            SqlDataReader oku = komut1.ExecuteReader();

            while (oku.Read())
            {
                label17.Text = oku[0].ToString();

            }

            baglanti.Close();
        }
    }
}
