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
    public partial class frmTemplate : Form
    {
        public frmTemplate()
        {
            InitializeComponent();
        }

        private void DTPBatDau_ValueChanged(object sender, EventArgs e)
        {
            string time = DTPBatDau.Value.ToString("MM/dd/yyyy");
            MessageBox.Show(time);
        }
    }
}
