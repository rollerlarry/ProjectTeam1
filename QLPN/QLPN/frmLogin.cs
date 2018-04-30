using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QLPN
{
    public partial class frmLogin : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QLPN"].ConnectionString;

        bool isMouseDown;
        int xLast;
        int yLast;

        //Property
        public string getTenTaiKhoan
        {
            get
            {
                return txtTenTaiKhoan.Text;
            }
        }
        //====End Prop====

        public frmLogin()
        {
            InitializeComponent();

        }
        //====================Di chuyển form====================
        protected override void OnMouseDown(MouseEventArgs e)
        {
            isMouseDown = true;
            xLast = e.X;
            yLast = e.Y;

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int newY = this.Top + (e.Y - yLast);
                int newX = this.Left + (e.X - xLast);

                this.Location = new Point(newX, newY);
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isMouseDown = false;

            base.OnMouseUp(e);
        }
        //====================end block di chuyển form====================

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
            if (e.KeyChar.ToString() == " " || txtTenTaiKhoan.Text.Length > 15)
            {
                e.Handled = true;
            }

            if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
            if (e.KeyChar.ToString() == " " || txtMatKhau.Text.Length > 15)
            {
                e.Handled = true;
            }

            if ((e.KeyChar < 65 || e.KeyChar > 90) && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = " ";
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string sqlSelect = string.Format("SELECT COUNT(*) FROM TAIKHOANQUANTRI WHERE TenTaiKhoan = '{0}' AND MatKhau = '{1}'", tenTaiKhoan, matKhau);
            string sqlUpdate = string.Format("UPDATE TAIKHOANQUANTRI SET TrangThaiTaiKhoan = '1' WHERE TenTaiKhoan = '{0}'", tenTaiKhoan);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlCommand cmd2 = new SqlCommand(sqlUpdate, con);

            try
            {
                con.Open();
                string output = cmd.ExecuteScalar().ToString();
                if (output == "1")
                {
                    cmd2.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    lblThongBao.Text = "Tài khoản hoặc mật khẩu không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kết nối: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }


        }

    }
}
