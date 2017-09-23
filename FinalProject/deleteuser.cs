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
    public partial class deleteuser : Form
    {
        public deleteuser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("確定刪除此筆資料?", "確定刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//delete
            if (ans == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog=FinalProject2;Integrated Security = SSPI");
                string sql = "Delete Customer where Customer_ID=@id";//where是指定某個欄位的某個值對他做指令
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = textBox1.Text;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
                Close();
            }
        }

        private void deleteuser_Load(object sender, EventArgs e)
        {

        }
    }
}
