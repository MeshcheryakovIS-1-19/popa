using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlData
{
    public static class ControlData
    {
        static string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=TestWork;Trusted_Connection=True;";
        static SqlConnection conn = new SqlConnection(connectionString);
        public static BindingSource bSource = new BindingSource();
        private static readonly SqlDataAdapter MyDA = new SqlDataAdapter();
        private static DataTable table = new DataTable();

        public static BindingSource GetData()
        {
            conn.Open();
            string commandStr = "SELECT Id  AS 'Код', Title AS 'Название', Author AS 'Автор', Genre AS 'Жанр', Year AS 'Год' FROM Books";
            MyDA.SelectCommand = new SqlCommand(commandStr, conn);
            MyDA.Fill(table);
            bSource.DataSource = table;
            conn.Close();
            return bSource;
        }
     

    }
}
