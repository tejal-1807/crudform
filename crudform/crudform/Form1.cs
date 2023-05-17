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

namespace crudform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-4FDHBTK\\SQLEXPRESS;Initial Catalog=crudform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ut values (@ID,@NAME,@AGE)",con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@AGE", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-4FDHBTK\\SQLEXPRESS;Initial Catalog=crudform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ut set name =@name, age =@age, id=@id", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
            cmd.Parameters.AddWithValue("@AGE", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully updated");

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-4FDHBTK\\SQLEXPRESS;Initial Catalog=crudform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE ut where id=@id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully deleted");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-4FDHBTK\\SQLEXPRESS;Initial Catalog=crudform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }
    }
}
