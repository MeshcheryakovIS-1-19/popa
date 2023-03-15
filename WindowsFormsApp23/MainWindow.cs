using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ControlData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp23
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        
        private void Refresh()
        {
            dataGridView1.DataSource = ControlData.ControlData.GetData();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            ControlData.ControlData.bSource.Filter = "Жанр LIKE'" + comboBox1.Text + "%'";
            Refresh();
        }
    }
}
