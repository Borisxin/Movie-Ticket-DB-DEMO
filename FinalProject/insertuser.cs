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
    public partial class Insertuser : Form
    {
        public Insertuser()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("確定新增此筆資料?", "確定新增",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);//當按下button 會跳出messagebox詢問 後面那個是旁邊的圖案 會顯示問號
            if (ans == System.Windows.Forms.DialogResult.Yes)//假如是選yes的話就會執行
            {
                SqlConnection conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");//連線
                string sql = "Insert into Customer(Customer_Name,Customer_Phone,Customer_Email,Customer_AccountNo,Customer_Password,Customer_Birthday,Customer_Occupation) values(@Name,@Phone,@Email,@Account,@pass,@Birth,@Occ);";//給指令 @是c#給參數的方法  順序必須相同 前面第一個是customer_name  values後面第一個就要給name的值
                SqlCommand cmd = new SqlCommand(sql, conn);//這應該是輸入指令才對 你比一下
                cmd.Parameters.Add("@Name", SqlDbType.Char).Value = textBox1.Text; //給參數值 (前面輸入是哪個參數,datatype.value後面是給值)
                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = textBox2.Text;
                cmd.Parameters.Add("@Email", SqlDbType.Char).Value = textBox3.Text;
                cmd.Parameters.Add("@Account", SqlDbType.Char).Value = textBox4.Text;
                cmd.Parameters.Add("@pass", SqlDbType.Char).Value = textBox5.Text;
                cmd.Parameters.Add("@Birth", SqlDbType.Date).Value = textBox6.Text;
                cmd.Parameters.Add("@Occ", SqlDbType.Char).Value = textBox7.Text;
                conn.Open();//打開連線 和資料庫的連線
                cmd.ExecuteNonQuery();//執行命令 他就會執行上面輸入的那一長串
                SqlCommand Cd = new SqlCommand("select TOP 1 Customer_ID FROM Customer ORDER BY Customer_ID DESC", conn);
                SqlDataReader re = Cd.ExecuteReader();
                re.Read();
                int i = re.GetInt32(re.GetOrdinal("Customer_ID"));
                MessageBox.Show("成功! 此訂單編號為：" + i + "  您可以至訂單查詢處進行查詢。");
                cmd.Dispose();//類似關閉指令吧 
                conn.Close();//中斷連線
                Close();//關閉視窗
            }
        }

        private void Insertuser_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
