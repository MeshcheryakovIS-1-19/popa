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

namespace WindowsFormsApp23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=TestWork;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = $"SELECT COUNT(*)  FROM Users WHERE Username = '{textBox1.Text}' and  Password = '{sha256(textBox2.Text)}'";
            conn.Open();
            SqlCommand command= new SqlCommand (sql, conn);
            int count = (int)command.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                MessageBox.Show("Вы вошли в программу");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверные данные авторизации!");
            }
        }

        static string sha256(string randomString)
        {
            var crypt = System.Security.Cryptography.SHA256.Create();
            return string.Concat(crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString)).Select(x => $"{x:x2}"));
        }
    }
}