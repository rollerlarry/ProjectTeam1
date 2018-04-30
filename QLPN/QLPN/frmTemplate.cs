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
    public partial class frmTemplate : Form
    {
        string connectionString = @"Server=DESKTOP-7A3KM08\SQLEXPRESS; Database=QLPN; Integrated Security=True";
        SqlConnection conn = null;

        public frmTemplate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmTemplate_Load(object sender, EventArgs e)
        {
            LayDSMayTram_DanhHy();
        }

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
    }
}
