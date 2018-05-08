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
            layTTDichVu(); //HuuHien

            this.Text = "IRMS - Server 1.7.38 [" + tenTaiKhoan + " Staff]"; //TD
            frmLogin formLogin = new frmLogin(); //TD
            formLogin.ShowDialog();  //TD
            tenTaiKhoan = formLogin.getTenTaiKhoan; //TD
            
            trangThaiDangNhap = TrangThaiDangNhap(tenTaiKhoan); //TD
            this.Text = "IRMS - Server 1.7.38 [" + tenTaiKhoan + " Staff]"; //TD


            LayDSMayTram_DanhHy();

            tabNKGG_LoadData(); //Duy
            tabNKGG_layTenNguoiDung();//Duy

            LayDSNhomNguoiSuDung();
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
            string tongThanhVien = dr["countMember"].ToString();
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
            checkTabNgocCan();

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

        //============= DUC DUY vs MINH VIET ==================//
       private void tabNKGG_LoadData()
        {
            try
            {
                string query = "select * from GIAODICH";
                if (conn == null)
                    conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem lvi = new ListViewItem(rd.GetString(1));
                    lvi.SubItems.Add(rd.GetDateTime(2).ToString("dd-MM-yyyy")); //dt
                    lvi.SubItems.Add(rd.GetDateTime(3).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(4).ToString("dd-MM-yyyy"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(5).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDouble(6).ToString());
                    TimeSpan diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(rd.GetDateTime(3).ToString());
                    long i = Math.Abs(diff.Ticks);
                    DateTime dt = new DateTime(i);
                    lvi.SubItems.Add(dt.ToString("HH:mm"));
                    lvi.SubItems.Add(rd.GetString(7));
                    lvi.SubItems.Add(rd.GetString(8));

                    lvDuyNhatKyGiaoDich.Items.Add(lvi);
                }
                rd.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void dtpDuyNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lvDuyNhatKyGiaoDich.Items.Clear();
                string time = dtpDuyNgayBatDau.Value.ToString("yyyy-MM-dd");

                string query = string.Format("select * from GIAODICH where NgayBatDau = '{0}'", time);
                if (conn == null)
                    conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem lvi = new ListViewItem(rd.GetString(1));
                    lvi.SubItems.Add(rd.GetDateTime(2).ToString("dd-MM-yyyy")); //dt
                    lvi.SubItems.Add(rd.GetDateTime(3).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(4).ToString("dd-MM-yyyy"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(5).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDouble(6).ToString());
                    TimeSpan diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(rd.GetDateTime(3).ToString());
                    long i = Math.Abs(diff.Ticks);
                    DateTime dt = new DateTime(i);
                    lvi.SubItems.Add(dt.ToString("HH:mm"));
                    lvi.SubItems.Add(rd.GetString(7));
                    lvi.SubItems.Add(rd.GetString(8));

                    lvDuyNhatKyGiaoDich.Items.Add(lvi);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }


        }

        private void btnDuyRefresh_Click(object sender, EventArgs e)
        {
            lvDuyNhatKyGiaoDich.Items.Clear();
            tabNKGG_LoadData();
        }

        private void btnDuyTime_Click(object sender, EventArgs e)
        {
            string name = cboDuyTenNguoiDung.SelectedValue.ToString();
            tabNKGG_xemTheoTen(name);
        }
        private void tabNKGG_xemTheoTen(string name)
        {
            try
            {
                lvDuyNhatKyGiaoDich.Items.Clear();
                string query = string.Format("select * from GIAODICH where TenTaiKhoan = '{0}'", name);


                if (conn == null)
                    conn = new SqlConnection(connectionString);


                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem lvi = new ListViewItem(rd.GetString(1));
                    lvi.SubItems.Add(rd.GetDateTime(2).ToString("dd-MM-yyyy")); //dt
                    lvi.SubItems.Add(rd.GetDateTime(3).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(4).ToString("dd-MM-yyyy"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(5).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDouble(6).ToString());
                    TimeSpan diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(rd.GetDateTime(3).ToString());
                    long i = Math.Abs(diff.Ticks);
                    DateTime dt = new DateTime(i);
                    lvi.SubItems.Add(dt.ToString("HH:mm"));
                    lvi.SubItems.Add(rd.GetString(7));
                    lvi.SubItems.Add(rd.GetString(8));

                    lvDuyNhatKyGiaoDich.Items.Add(lvi);
                }
                rd.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        //Lấy tên người dùng cho vào combobox
        private void tabNKGG_layTenNguoiDung()
        {
            string query = "select * from GIAODICH";
            SqlDataAdapter adt = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adt.Fill(ds, "GiaoDich");
            cboDuyTenNguoiDung.DisplayMember = "TenTaiKhoan";
            cboDuyTenNguoiDung.ValueMember = "TenTaiKhoan";
            cboDuyTenNguoiDung.DataSource = ds.Tables["GiaoDich"];

        }

        private void cboDuyHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hinhThuc = cboDuyHinhThuc.SelectedItem.ToString();

            if (hinhThuc == "Chưa thanh toán")
            {
                tabNKGG_HinhThuc_ChuaThanhToan();
            }

            else if (hinhThuc == "Đã thanh toán")
            {
                tabNKGG_HinhThuc_DaThanhToan();
            }
        }

        //Lay du lieu la khi chon hinh thuc da thanh thoan
        private void tabNKGG_HinhThuc_DaThanhToan()
        {
            try
            {
                lvDuyNhatKyGiaoDich.Items.Clear();
                string query = "select * from GIAODICH where SoTienGiaoDich > 0";


                if (conn == null)
                    conn = new SqlConnection(connectionString);


                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem lvi = new ListViewItem(rd.GetString(1));
                    lvi.SubItems.Add(rd.GetDateTime(2).ToString("dd-MM-yyyy")); //dt
                    lvi.SubItems.Add(rd.GetDateTime(3).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(4).ToString("dd-MM-yyyy"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(5).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDouble(6).ToString());
                    TimeSpan diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(rd.GetDateTime(3).ToString());
                    long i = Math.Abs(diff.Ticks);
                    DateTime dt = new DateTime(i);
                    lvi.SubItems.Add(dt.ToString("HH:mm"));
                    lvi.SubItems.Add(rd.GetString(7));
                    lvi.SubItems.Add(rd.GetString(8));

                    lvDuyNhatKyGiaoDich.Items.Add(lvi);


                }
                rd.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        //Lay du lieu khi chon hinh thuc chua thanh toan
        private void tabNKGG_HinhThuc_ChuaThanhToan()
        {
            try
            {
                lvDuyNhatKyGiaoDich.Items.Clear();
                string query = "select * from GIAODICH where SoTienGiaoDich < 0";


                if (conn == null)
                    conn = new SqlConnection(connectionString);


                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem lvi = new ListViewItem(rd.GetString(1));
                    lvi.SubItems.Add(rd.GetDateTime(2).ToString("dd-MM-yyyy")); //dt
                    lvi.SubItems.Add(rd.GetDateTime(3).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(4).ToString("dd-MM-yyyy"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(5).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDouble(6).ToString());
                    TimeSpan diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(rd.GetDateTime(3).ToString());
                    long i = Math.Abs(diff.Ticks);
                    DateTime dt = new DateTime(i);
                    lvi.SubItems.Add(dt.ToString("HH:mm"));
                    lvi.SubItems.Add(rd.GetString(7));
                    lvi.SubItems.Add(rd.GetString(8));

                    lvDuyNhatKyGiaoDich.Items.Add(lvi);
                }
                rd.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDuySearch_Click(object sender, EventArgs e)
        {
            string tenVuaSearch = txtDuySearch.Text;
            tabNKGG_xemTheoTen(tenVuaSearch);
        }

        private void dtpDuyKT_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                lvDuyNhatKyGiaoDich.Items.Clear();
                string time = dtpDuyKT.Value.ToString("yyyy-MM-dd");

                string query = string.Format("select * from GIAODICH where NgayBatDau = '{0}'", time);
                if (conn == null)
                    conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListViewItem lvi = new ListViewItem(rd.GetString(1));
                    lvi.SubItems.Add(rd.GetDateTime(2).ToString("dd-MM-yyyy")); //dt
                    lvi.SubItems.Add(rd.GetDateTime(3).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(4).ToString("dd-MM-yyyy"));//dt
                    lvi.SubItems.Add(rd.GetDateTime(5).ToString("HH:mm"));//dt
                    lvi.SubItems.Add(rd.GetDouble(6).ToString());
                    TimeSpan diff = DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(rd.GetDateTime(3).ToString());
                    long i = Math.Abs(diff.Ticks);
                    DateTime dt = new DateTime(i);
                    lvi.SubItems.Add(dt.ToString("HH:mm"));
                    lvi.SubItems.Add(rd.GetString(7));
                    lvi.SubItems.Add(rd.GetString(8));

                    lvDuyNhatKyGiaoDich.Items.Add(lvi);
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        private void menuNhatKyGiaoDich_Click(object sender, EventArgs e)
        {
            tabControlChucNang.SelectedIndex = 3;
        }
        //================END DUY va VIET===============
        //================CODE BY CAN===================
        private void LayDSTaiKhoanNgocCan()
        {
            dgvCanAcc.Rows.Clear();
            string SqlSelect = "Select *from TAIKHOAN order by TenTaiKhoan ASC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlSelect, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string tenNSD = (string)dr["TenTaiKhoan"];
                            double soTien = (double)dr["SoTien"];
                            string nhomNSD = (string)dr["LoaiTaiKhoan"];
                            string tinhTrang;
                            if ((int)dr["TinhTrangTaiKhoan"] == 0)
                            {
                                tinhTrang = "Banned";
                            }
                            else
                            {
                                tinhTrang = null;
                            }
                            dgvCanAcc.Rows.Add(tenNSD.ToUpper(), String.Format("{0:0,0}", soTien), nhomNSD, tinhTrang);
                        }
                    }
                }
            }
        }

        private void btnCanRefresh_Click(object sender, EventArgs e)
        {
            LayDSTaiKhoanNgocCan();
        }
        private void checkTabNgocCan()
        {
            if (tabControlChucNang.SelectedIndex == 1)
            {
                LayDSTaiKhoanNgocCan();
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlChucNang.SelectedIndex = 1;
            checkTabNgocCan();
        }

        private void btnCanRefresh_Click_1(object sender, EventArgs e)
        {
            LayDSTaiKhoanNgocCan();
        }

        private void btnCanTV_Click(object sender, EventArgs e)
        {
            string btnThanhVien = "Thành viên";
            dgvCanAcc.Rows.Clear();
            string SqlSelect = "Select *from TAIKHOAN where LoaiTaiKhoan like '" + btnThanhVien + "'  order by TenTaiKhoan ASC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlSelect, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string tenNSD = (string)dr["TenTaiKhoan"];
                            double soTien = (double)dr["SoTien"];
                            string nhomNSD = (string)dr["LoaiTaiKhoan"];
                            string tinhTrang;
                            if ((int)dr["TinhTrangTaiKhoan"] == 0)
                            {
                                tinhTrang = "Banned";
                            }
                            else
                            {
                                tinhTrang = null;
                            }
                            dgvCanAcc.Rows.Add(tenNSD.ToUpper(), String.Format("{0:0,0}", soTien), nhomNSD, tinhTrang);
                        }
                    }
                }
            }
        }

        private void btnCanNV_Click(object sender, EventArgs e)
        {
            string btnNhanVien = "Nhân viên";
            dgvCanAcc.Rows.Clear();
            string SqlSelect = "Select *from TAIKHOAN where LoaiTaiKhoan like '" + btnNhanVien + "'  order by TenTaiKhoan ASC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlSelect, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string tenNSD = (string)dr["TenTaiKhoan"];
                            double soTien = (double)dr["SoTien"];
                            string nhomNSD = (string)dr["LoaiTaiKhoan"];
                            string tinhTrang;
                            if ((int)dr["TinhTrangTaiKhoan"] == 0)
                            {
                                tinhTrang = "Banned";
                            }
                            else
                            {
                                tinhTrang = null;
                            }
                            dgvCanAcc.Rows.Add(tenNSD.ToUpper(), String.Format("{0:0,0}", soTien), nhomNSD, tinhTrang);
                        }
                    }
                }
            }
        }

        private void btnCanSearch_Click(object sender, EventArgs e)
        {
            if (cbxCanSearch.Text != null && txtCanSearch.Text != null)
            {
                string SqlSelect;
                string txtCanValueSearch = txtCanSearch.Text;
                if (cbxCanSearch.Text == "Tên người sử dụng")
                {
                    SqlSelect = "Select *from TAIKHOAN where TenTaiKhoan like '%" + txtCanValueSearch + "%'  order by TenTaiKhoan ASC";
                }
                else if (cbxCanSearch.Text == "Tình trạng tài khoản")
                {
                    SqlSelect = "Select *from TAIKHOAN where TinhTrangTaiKhoan = 0  order by TenTaiKhoan ASC";
                }
                else
                {
                    SqlSelect = "Select *from TAIKHOAN where LoaiTaiKhoan like '%" + txtCanValueSearch + "%'  order by TenTaiKhoan ASC";
                }
                
                dgvCanAcc.Rows.Clear();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlSelect, conn))
                    {
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string tenNSD = (string)dr["TenTaiKhoan"];
                                double soTien = (double)dr["SoTien"];
                                string nhomNSD = (string)dr["LoaiTaiKhoan"];
                                string tinhTrang;
                                if ((int)dr["TinhTrangTaiKhoan"] == 0)
                                {
                                    tinhTrang = "Banned";
                                }
                                else
                                {
                                    tinhTrang = null;
                                }
                                dgvCanAcc.Rows.Add(tenNSD.ToUpper(), String.Format("{0:0,0}", soTien), nhomNSD, tinhTrang);
                            }
                        }
                    }
                }
            }
        }
        //================END CODE BY CAN================== 
        //================CODE BY HAO======================

        private void LayDSNhomNguoiSuDung()
        {

            dgvNhomNguoiSuDung.Rows.Clear(); 
            string query = "SELECT *FROM NHOMNGUOISUDUNG";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tenNhom = (string)reader["TenNhom"];
                            string loaiTK = (string)reader["LoaiTaiKhoan"];
                            double giaTien = (double)reader["GiaTien"];

                            dgvNhomNguoiSuDung.Rows.Add(tenNhom,loaiTK, String.Format("{0:0,0}",giaTien));
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //================END CODE HAO=====================

        //================ CODE BY HIEN ===================
        //Huuhien edited
        private void layTTDichVu()
        {
            MessageBox.Show("Đang lấy dịch vụ.....");
            DataTable dmDV = layDMDichVu();
            for (int i = 0; i < dmDV.Rows.Count; i++)
            {
                dgvDichVu.Rows.Add(dmDV.Rows[i][1], "", "", "", "");
                layDichVuTheoDM((String)dmDV.Rows[i][0]);
            }
        }

        private void layDichVuTheoDM(string maDM)
        {
            string query = String.Format("Select ten,donvi,gia,tonkho from DICHVU where maDM = '{0}'", maDM);
            SqlDataReader reader = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            dgvDichVu.Rows.Add("", reader[0].ToString(), reader[2].ToString() + ".000đ", reader[1].ToString(), reader[3].ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Lỗi lấy chi tiết dịch vụ:\n" + e.ToString());
                    }

                }
            }
        }

        private DataTable layDMDichVu()
        {
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            string queryDMPhong = "select * from DMDICHVU";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryDMPhong, connection))
                {
                    try
                    {
                        connection.Open();
                        reader = command.ExecuteReader();
                        /*đổ dữ liệu từ sqldatareader ra datatable*/
                        dt.Load(reader);
                    }
                    catch (Exception e) { MessageBox.Show("Lỗi kết nối lấy danh mục DV:\n" + e.ToString()); }
                }
            }

            return dt;
        }

        private void pnlMenuStrip_Paint(object sender, PaintEventArgs e)
        {

        }
        //================ END CODE HIEN ==================
    }
}

