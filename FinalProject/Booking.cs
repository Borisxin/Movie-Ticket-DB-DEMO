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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
            SqlConnection Conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog =FinalProject2;Integrated Security =SSPI");
            SqlCommand Command,Comm,co;
            SqlDataReader reader,rea,re;
            Conn.Open();
            Command = new SqlCommand("select * from Movie_theater", Conn);
            reader = Command.ExecuteReader();
            while (reader.Read())//這邊是上次老師做的 他會把讀到的資料傳到combobox 
            {
                comboBox1.Items.Add(reader["Movie_theater_NAME"]);
            }
            reader.Close();
            Comm = new SqlCommand("Select * from TicketType", Conn);
            rea = Comm.ExecuteReader();
            while(rea.Read())
            {
                comboBox6.Items.Add(rea["TicketType"]);
            }
            rea.Close();
            comboBox7.Items.Clear();
            co = new SqlCommand("select * from Meal ", Conn);
            re = co.ExecuteReader();
            while (re.Read())
            {
                comboBox7.Items.Add(re["MealContent"]);
            }
            re.Close();
            comboBox5.Items.Clear();
            SqlCommand Cmmd;
            SqlDataReader read;
            Cmmd = new SqlCommand("select * from Payment ", Conn);
            read = Cmmd.ExecuteReader();
            while (read.Read())
            {
                comboBox5.Items.Add(read["payType"]);
            }
            read.Close();
            
            Conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlConnection Conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog = FinalProject2;Integrated Security =SSPI");
            SqlCommand Cmd;
            SqlDataReader rea;
            Conn.Open();
            int d;
            if(comboBox1.Text.Trim()=="花蓮店")
            {
                d = 1001;
            }
            else
            {
                d = 1002;
            }
            Cmd = new SqlCommand("select * from Show where Movie_theater_ID=@ID", Conn);
            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = d;
            rea = Cmd.ExecuteReader();
            while (rea.Read())
            {
                comboBox2.Items.Add(rea["Movie_Name"]);
            }
            int count = comboBox2.Items.Count;
            int i;
            for (i = 0; i < count; i++)//這邊就是用來刪除重複的
            {
                string str = comboBox2.Items[i].ToString();
                for (int j = i + 1; j < count; j++)
                {
                    string str1 = comboBox2.Items[j].ToString();
                    if (str1 == str)
                    {
                        comboBox2.Items.RemoveAt(j);
                        count--;
                        j--;
                    }
                }
            }
            Conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog = FinalProject2;Integrated Security =SSPI");
            SqlCommand Cmd, Command,Cd;
            SqlDataReader rea,re;
            Conn.Open();
            Cmd = new SqlCommand("select Customer_AccountNo,Customer_Password from Customer where Customer_AccountNo=@ACC", Conn);
            Cmd.Parameters.Add("@Acc", SqlDbType.Char).Value = textBox1.Text;
            rea = Cmd.ExecuteReader();
            if (rea.Read())
            {
                string s1, s2;
                int d;
                if (comboBox1.Text.Trim() == "花蓮店")
                {
                    d = 1001;
                }
                else
                {
                    d = 1002;
                }
                int t;             
                if(comboBox5.Text.Trim()=="信用卡")
                {
                    t = 1;
                }
                else if(comboBox5.Text.Trim()=="現金")
                {
                    t = 2;
                }
                else
                {
                    t = 3;
                }
                int m;
                if(comboBox7.Text.Trim()=="薯條")
                {
                    m = 1;
                }
                else if(comboBox7.Text.Trim()=="薯條加可樂")
                {
                    m = 2;
                }
                else
                {
                    m = 3;
                }
                s1 = rea.GetString(rea.GetOrdinal("Customer_Password")).Trim();
                s2 = textBox2.Text.Trim();
                if (s1.Equals(s2))//判斷密碼是否正確 假如正確就進行訂票
                {
                    rea.Close();//下面那一串就是輸入訂票資訊 跟剛剛的會員依樣 這邊大概就這樣 都是在填值
                    Command=new SqlCommand("Insert into Record(Movie_theater_ID,TypeNo,Customer_AccountNo,Movie_Name,Transaction_Time,MealNo,TicketType,Language,Session) values(@ID,@Type,@Acc,@Name,Getdate(),@Meal,@Ticket,@Lan,@Se);", Conn);
                    Command.Parameters.Add("@Name", SqlDbType.Char).Value = comboBox2.Text.Trim();
                    Command.Parameters.Add("@Ticket", SqlDbType.Char).Value =comboBox6.Text.Trim();
                    Command.Parameters.Add("@Acc", SqlDbType.Char).Value = textBox1.Text;
                    Command.Parameters.Add("@Type", SqlDbType.Int).Value = t;
                    Command.Parameters.Add("@ID", SqlDbType.Int).Value = d;
                    Command.Parameters.Add("@Se", SqlDbType.Char).Value = comboBox3.Text.Trim();
                    Command.Parameters.Add("@Lan", SqlDbType.Char).Value = comboBox4.Text.Trim();
                    Command.Parameters.Add("@Meal", SqlDbType.Int).Value = m;
                    Command.ExecuteNonQuery();
                    Command.Dispose();
                    Cd = new SqlCommand("select TOP 1 Record_ID FROM Record ORDER BY Record_ID DESC", Conn);
                    re = Cd.ExecuteReader();
                    re.Read();
                    int i = re.GetInt32(re.GetOrdinal("Record_ID"));
                    MessageBox.Show("成功! 此訂單編號為："+i+"  您可以至訂單查詢處進行查詢。");  
                       
                }
                else
                {
                    MessageBox.Show("帳號或密碼錯誤!");
                }
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤!");
            }
            Conn.Close();
            Close();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            SqlConnection Conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog = FinalProject2;Integrated Security =SSPI");
            SqlCommand Cmd;
            SqlDataReader rea;
            Conn.Open();
            int d;
            if (comboBox1.Text.Trim() == "花蓮店")
            {
                d = 1001;
            }
            else
            {
                d = 1002;
            }
            Cmd = new SqlCommand("select * from Show where Movie_Name=@Name and Movie_theater_ID=@ID", Conn);
            Cmd.Parameters.Add("@Name", SqlDbType.Char).Value = comboBox2.Text;
            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = d;
            rea = Cmd.ExecuteReader();
            while (rea.Read())
            {
                comboBox4.Items.Add(rea["Language"]);
            }
            int count = comboBox4.Items.Count;
            int i;
            for (i = 0; i < count; i++)
            {
                string str = comboBox4.Items[i].ToString();
                for (int j = i + 1; j < count; j++)
                {
                    string str1 = comboBox4.Items[j].ToString();
                    if (str1 == str)
                    {
                        comboBox4.Items.RemoveAt(j);
                        count--;
                        j--;
                    }
                }
            }
            Conn.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlConnection Conn = new SqlConnection("Data Source=127.0.0.1\\SQLEXPRESS;Initial catalog =FinalProject2;Integrated Security =SSPI");
            SqlCommand Cmd;
            SqlDataReader rea;
            Conn.Open();
            int d;
            if (comboBox1.Text.Trim() == "花蓮店")
            {
                d = 1001;
            }
            else
            {
                d = 1002;
            }
            Cmd = new SqlCommand("select * from Show where Movie_Name=@Name and Movie_theater_ID=@ID and Language=@Lan", Conn);
            Cmd.Parameters.Add("@Name", SqlDbType.Char).Value = comboBox2.Text;
            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = d;
            Cmd.Parameters.Add("@Lan", SqlDbType.Char).Value = comboBox4.Text;
            rea = Cmd.ExecuteReader();
            while (rea.Read())
            {
                comboBox3.Items.Add(rea["Session"]);
            }
            int count=comboBox3.Items.Count;
            int i;
            for (i = 0; i < count; i++)
            {
                string str = comboBox3.Items[i].ToString();
                for (int j=i+1; j < count; j++)
                {
                    string str1 = comboBox3.Items[j].ToString();
                    if (str1 == str)
                    {
                        comboBox3.Items.RemoveAt(j);
                        count--;
                        j--;
                    }
                }
            }
            rea.Close();
            
            Conn.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
                    }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text.Clone();
            if(comboBox6.Text.Trim()=="優待票")
            {
                textBox6.Text = "220";
            }
            else
            {
                textBox6.Text = "250";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
