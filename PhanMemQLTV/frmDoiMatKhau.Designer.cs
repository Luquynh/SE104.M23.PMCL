namespace PhanMemQLTV
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtNhapLaiMKMoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNhapLaiMatKhau = new System.Windows.Forms.CheckBox();
            this.chkMatKhauMoi = new System.Windows.Forms.CheckBox();
            this.chkMatKhauCu = new System.Windows.Forms.CheckBox();
            this.btnDMK = new Guna.UI2.WinForms.Guna2Button();
            this.btbHome = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.SuspendLayout();
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(198, 24);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(151, 27);
            this.txtTenTaiKhoan.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(198, 54);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(151, 27);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(198, 84);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(151, 27);
            this.txtMatKhauMoi.TabIndex = 2;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // txtNhapLaiMKMoi
            // 
            this.txtNhapLaiMKMoi.Location = new System.Drawing.Point(198, 116);
            this.txtNhapLaiMKMoi.Name = "txtNhapLaiMKMoi";
            this.txtNhapLaiMKMoi.Size = new System.Drawing.Size(151, 27);
            this.txtNhapLaiMKMoi.TabIndex = 3;
            this.txtNhapLaiMKMoi.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên tài khoản: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập mật khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập mật khẩu mới:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nhập lại mật khẩu mới";
            // 
            // chkNhapLaiMatKhau
            // 
            this.chkNhapLaiMatKhau.AutoSize = true;
            this.chkNhapLaiMatKhau.Location = new System.Drawing.Point(355, 118);
            this.chkNhapLaiMatKhau.Name = "chkNhapLaiMatKhau";
            this.chkNhapLaiMatKhau.Size = new System.Drawing.Size(64, 23);
            this.chkNhapLaiMatKhau.TabIndex = 8;
            this.chkNhapLaiMatKhau.Text = "Xem";
            this.chkNhapLaiMatKhau.UseVisualStyleBackColor = true;
            this.chkNhapLaiMatKhau.CheckedChanged += new System.EventHandler(this.chkNhapLaiMatKhau_CheckedChanged);
            // 
            // chkMatKhauMoi
            // 
            this.chkMatKhauMoi.AutoSize = true;
            this.chkMatKhauMoi.Location = new System.Drawing.Point(356, 86);
            this.chkMatKhauMoi.Name = "chkMatKhauMoi";
            this.chkMatKhauMoi.Size = new System.Drawing.Size(64, 23);
            this.chkMatKhauMoi.TabIndex = 7;
            this.chkMatKhauMoi.Text = "Xem";
            this.chkMatKhauMoi.UseVisualStyleBackColor = true;
            this.chkMatKhauMoi.CheckedChanged += new System.EventHandler(this.chkMatKhauMoi_CheckedChanged);
            // 
            // chkMatKhauCu
            // 
            this.chkMatKhauCu.AutoSize = true;
            this.chkMatKhauCu.Location = new System.Drawing.Point(356, 57);
            this.chkMatKhauCu.Name = "chkMatKhauCu";
            this.chkMatKhauCu.Size = new System.Drawing.Size(64, 23);
            this.chkMatKhauCu.TabIndex = 6;
            this.chkMatKhauCu.Text = "Xem";
            this.chkMatKhauCu.UseVisualStyleBackColor = true;
            this.chkMatKhauCu.CheckedChanged += new System.EventHandler(this.chkMatKhauCu_CheckedChanged);
            // 
            // btnDMK
            // 
            this.btnDMK.Animated = true;
            this.btnDMK.AutoRoundedCorners = true;
            this.btnDMK.BackColor = System.Drawing.Color.Transparent;
            this.btnDMK.BorderRadius = 23;
            this.btnDMK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDMK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDMK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDMK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDMK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(74)))));
            this.btnDMK.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDMK.ForeColor = System.Drawing.Color.White;
            this.btnDMK.Image = ((System.Drawing.Image)(resources.GetObject("btnDMK.Image")));
            this.btnDMK.Location = new System.Drawing.Point(29, 182);
            this.btnDMK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDMK.Name = "btnDMK";
            this.btnDMK.Size = new System.Drawing.Size(187, 49);
            this.btnDMK.TabIndex = 34;
            this.btnDMK.Text = "Đổi Mật Khẩu";
            this.btnDMK.UseTransparentBackground = true;
            this.btnDMK.Click += new System.EventHandler(this.btnDMK_Click);
            // 
            // btbHome
            // 
            this.btbHome.Animated = true;
            this.btbHome.AutoRoundedCorners = true;
            this.btbHome.BackColor = System.Drawing.Color.Transparent;
            this.btbHome.BorderRadius = 23;
            this.btbHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btbHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btbHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btbHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btbHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(74)))));
            this.btbHome.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btbHome.ForeColor = System.Drawing.Color.White;
            this.btbHome.Image = ((System.Drawing.Image)(resources.GetObject("btbHome.Image")));
            this.btbHome.Location = new System.Drawing.Point(344, 182);
            this.btbHome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btbHome.Name = "btbHome";
            this.btbHome.Size = new System.Drawing.Size(98, 49);
            this.btbHome.TabIndex = 37;
            this.btbHome.Text = "Trở về ";
            this.btbHome.UseTransparentBackground = true;
            this.btbHome.Click += new System.EventHandler(this.btbHome_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(300, 200);
            this.guna2GroupBox1.TabIndex = 38;
            this.guna2GroupBox1.Text = "guna2GroupBox1";
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 234);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.btbHome);
            this.Controls.Add(this.btnDMK);
            this.Controls.Add(this.chkNhapLaiMatKhau);
            this.Controls.Add(this.chkMatKhauMoi);
            this.Controls.Add(this.chkMatKhauCu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNhapLaiMKMoi);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenTaiKhoan);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtNhapLaiMKMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNhapLaiMatKhau;
        private System.Windows.Forms.CheckBox chkMatKhauMoi;
        private System.Windows.Forms.CheckBox chkMatKhauCu;
        private Guna.UI2.WinForms.Guna2Button btnDMK;
        private Guna.UI2.WinForms.Guna2Button btbHome;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
    }
}