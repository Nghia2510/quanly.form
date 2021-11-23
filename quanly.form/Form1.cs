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
namespace quanly.form
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-B68DCDH\SQLEXPRESS;Initial Catalog=SHOES10;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = " Select * from Mat_Hang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            tb_magiay.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            tb_tengiay.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            tb_size.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            tb_soluong.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            tb_mausac.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            tb_dongia.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command.Connection.CreateCommand();
            command.CommandText = "insert into Mat_Hang values ('" + tb_magiay.Text + "','" + tb_tengiay.Text + "','" + tb_soluong.Text + "','" + tb_mausac.Text + "','" + tb_size.Text + "','" + tb_dongia + "')";
            command.ExecuteNonQuery();
            loaddata();
        }
    }
}
