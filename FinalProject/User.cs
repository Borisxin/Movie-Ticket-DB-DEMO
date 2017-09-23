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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            UpdateForm();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        public void UpdateForm() //更新user資料 顯示出來 這個就是把資料傳到剛剛灰色的那邊
        {
            SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");//連線
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", cnn);//輸入命令
            cnn.Open();
            SqlDataReader mydr = cmd.ExecuteReader();//讀取資料 他會把剛剛command取出來的資料讀進去
            DataTable tt = new DataTable();//創一個table
            tt.Load(mydr);//把資料丟到table裡面
            dataGridView1.DataSource = tt;//datagrid就是剛剛灰色的那個 讓他顯示table的資料 
            cmd.Clone();
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Insertuser f3 = new Insertuser();
            f3.ShowDialog();
            UpdateForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectuser f5 = new selectuser();
            f5.ShowDialog();
        }

        private void deleteuser_Click(object sender, EventArgs e)
        {
            deleteuser f4 = new deleteuser();
            f4.ShowDialog();
            UpdateForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            modiuser f6 = new modiuser();
            f6.ShowDialog();
            UpdateForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
