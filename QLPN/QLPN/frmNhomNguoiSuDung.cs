using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPN
{
    public partial class frmNhomNguoiSuDung : Form
    {
        public frmNhomNguoiSuDung()
        {
            InitializeComponent();
        }

        private void frmNhomNguoiSuDung_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[0].Cells[0].Value = "1";
            this.dataGridView1.Rows[0].Cells[1].Value = "Baqar";
            this.dataGridView1.Rows[0].Cells[2].Value = "Baqar";
            //button3.Visible = false;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
