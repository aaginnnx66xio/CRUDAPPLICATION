using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Application
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2DFCC0R\\SQLEXPRESS;Initial Catalog=CRUDSP_DB;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            int cusid = int.Parse(textBox1.Text);
            string cusname = textBox2.Text, city = comboBox1.Text, gender = comboBox2.Text, contact = textBox4.Text;
            double age = double.Parse(textBox3.Text);
            con.Open();
            SqlCommand c = new SqlCommand("exec InsertCus_SP '" + cusid + "','" + cusname + "','" + city + "','" + age + "','" + gender + "','" + contact + "'", con);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted");
            GetCusList();

        }
        void GetCusList()
        {

            SqlCommand c = new SqlCommand("exec Listcus_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void customer_Load(object sender, EventArgs e)
        {
            GetCusList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            int cusid = int.Parse(textBox1.Text);
            string cusname = textBox2.Text, city = comboBox1.Text, gender = comboBox2.Text, contact = textBox4.Text;
            double age = double.Parse(textBox3.Text);
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateCus_SP '" + cusid + "','" + cusname + "','" + city + "','" + age + "','" + gender + "','" + contact + "'", con);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated...");
            GetCusList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete
            if (MessageBox.Show("Are you sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int cusid = int.Parse(textBox1.Text);
                con.Open();
                SqlCommand c = new SqlCommand("exec DeleteCus_SP '" + cusid + "'", con);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted...");
                GetCusList();
            }
        }
    }
}
