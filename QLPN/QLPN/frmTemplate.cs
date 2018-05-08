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
using System.Configuration;

namespace QLPN
{
    public partial class frmTemplate : Form
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QLPN"].ConnectionString;
        int trangThaiDangNhap = 0;
        string tenTaiKhoan;

        SqlConnection conn = null;

        public frmTemplate()
        {
            InitializeComponent();
        }



        private void frmTemplate_Load(object sender, EventArgs e)
        {
            LayTongThanhVien(); //TD
            LayTongSoMayTram(); //TD
            LayMTDangSuDung(); //TD
            LayMTSanSang(); //TD

            this.Text = "IRMS - Server 1.7.38 [" + tenTaiKhoan + " Staff]"; //TD
            frmLogin formLogin = new frmLogin(); //TD
            formLogin.ShowDialog();  //TD
            tenTaiKhoan = formLogin.getTenTaiKhoan; //TD
            
            trangThaiDangNhap = TrangThaiDangNhap(tenTaiKhoan); //TD
            this.Text = "IRMS - Server 1.7.38 [" + tenTaiKhoan + " Staff]"; //TD


            LayDSMayTram_DanhHy();
        }

        //========================================[BEGIN] Văn Danh, Hy [BEGIN]====================================
        private void LayDSMayTram_DanhHy()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string query ="SELECT * FROM MAYTRAM";
                SqlCommand command = new SqlCommand(query,conn);
                SqlDataReader reader = command.ExecuteReader();
                int dem = 0;
                while (reader.Read())
                {

                    //đọc từng trường trong csdl rồi gán vô biến kiểu string tương ứng
                    string maMayTram = reader[0].ToString();
                    string tenMayTram = "  " + reader[1].ToString();
                    string tinhTrang = reader[2].ToString();
                    string tenTaiKhoan =  reader[3].ToString();
                    string thoiGianBatDau = string.Format("{0:HH':'mm':'ss}",reader[4]);
                    string daSuDung = reader[5].ToString();
                    string conLai = reader[6].ToString();
                    string tien = reader[7].ToString();
                    string ngayHienTai = string.Format("{00:dd/MM/yyyy}", reader[8]);
                    string phienBan = reader[9].ToString();
                    string loaiTK = reader[10].ToString();
                    string ghiChu = reader[11].ToString();

                    // thêm từng biến vô listviewitem
                    ListViewItem lvi = new ListViewItem(tenMayTram);

                    // kiểm tra tình trạng 0 thì gán thành offline, 1 là online, 2 là ready. Đồng thời gán icon màu tương ứng
                    if (string.Compare(tinhTrang, "0", true) == 0)
                    {
                        lvi.ImageIndex = 10;
                        tinhTrang = "Offline";
                    }
                    else if (string.Compare(tinhTrang, "1", true) == 0) { 
                        lvi.ImageIndex = 9;
                        tinhTrang = "Online";
                    }
                    else{
                       lvi.ImageIndex = 11;
                        tinhTrang = "Ready";
                    }

                    //thêm đồng vào sau tien
                    if (string.Compare(tien, "",true) != 0)
                    {
                        tien = tien + " đồng";
                    }

                    //thêm phút vào sau daSuDung và conLai
                    if (string.Compare(daSuDung, "", true) != 0)
                        daSuDung = daSuDung + " phút";
                    if (string.Compare(conLai, "", true) != 0)
                        conLai = conLai + " phút";

                    // thêm các biến còn lại vào listviewitem
                    lvi.SubItems.Add(tinhTrang);
                    lvi.SubItems.Add(tenTaiKhoan);
                    lvi.SubItems.Add(thoiGianBatDau);
                    lvi.SubItems.Add(daSuDung);
                    lvi.SubItems.Add(conLai);
                    lvi.SubItems.Add(tien);
                    lvi.SubItems.Add(ngayHienTai);
                    lvi.SubItems.Add(phienBan);
                    lvi.SubItems.Add(loaiTK);
                    lvi.SubItems.Add(ghiChu);

                    //Add listviewitem vô listview
                    listView_DanhHy.Items.Add(lvi);

                    //Kiểm tra đổi màu
                    listView_DanhHy.Items[dem].UseItemStyleForSubItems = false;
                    if (string.Compare(tinhTrang, "Online", true) == 0)
                    {
                        listView_DanhHy.Items[dem].SubItems[1].BackColor = Color.Blue;
                    }
                    else if (string.Compare(tinhTrang, "Offline", true) == 0)
                    {
                        listView_DanhHy.Items[dem].SubItems[1].BackColor = Color.Red;
                    }
                    else
                    {
                        listView_DanhHy.Items[dem].SubItems[1].BackColor = Color.Green;
                    }

                    dem++;
                }
                reader.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void listView_DanhHy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_DanhHy.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip_DanhHy.Show(Cursor.Position);
                }
            }
        }

        //========================================[END] Văn Danh, Hy [END]====================================



        //======================================== Thành Danh ========================================
        private int TrangThaiDangNhap(string tenTaiKhoan)
        {
            if(tenTaiKhoan != null)
            {
                try
                {
                    string sqlSelect = string.Format("SELECT TrangThaiTaiKhoan FROM TAIKHOANQUANTRI WHERE TenTaiKhoan = '{0}'", tenTaiKhoan);
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.Rows[0];
                    return Convert.ToInt16(dr["TrangThaiTaiKhoan"].ToString());
                }
                catch
                {
                    //none
                }

            }
            return 0;


        }
            //===================Load Thông tin===================
        private void LayTongThanhVien()
        {
            string sqlCountMember = "SELECT COUNT(*) AS CountMember  FROM TAIKHOAN";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sqlCountMember, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CountMember");
            DataTable dt = ds.Tables["CountMember"];
            DataRow dr = dt.Rows[0];
            string tongThanhVien = dr["CountMember"].ToString();
            tsslTongThanhVien.Text = "Tổng thành viên: " + tongThanhVien;
        }
        private void LayTongSoMayTram()
        {
            string sqlCountClient = "SELECT COUNT(*) AS CountClient  FROM MAYTRAM";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sqlCountClient, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CountClient");
            DataTable dt = ds.Tables["CountClient"];
            DataRow dr = dt.Rows[0];
            string tongSoMayTram = dr["CountClient"].ToString();
            tsslTongSoMayTram.Text = "Tổng số máy trạm: " + tongSoMayTram;
        }
        private void LayMTDangSuDung()
        {
            string sqlCountActiveClient = "SELECT COUNT(*) AS CountActiveClient  FROM MAYTRAM WHERE TinhTrangMayTram = '1'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sqlCountActiveClient, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CountActiveClient");
            DataTable dt = ds.Tables["CountActiveClient"];
            DataRow dr = dt.Rows[0];
            string tongMTDangSuDung = dr["CountActiveClient"].ToString();
            tsslDangSuDung.Text = "Đang sử dụng: " + tongMTDangSuDung;
        }
        private void LayMTSanSang()
        {
            string sqlCountReadyClient = "SELECT COUNT(*) AS CountReadyClient  FROM MAYTRAM WHERE TinhTrangMayTram = '2'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(sqlCountReadyClient, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CountReadyClient");
            DataTable dt = ds.Tables["CountReadyClient"];
            DataRow dr = dt.Rows[0];
            string tongMTSanSang = dr["CountReadyClient"].ToString();
            tsslSanSang.Text = "Sẵn sàng: " + tongMTSanSang;
        }
            //===================End block load===================
        private void Protect_Click(object sender, EventArgs e)
        {
            if (trangThaiDangNhap == 0)
            {
                
                tabControlChucNang.SelectedTab = tabMayTram;
                frmLogin formLogin1 = new frmLogin();
                formLogin1.ShowDialog();
                tenTaiKhoan = formLogin1.getTenTaiKhoan;
                trangThaiDangNhap = TrangThaiDangNhap(tenTaiKhoan);
                this.Text = "IRMS - Server 1.7.38 [" + tenTaiKhoan + " Staff]";

                tabControlChucNang.SelectedTab = tabMayTram;

            }

        }
        private void btnThayDoiNhanVien_Click(object sender, EventArgs e)
        {
            tabControlChucNang.SelectedTab = tabMayTram;
            if (tenTaiKhoan != null)
            {
                string sqlUpdate = string.Format("UPDATE TAIKHOANQUANTRI SET TrangThaiTaiKhoan = '0' WHERE TenTaiKhoan = '{0}'", tenTaiKhoan);
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
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

            tenTaiKhoan = null;
            trangThaiDangNhap = 0;
            frmLogin formLogin1 = new frmLogin();
            formLogin1.ShowDialog();
            tenTaiKhoan = formLogin1.getTenTaiKhoan;
            trangThaiDangNhap = TrangThaiDangNhap(tenTaiKhoan);
            this.Text = "IRMS - Server 1.7.38 [" + tenTaiKhoan + " Staff]";

            tabControlChucNang.SelectedTab = tabMayTram;

        }

        private void frmTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tenTaiKhoan != null)
            {
                string sqlUpdate = string.Format("UPDATE TAIKHOANQUANTRI SET TrangThaiTaiKhoan = '0' WHERE TenTaiKhoan = '{0}'", tenTaiKhoan);
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
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

        

        //============================== End Block of Thành Danh ==============================
    }
}
