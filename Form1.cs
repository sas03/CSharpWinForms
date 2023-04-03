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

namespace WinFormsCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connect to the database from the connectionstring
            SqlConnection con = new SqlConnection("Data Source=NSI-PC020\\SQLEXPRESS;Initial Catalog=Debutant;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO users values(@id, @name, @firstname)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox3.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NSI-PC020\\SQLEXPRESS;Initial Catalog=Debutant;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE users SET name=@name, firstname=@firstname where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox3.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NSI-PC020\\SQLEXPRESS;Initial Catalog=Debutant;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE users where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NSI-PC020\\SQLEXPRESS;Initial Catalog=Debutant;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM users where id=@id", con);
            cmd.Parameters.AddWithValue("id", int.Parse(textBox1.Text));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //grabbed from the datagrid(in Design)
            dataGridView1.DataSource = dt;
        }
    }
}
