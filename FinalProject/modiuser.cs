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
    public partial class modiuser : Form
    {
        public modiuser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//修改 
        {
            DialogResult ans = MessageBox.Show("確定修改此筆資料?", "確定新增",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");
                string sql = "Update  Customer Set Customer_Name=@Name,Customer_Phone=@Phone,Customer_Email=@Email,Customer_AccountNo=@Account,Customer_Password=@pass,Customer_Birthday=@Birth,Customer_Occupation=@Occ Where Customer_ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = textBox1.Text;
                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = textBox2.Text;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = textBox3.Text;
                cmd.Parameters.Add("@Account", SqlDbType.Char).Value = textBox4.Text;
                cmd.Parameters.Add("@pass", SqlDbType.Char).Value = textBox5.Text;
                cmd.Parameters.Add("@Birth", SqlDbType.Date).Value = textBox6.Text;
                cmd.Parameters.Add("@Occ", SqlDbType.Char).Value = textBox7.Text;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = textBox8.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                Close();
            }
        }

        private void modiuser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name, tel, mail, account, pass, bir, occ;
            int idd = Int32.Parse(textBox8.Text);
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");//帳號查詢
            SqlCommand cmd = new SqlCommand("SELECT Customer_Name,Customer_Phone,Customer_Email,Customer_AccountNo,Customer_Password,Customer_Birthday,Customer_Occupation FROM Customer where Customer_ID=@ID", cnn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = idd;
            cnn.Open();
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            name = read.GetString(read.GetOrdinal("Customer_Name")).Trim();
            tel = read.GetDecimal(read.GetOrdinal("Customer_Phone")).ToString();
            mail = read.GetString(read.GetOrdinal("Customer_Email")).Trim();
            account = read.GetString(read.GetOrdinal("Customer_AccountNo")).Trim();
            pass = read.GetString(read.GetOrdinal("Customer_Password")).Trim();
            bir = read.GetDateTime(read.GetOrdinal("Customer_Birthday")).ToString("d");
            occ = read.GetString(read.GetOrdinal("Customer_Occupation")).Trim();
            textBox1.Text = name;
            textBox2.Text = tel;
            textBox3.Text = mail;
            textBox4.Text = account;
            textBox5.Text = pass;
            textBox6.Text = bir;
            textBox7.Text = occ;
            cnn.Close();
        }
    }
}
