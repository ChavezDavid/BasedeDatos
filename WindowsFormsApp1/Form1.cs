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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();

            sql.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\SQLServer.mdf;Integrated Security=True;Connect Timeout=30";

            sql.Open();

            var cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Jugador";
            cmd.Connection = sql;

            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            da.Fill(dt);

            sql.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\SQLServer.mdf;Integrated Security=True;Connect Timeout=30";
            sql.Open();

            var cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Jugador (IdJugador, nombre, genero)" + "VALUES('" + txtId.Text + "','" + txtNombre.Text + "','" + txtGenero.Text + "')";
            cmd.Connection = sql;
            cmd.ExecuteNonQuery();

            sql.Close();
        }
    }
}
