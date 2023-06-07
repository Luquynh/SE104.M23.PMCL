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
namespace PhanMemQLTV
{
    public partial class Docgiamanhinh : Form
    {
        public string tKDG;
        public Docgiamanhinh(string tkDG)
        {
            InitializeComponent();
            tKDG = tkDG;
            MessageBox.Show(tkDG);
            travegiatri();
            setControlsdcsua(false);
            btnSua.Enabled = true;
            
            huythaotac.Enabled = false;
            guna2Button4.Enabled = false;
        }
        string strKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private DataTable myTable;





        /// <summary>
        /// /////////////////////////////////////////////////
        /// </summary>
        private DataTable myTableSach, myTableSach1;
        private DataTable myTableDG;
        private SqlDataReader myDataReaderSach;
        private SqlDataReader myDataReaderSLSachDaMuon;
        //private SqlDataReader myDataReaderMuonTra;
        //////////////////////////////////////////////////////////////////////////////////

        // Kết nối tới sql
        //Ket noi tra ve bang
        
        private DataTable ketnoictpm(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTableSach1 = new DataTable();
            myDataAdapter.Fill(myTableSach1);
            return myTableSach1;
        }
        private void ketnoithaotackhac(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);

        }
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int sosachdangmuondg;
        private DataTable thongtindg;
        private void travegiatri()
        {
            string strlaydulieu = "select * from tblDocGia where MaDG='" + tKDG + "'";
            thongtindg = ketnoictpm(strlaydulieu);
            
            {
                //MessageBox.Show(thongtindg.Rows[0][0].ToString());
                //luuMaSach = cboMaSach0.Text;
                txtMaDG.Text = thongtindg.Rows[0][0].ToString();
                 txtTenDG.Text = thongtindg.Rows[0][1].ToString();
                cboGioiTinh.Text = thongtindg.Rows[0][2].ToString();
                dtmNgaySinh.Text = Convert.ToDateTime(thongtindg.Rows[0][3]).ToString();
                emaildg.Text = thongtindg.Rows[0][4].ToString();
                txtDiaChi.Text = thongtindg.Rows[0][5].ToString();
                socmnddg.Text = thongtindg.Rows[0][6].ToString();
                dtmNgLapThe.Text = thongtindg.Rows[0][10].ToString();
                
                ngayhethandg.Text = thongtindg.Rows[0][11].ToString();
                string query = "set dateformat dmy; SELECT COUNT(*) FROM ChiTietPM, tblPhieuMuon WHERE ChiTietPM.MaPhieu = tblPhieuMuon.MaPhieu AND MaDG = '" + tKDG + "' AND ChiTietPM.Datra = '0' ";
                ketnoithaotackhac(query);
                sosachdangmuondg = (int)myCommand.ExecuteScalar();
                sosachdangmuon.Text = sosachdangmuondg.ToString();
            }
        }
        private void setControlsdcsua(bool edit)
        {
            txtMaDG.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtTenDG.Enabled = edit;
            dtmNgaySinh.Enabled = edit;
            dtmNgLapThe.Enabled = false;
            ngayhethandg.Enabled = false;
            emaildg.Enabled = edit;
            txtDiaChi.Enabled = edit;
            socmnddg.Enabled = edit;
            sosachdangmuon.Enabled = false;


        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMKDG doimatkhaudocgia = new frmDoiMKDG();
            doimatkhaudocgia.Show();
        }

        

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            Docgiamanhinh dg = new Docgiamanhinh(tKDG);
            dg.Show();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmDoiMKDG doimatkhaudocgia = new frmDoiMKDG();
            doimatkhaudocgia.Show();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void suathongtin_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            setControlsdcsua(true);
            huythaotac.Enabled = true;
            guna2Button4.Enabled = true;
        }
        // lich su nguoi muon 
        private void btnChoMuon0_Click(object sender, EventArgs e)
        {
            if (lsmuontra.DataSource != null)
            {
                lsmuontra.DataSource = null;
                lsmuontra.Columns.Clear();
            }
            string truyvan = "Select ct.MaPhieu ,MaCTPM ,MaSach ,NgayMuon ,pm.NgayhenTra ,Datra  from tblPhieuMuon pm,ChiTietPM ct Where pm.MaPhieu=ct.MaPhieu and MaDG='"+tKDG+"'";
            lsmuontra.DataSource=ketnoictpm(truyvan);

        }
        //luu sua thong tin 
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string strCapNhatSLCon = "set dateformat dmy; update tblDocGia set TenDG=N'" + txtTenDG.Text + "',GioiTinhDG=N'" + cboGioiTinh.Text + "',NgaySinhDG='" + dtmNgaySinh.Text + "',EmailDG=N'" + emaildg.Text + "',DiaChiDG=N'" + txtDiaChi.Text + "',Socmnd=N'" + socmnddg.Text + "' where MaDG='" + tKDG + "'";
                ketnoictpm(strCapNhatSLCon);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Sửa thông tin cá nhân thành công!");
            }
            catch (Exception)
            {

            }
            btnSua.Enabled = true;
            setControlsdcsua(false);
            huythaotac.Enabled = false;
            guna2Button4.Enabled = false;
        }

        private void huythaotac_Click(object sender, EventArgs e)
        {
            setControlsdcsua(false);
            huythaotac.Enabled = false;
            guna2Button4.Enabled = false;
            btnSua.Enabled = true;
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            Timkiemsach tk = new Timkiemsach();
            tk.Show();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        //lich su tra nguoi dung 
        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (lsmuontra.DataSource != null)
            {
                lsmuontra.DataSource = null;
                lsmuontra.Columns.Clear();
            }
            string truyvan = "Select pt.MaPhieuTra ,MaCTPT ,MaSach ,NgayTra ,vipham  from PhieuTra pt,ChiTietPT ct Where pt.MaPhieuTra=ct.MaPhieuTra and MaDG='" + tKDG + "'";
            lsmuontra.DataSource = ketnoictpm(truyvan);
        }
    }
}
