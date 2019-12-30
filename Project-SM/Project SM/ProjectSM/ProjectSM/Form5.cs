using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSM
{
    public partial class Form5 : Form
    {
        public Form5(string connectionString)
        {
            InitializeComponent();
            textBox1.Text = connectionString; 
        }
        public string conn = "";
        private void button1_Click(object sender, EventArgs e)
        {
            conn = textBox1.Text.ToString();
            Close();
        }
    }
}
