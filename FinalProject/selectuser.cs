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
    public partial class selectuser : Form
    {
        //打在這
        public selectuser()
        {
            InitializeComponent();
        }

        private void selectuser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");//帳號查詢
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer where Customer_Name=@Name", cnn);
            cnn.Open();
            cmd.Parameters.Add("@Name", SqlDbType.Char).Value = textBox1.Text.Trim();
            SqlDataReader mydr = cmd.ExecuteReader();
            DataTable tt = new DataTable();
            if (mydr.HasRows)//假如有資料的話 就繼續執行 mydr是? read的變數他用來讀資料 然後讀到傳給load 然後顯示資料?恩 
            {
                tt.Load(mydr);
                dataGridView1.DataSource = tt;//把資料放在灰色區
                cmd.Clone();
                cnn.Close();
            }
            else
            {
                MessageBox.Show("錯誤 查無此姓名帳號!");
                cmd.Clone();
                cnn.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");//甚麼時候要有這行連線的? 當你要連資料庫的時候 每個function開頭都要打 不然就要打在最上面 這裡是要連甚麼 依樣是給指令阿 上面是用ˋ帳號查詢 這邊用編號查詢
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer where Customer_ID=@ID", cnn);//為什麼查詢要用到DB? 你要從資料庫抓資料壓 所以我輸入的值 會傳到DB? 
            cnn.Open();
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = textBox2.Text.Trim();
            SqlDataReader mydr = cmd.ExecuteReader();
            DataTable tt = new DataTable();
            if (mydr.HasRows)//下面也依樣 只是用來查詢的東西不同
            {
                tt.Load(mydr);
                dataGridView1.DataSource = tt;
                cmd.Clone();
                cnn.Close();
            }
            else
            {
                MessageBox.Show("錯誤 查無此編號帳號!");
                cmd.Clone();
                cnn.Close();
            }
        }
    }
}
