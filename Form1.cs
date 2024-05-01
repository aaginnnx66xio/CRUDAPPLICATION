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

namespace CRUD_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2DFCC0R\\SQLEXPRESS;Initial Catalog=CRUDSP_DB;Integrated Security=True;Encrypt=False");
            con.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cnn = new SqlCommand("select Username,Password from logintab where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");

            }
            con.Close();
        }
    }
}
