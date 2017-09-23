using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user f2 = new user(); 
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking f7 = new Booking();
            f7.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            querybook f8 = new querybook();
            f8.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f9 = new Form2();
            f9.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
