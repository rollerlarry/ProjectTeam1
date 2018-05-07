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

namespace QLPN
{
    public partial class MenuMayTram_doiMK : Form
    {
        string username;
        string mk;
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["QLPN"].ConnectionString;
        public MenuMayTram_doiMK(string username, string mk)
        {
            this.username = username;
            this.mk = mk;
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string mkc = txtMK.Text.Trim();
            string mkm = txtMKnew.Text.Trim();
            string mkm2 = txtNhapLaiMK.Text.Trim();
            bool doimk = false;

            if (mkc == mk)
            {
                if(mkm == mkm2 && mkm != "")
                {
                    doimk = doiMK(mkm);
                }else MessageBox.Show("Mật khẩu không khớp!");
            }
            else MessageBox.Show("Mật khẩu không chính xác!");

            if (doimk == true)
                this.Close();
        }

        private bool doiMK(string mkm)
        {
            int tmp = 0;
            string query = String.Format("Update taikhoan set matkhau = '{0}' where tentaikhoan = '{1}' and matkhau= '{2}'", mkm, username, mk);

            using(SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        tmp= (int)command.ExecuteNonQuery();
                        
                    }catch(Exception e) { MessageBox.Show("Lỗi kết nối:\n" + e.ToString()); }
                }
            }
            if (tmp > 0)
                return true;
            else return false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
