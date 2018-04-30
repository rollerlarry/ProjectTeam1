namespace QLPN
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblDangNhapTaiKhoan = new System.Windows.Forms.Label();
            this.lblTenTaiKhoan = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDangNhapTaiKhoan
            // 
            this.lblDangNhapTaiKhoan.AutoSize = true;
            this.lblDangNhapTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("lblDangNhapTaiKhoan.Image")));
            this.lblDangNhapTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDangNhapTaiKhoan.Location = new System.Drawing.Point(13, 13);
            this.lblDangNhapTaiKhoan.Name = "lblDangNhapTaiKhoan";
            this.lblDangNhapTaiKhoan.Size = new System.Drawing.Size(125, 13);
            this.lblDangNhapTaiKhoan.TabIndex = 0;
            this.lblDangNhapTaiKhoan.Text = "      Đăng nhập tài khoản";
            // 
            // lblTenTaiKhoan
            // 
            this.lblTenTaiKhoan.AutoSize = true;
            this.lblTenTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("lblTenTaiKhoan.Image")));
            this.lblTenTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTenTaiKhoan.Location = new System.Drawing.Point(37, 47);
            this.lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            this.lblTenTaiKhoan.Size = new System.Drawing.Size(91, 13);
            this.lblTenTaiKhoan.TabIndex = 1;
            this.lblTenTaiKhoan.Text = "      Tên tài khoản";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Image = ((System.Drawing.Image)(resources.GetObject("lblMatKhau.Image")));
            this.lblMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMatKhau.Location = new System.Drawing.Point(37, 89);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(70, 13);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "      Mật khẩu";
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(134, 44);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(170, 20);
            this.txtTenTaiKhoan.TabIndex = 3;
            this.txtTenTaiKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenTaiKhoan_KeyPress);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(134, 86);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(170, 20);
            this.txtMatKhau.TabIndex = 4;
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Location = new System.Drawing.Point(134, 125);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            this.btnDangNhap.Enter += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(229, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(65, 160);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(10, 13);
            this.lblThongBao.TabIndex = 7;
            this.lblThongBao.Text = " ";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 192);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenTaiKhoan);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenTaiKhoan);
            this.Controls.Add(this.lblDangNhapTaiKhoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDangNhapTaiKhoan;
        private System.Windows.Forms.Label lblTenTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblThongBao;
    }
}