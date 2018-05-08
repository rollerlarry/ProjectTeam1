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
    public partial class MenuMayTram_TienIch : Form
    {
        public MenuMayTram_TienIch()
        {
            InitializeComponent();
        }

        private void trkbAmThanh_Scroll(object sender, EventArgs e)
        {
            int scroll = trkbAmLuong.Value;
            lbAmLuong.Text = scroll*10 + "%";
        }

        private void trkbarChuot_Scroll(object sender, EventArgs e)
        {
            int scroll = trkbarChuot.Value;
            lbTocDoChuot.Text = scroll * 10 + "%";
        }

        private void trkbarDoSang_Scroll(object sender, EventArgs e)
        {
            int scroll = trkbarDoSang.Value;
            lbDoSang.Text = scroll * 10 + "%";
        }
    }
}
