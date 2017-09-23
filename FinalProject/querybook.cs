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
    public partial class querybook : Form
    {
        public querybook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Record where Customer_AccountNo=@Acc", cnn);
            cnn.Open();
            cmd.Parameters.Add("@Acc", SqlDbType.Char).Value = textBox1.Text;
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
                MessageBox.Show("查無此帳號或無訂票紀錄，請重新查詢");
                cmd.Clone();
                cnn.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//跟剛剛查詢會員完全依樣 只是變成查訂單
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Record where Record_ID=@ID", cnn);
            cnn.Open();
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = textBox2.Text;
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
                MessageBox.Show("查無此帳號或無訂票紀錄，請重新查詢");
                cmd.Clone();
                cnn.Close();
            }
        }

        private void querybook_Load(object sender, EventArgs e)
        {

        }
    }
}
