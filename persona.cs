using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab03
{
    public partial class persona : Form
    {
        SqlConnection conn;
        public persona(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void persona_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                String sql = "SELECT * FROM tbl_usuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvListado.DataSource = dt;
                dgvListado.Refresh();
            }else
            {
                MessageBox.Show("La conexión esta cerrada");
            }
        }
    }
}
