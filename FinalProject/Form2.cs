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
namespace FinalProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UpdateForm();
            SqlConnection Conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog = FinalProject2;Integrated Security =SSPI");
            SqlCommand Command;
            SqlDataReader reader;
            Conn.Open();
            Command = new SqlCommand("select * from Movie_theater", Conn);
            reader = Command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Movie_theater_ID"]);
            }
            reader.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public void UpdateForm()//顯示電影表 
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Show", cnn);
            cnn.Open();
            SqlDataReader mydr = cmd.ExecuteReader();
            DataTable tt = new DataTable();
            tt.Load(mydr);
            dataGridView1.DataSource = tt;
            cmd.Clone();
            cnn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Show where Movie_theater_ID=@ID", cnn);
            cnn.Open();
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = comboBox1.Text;
            SqlDataReader mydr = cmd.ExecuteReader();
            if (mydr.HasRows)
            {
                DataTable tt = new DataTable();
                tt.Load(mydr);
                dataGridView1.DataSource = tt;
                cmd.Clone();
                cnn.Close();
            }
            else
            {
                MessageBox.Show("查無此影城代號，請重新查詢");
                cmd.Clone();
                cnn.Close();
            }
        }
    }
}
