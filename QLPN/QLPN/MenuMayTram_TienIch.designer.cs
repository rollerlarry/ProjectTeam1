namespace QLPN
{
    partial class MenuMayTram_TienIch
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
            this.trkbAmLuong = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trkbarChuot = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trkbarDoSang = new System.Windows.Forms.TrackBar();
            this.lbAmLuong = new System.Windows.Forms.Label();
            this.lbTocDoChuot = new System.Windows.Forms.Label();
            this.lbDoSang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trkbAmLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbarChuot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbarDoSang)).BeginInit();
            this.SuspendLayout();
            // 
            // trkbAmLuong
            // 
            this.trkbAmLuong.Location = new System.Drawing.Point(102, 35);
            this.trkbAmLuong.Name = "trkbAmLuong";
            this.trkbAmLuong.Size = new System.Drawing.Size(234, 45);
            this.trkbAmLuong.TabIndex = 0;
            this.trkbAmLuong.Scroll += new System.EventHandler(this.trkbAmThanh_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Âm lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tốc độ chuột";
            // 
            // trkbarChuot
            // 
            this.trkbarChuot.Location = new System.Drawing.Point(102, 86);
            this.trkbarChuot.Name = "trkbarChuot";
            this.trkbarChuot.Size = new System.Drawing.Size(234, 45);
            this.trkbarChuot.TabIndex = 2;
            this.trkbarChuot.Scroll += new System.EventHandler(this.trkbarChuot_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Độ sáng";
            // 
            // trkbarDoSang
            // 
            this.trkbarDoSang.Location = new System.Drawing.Point(102, 137);
            this.trkbarDoSang.Name = "trkbarDoSang";
            this.trkbarDoSang.Size = new System.Drawing.Size(234, 45);
            this.trkbarDoSang.TabIndex = 4;
            this.trkbarDoSang.Scroll += new System.EventHandler(this.trkbarDoSang_Scroll);
            // 
            // lbAmLuong
            // 
            this.lbAmLuong.AutoSize = true;
            this.lbAmLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmLuong.Location = new System.Drawing.Point(276, 19);
            this.lbAmLuong.Name = "lbAmLuong";
            this.lbAmLuong.Size = new System.Drawing.Size(27, 16);
            this.lbAmLuong.TabIndex = 6;
            this.lbAmLuong.Text = "0%";
            // 
            // lbTocDoChuot
            // 
            this.lbTocDoChuot.AutoSize = true;
            this.lbTocDoChuot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTocDoChuot.Location = new System.Drawing.Point(276, 64);
            this.lbTocDoChuot.Name = "lbTocDoChuot";
            this.lbTocDoChuot.Size = new System.Drawing.Size(27, 16);
            this.lbTocDoChuot.TabIndex = 7;
            this.lbTocDoChuot.Text = "0%";
            // 
            // lbDoSang
            // 
            this.lbDoSang.AutoSize = true;
            this.lbDoSang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoSang.Location = new System.Drawing.Point(276, 118);
            this.lbDoSang.Name = "lbDoSang";
            this.lbDoSang.Size = new System.Drawing.Size(27, 16);
            this.lbDoSang.TabIndex = 8;
            this.lbDoSang.Text = "0%";
            // 
            // MenuMayTram_TienIch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 179);
            this.Controls.Add(this.lbDoSang);
            this.Controls.Add(this.lbTocDoChuot);
            this.Controls.Add(this.lbAmLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trkbarDoSang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trkbarChuot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trkbAmLuong);
            this.Name = "MenuMayTram_TienIch";
            this.Text = "Tiện ích";
            ((System.ComponentModel.ISupportInitialize)(this.trkbAmLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbarChuot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbarDoSang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trkbAmLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trkbarChuot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trkbarDoSang;
        private System.Windows.Forms.Label lbAmLuong;
        private System.Windows.Forms.Label lbTocDoChuot;
        private System.Windows.Forms.Label lbDoSang;
    }
}