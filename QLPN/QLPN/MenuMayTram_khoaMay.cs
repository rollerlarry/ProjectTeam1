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
    
    public partial class MenuMayTram_khoaMay : Form
    {
        String mk;
        public MenuMayTram_khoaMay()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoaMay_Click(object sender, EventArgs e)
        {
            if(btnKhoaMay.Text.Trim() == "Khóa máy")
                if(txtMk.Text.Trim() == txtNhapLai.Text.Trim())
                {
                    mk = txtMk.Text.Trim();
                    resetAllControll();
                }else
                {
                    MessageBox.Show("Nhập lại mật khẩu không khớp!");
                }
            else
                {
                    if(txtMk.Text.Trim() == mk)
                    {
                    this.Close();
                    }
                }
            // xu ly nhap mat khau mo may           
        }

        private void resetAllControll()
        {
            txtMk.Text = "";
            label2.Visible = false;
            txtNhapLai.Visible = false;
            btnKhoaMay.Text = "Mở máy";
        }

        private void MenuMayTram_MkTamThoi_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }
    }
}
