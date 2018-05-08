using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLPN
{
    public partial class MenuMayTram : Form
    {
        //Thành viên đăng nhập đã có User Name và Password, Form này làm việc với db User 
        //tiền net mặc định là 3000đồng/giờ chơi, có thể define trong file config
        const int TIEN_GIO = 3000; 
        string Username = "lehuuhien";
        string pass = "123";
        string connString = ConfigurationManager.ConnectionStrings["QLPN"].ConnectionString;
        public MenuMayTram()
        {
            InitializeComponent();
            prepairUI(getUserData());
        }

        private void MenuMayTram_Load(object sender, EventArgs e)
        {
            ControlBox = false; 

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            Point p = new Point(screenWidth - 298, 0);
            this.Location = p;

            MessageBox.Show("* Thành viên phải đăng nhập vào hệ thống để có thông tin làm việc\n" +
                           "* Mặc định username khi test là lehuuhien, password= 123\n"+
                           "* đổi mật khẩu phải vào SQLServer chạy lệnh\n"+ 
                           "***Update TAIKHOAN set MatKhau = '123' where MaTaiKhoan = '03'\n"+
                           "* đăng nhập lấy username và pass!");       
            DataTable dt = getUserData();

            if (dt != null)
            {
                DataRow row = dt.Rows[0];
                this.Text = row["TenTaiKhoan"].ToString();
            }
            else this.Text = "Unknnown Member!";           
        }

        /* UserData maTaiKhoan, TenTaiKhoan, MatKhau, LoaiTaiKhoan, SoTien, TinhTrangTaiKhoan */
        private void prepairUI(DataTable userData)
        {
            //DataRow test = userData.Rows[0];
            //MessageBox.Show(test[0] + " " + test[1] + " " + test[2] + " " + test[3] + " " + test[4]);
            int gio= 0, phut= 0;
            DataRow row = userData.Rows[0];
            int soTien = 0;
            try
            {
               soTien = int.Parse(row[4].ToString());
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi lấy dữ liệu:\n" + e.ToString());
            }
            
            //tinh so gio dua tren so tien trong tai khoan
            gio = soTien / TIEN_GIO;
            if (soTien % TIEN_GIO < 1000)
                phut = 15;
            else if (soTien % TIEN_GIO < 2000)
                phut = 30;
            else
                phut = 45;
            string gioConLai = gio + ":" + phut;
            txtTgConLai.Text = gioConLai;
            usingTime.Enabled = true;
            usingTime.Start();
            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DataTable getUserData()
        {
            DataTable dt = new DataTable();
            string query = String.Format("Select * from TAIKHOAN where tentaikhoan= '{0}' and matkhau = '{1}'", Username, pass);
            using(SqlConnection connection = new SqlConnection(connString))
            {
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader dr = command.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Lỗi kết nối:\n" + e.ToString());
                    }
                }
            }
            return dt;
        }

        private void btnTinNhan_Click(object sender, EventArgs e)
        {
            MenuMayTram_TinNhan frmTinNhan = new MenuMayTram_TinNhan();
            frmTinNhan.Show();
        }

        private void btnKhoaMay_Click(object sender, EventArgs e)
        {
            MenuMayTram_khoaMay frmMk = new MenuMayTram_khoaMay();
            frmMk.Show();
        }

        private void btnMatKhau_Click(object sender, EventArgs e)
        {
            MenuMayTram_doiMK frmDoiMK = new MenuMayTram_doiMK(Username, pass);
            frmDoiMK.ShowDialog();
        }

        private void btnMess_Click(object sender, EventArgs e)
        {
            MenuMayTram_TinNhan frmTN = new MenuMayTram_TinNhan();
            frmTN.Show();
        }

        private void btnTienIch_Click(object sender, EventArgs e)
        {
            MenuMayTram_TienIch frmTienIch = new MenuMayTram_TienIch();
            frmTienIch.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            MenuMayTram_DichVu frmDV = new MenuMayTram_DichVu();
            frmDV.Show();
        }

        //Interval is 60 sec (same 1 min)
        int gioChoi= 0, phutChoi = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("bắt đầu đếm!");
            phutChoi++;
            if(phutChoi == 60)
            {
                gioChoi++;
                phutChoi = 0;
            }
            txtTgSuDung.Text = gioChoi.ToString() + ":" + phutChoi.ToString();
        }
    }

}
