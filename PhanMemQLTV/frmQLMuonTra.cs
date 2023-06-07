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
    public partial class frmQLMuonTra : Form
    {
        public int sosachdmuonmax;
        public frmQLMuonTra()
        {
            InitializeComponent();
            string query = "Select giatri from ThamSo  where Tents = 'Sosachdangmuonmax'";
            ketnoithaotackhac(query);
            sosachdmuonmax = Convert.ToInt32(myCommand.ExecuteScalar());


        }
        
        // Khai báo
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
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh,myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable=new DataTable();
            myDataAdapter.Fill(myTable);
            dataGridViewDSMuon0.DataSource=myTable;
            dataGridViewDSMuon0.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewDSMuon0.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            return myTable;
        }
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
        //ket noi thac tac khac
        private void ketnoithaotackhac(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);

        }
        // Kết nối tới tblSach
        private DataTable ketnoitblSach(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTableSach = new DataTable();
            myDataAdapter.Fill(myTableSach);
            return myTableSach;
        }
        
        //cboMaSach0.SelectedIndex=dongcuoi;
        //int dongcuoi = myTableSach.Rows.Count+1;

        // Lấy mã sách lên cboMasach0
        public void layMaSachMuon()
        { 
            string strLayMaSach = "select MaSach from tblSach";
            cboMaSach0.DataSource = ketnoitblSach(strLayMaSach);
            cboMaSach0.DisplayMember = "MaSach";
            cboMaSach0.ValueMember = "MaSach";
            myConnection.Close();
        }

        // Kết nối tới tblDocGia
        private DataTable ketnoitblDocGia(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTableDG = new DataTable();
            myDataAdapter.Fill(myTableDG);
            return myTableDG;
        }

        // lấy Mã DG lên cboMaDG
        public void layMaDGMuon()
        {
            string strLayMaDG = "select * from tblDocGia";
            cboMaDG0.DataSource = ketnoitblSach(strLayMaDG);
            cboMaDG0.DisplayMember = "MaDG";
            cboMaDG0.ValueMember = "MaDG";
            myConnection.Close();
        }

        private void setControlsMuon(bool edit)
        {
            cboMaDG0.Enabled = edit;
            cboMaSach0.Enabled = edit;
            txtSLMuon0.Enabled = edit;
            //dtmNgayMuon0.Enabled = edit;
            //dtmNgayTra0.Enabled = edit;
            txtGhiChu0.Enabled = edit;
            dtmNgayTra0.Enabled = edit;
            dtmNgayMuon0.Enabled = edit;
            btn_Themsachmuon.Enabled = edit;
        }

        private void frmQLMuonTra_Load(object sender, EventArgs e)
        {
            //soSanhNgay();


            string cauTruyVan = "select * from tblPhieuMuon";
            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon0.AutoGenerateColumns = false;
            myConnection.Close();
            string ketnoiphieutra = "select* from PhieuTra";
            dataGridViewDStra.DataSource = ketnoi(ketnoiphieutra);
            dataGridViewDStra.AutoGenerateColumns = false;
            myConnection.Close();

            radMaDG.Checked = true;
            radMaDG1.Checked = true;
            //btn Muon sach 
            btnChoMuon0.Text = "Cho Mượn";
            
            btnChoMuon0.Enabled = false;
            btnHuy0.Enabled = false;
            txtMaPhieu0.Enabled = false;
            txtcmnd.Enabled = false;
            txtTenDG.Enabled = false;
            dtmNgLapThe.Enabled = false;
            sosachdangmuon.Enabled = false;
            //txtMaPhieu0.Enabled = false;
            txtTTMaSach.Enabled = false;
            txtTTTenSach.Enabled = false;
            txtTTSLCon.Enabled = false;
            txtTTTenTG.Enabled = false;
            //dtmNgayTra0.Enabled = false;
            //dtmNgayMuon0.Enabled = false;
            //txtTinhTrang0.Enabled = false;
            //ben tab tra sach
            txtMaPhieutra.Enabled = false;
            comboMaDGtra.Enabled = false;
            combosltra.Enabled = false;
            comboBoMasachtra.Enabled = false;
            dtmNgayTra1.Enabled = false;
            Themsachtra.Enabled = false;
            //Nut ben tra sach
            btnHuytrasach.Enabled = false;
            btnLuutrasach.Enabled = false;
            setControlsMuon(false);
            setControlsTra(false);
        }

        public string maPhieu0, maDG0, maSach0, slMuon0, ngayMuon0, ngayTra0, ghiChu0;
        

        private void txtNDTimKiem_TextChanged(object sender, EventArgs e)
        {
            setControlsMuon(false);
            btnNhap.Enabled = false;
            btnChoMuon0.Enabled = false;
            btnHuy0.Enabled = false;

            if (radMaDG.Checked)
            {
                string timkiemMaDG = "select * from tblPhieuMuon where MaDG like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMaDG);
                myCommand.ExecuteNonQuery();
                dataGridViewDSMuon0.DataSource = ketnoi(timkiemMaDG);
                dataGridViewDSMuon0.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radMaSach.Checked)
            {
                string timkiemMS = "select * from tblPhieuMuon where MaPhieu like '%" + txtNDTimKiem.Text + "%'";
                ketnoi(timkiemMS);
                myCommand.ExecuteNonQuery();
                dataGridViewDSMuon0.DataSource = ketnoi(timkiemMS);
                dataGridViewDSMuon0.AutoGenerateColumns =true;
                myConnection.Close();
            }
        }


        private void btnLoadDanhSach0_Click(object sender, EventArgs e)
        {
            txtNDTimKiem.Text = "";
            btnNhap.Enabled = true;
            btnChoMuon0.Enabled = false;
            btnHuy0.Enabled = false;
            setControlsMuon(false);

            string cauTruyVanLoad = "select * from tblPhieuMuon";
            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVanLoad);
            dataGridViewDSMuon0.AutoGenerateColumns = false;
            myConnection.Close();
        }

        public string tangMaTuDong()
        {
            string cauTruyVan = "select * from tblPhieuMuon";
            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
            dataGridViewDSMuon0.AutoGenerateColumns = false;
            myConnection.Close();

            string maTuDong = "";
            if (myTable.Rows.Count <= 0)
            {
                maTuDong = "MP001";
            }
            else
            {
                int k;
                maTuDong = "MP";
                k = Convert.ToInt32(myTable.Rows[myTable.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = k + 1;
                if (k < 10)
                {
                    maTuDong = maTuDong + "00";
                }
                else if (k < 100)
                {
                    maTuDong = maTuDong + "0";
                }
                maTuDong = maTuDong + k.ToString();
            }
            return maTuDong;
        }

        public int xuly;
        public static DateTime today = DateTime.Now;  //Get Date time now on system
        public static DateTime newday = today.AddDays(14);
        //txt txtMaPhieu0.Text ma cua bang phieu muon
        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox13.Enabled = false;


            layMaDGMuon();
            layMaSachMuon();
            
            btnChoMuon0.Text = "Cho Mượn";
            
            setControlsMuon(true);
            btnNhap.Enabled = false;
            //btn_Themsachmuon.Enabled = false;
            btnChoMuon0.Enabled = true;
            btnHuy0.Enabled = true;
            btnGiaHan.Enabled = false;
            dataGridViewDSMuon0.Enabled = false;

            txtMaPhieu0.Text = tangMaTuDong();
            cboMaDG0.Text = "";
            cboMaSach0.Text = "";
            txtSLMuon0.Text = "";
            dtmNgayMuon0.Text = Convert.ToString(today); ;
            dtmNgayTra0.Text = Convert.ToString(newday);
            //dtmNgayTra0.Text = "";
            txtGhiChu0.Text = "";

            lblNhapSLNhap.Text = "";
            xuly = 0;
        }

      
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        public string ngaymuon, thangmuon, nammuon, ngaytra, thangtra, namtra, ngaydgmuon, ngaydgtra;
        public int hieumuon,hieutra,catthangmuon,catngaymuon,catngaytra,catthangtra, songaymuon, sothangmuon, sonammuon, songaytra, sothangtra, sonamtra, kq = 1;

        private void dtmNgayMuon0_ValueChanged(object sender, EventArgs e)
        {
            dtmNgayTra0.Value = dtmNgayMuon0.Value.AddDays(14);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabQLMuonTraSach_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabQLMuonTraSach.TabPages[e.Index];
            Color col = Color.MidnightBlue;

            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            
            TextRenderer.DrawText(e.Graphics, page.Text, page.Font, paddedBounds, Color.White);
        }

        private void txtGhiChu1_TextChanged(object sender, EventArgs e)
        {
            
        }
        public int slmuonds ;
        private void txtSLMuon0_SelectedIndexChanged(object sender, EventArgs e)
        {
            slmuonds = Int32.Parse(txtSLMuon0.SelectedItem.ToString());
            if (slmuonds + sosachdangmuondg > sosachdmuonmax)
            {
                int hieu = sosachdmuonmax - sosachdangmuondg;
                MessageBox.Show("Không hợp lệ. Vui lòng chọn số lượng sách mượn từ "+hieu.ToString()+" trở xuống!" );
            }
            //slmuonds = Int32.Parse(txtSLMuon0.SelectedItem.ToString());
            //for (int i = 1; i <= slmuonds; i++)
            //{   
            //    string[] row = new string[] { i.ToString()};
            //    dsqsmuon.Rows.Add(row);
            //}
            //MessageBox.Show(slMuon0.ToString());
        }
        //btn_Themsachmuon
        //MaSachmuon,TenSachmuon
        public int row_dsqsm = 1;
        public string gt;

        private void dataGridViewDSMuon0_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                txtMaPhieu0.Text = myTable.Rows[row]["MaPhieu"].ToString();
                maPhieu0 = txtMaPhieu0.Text;
                cboMaDG0.Text = myTable.Rows[row]["MaDG"].ToString();
                maDG0 = cboMaDG0.Text;
                dtmNgayMuon0.Text = myTable.Rows[row]["NgayMuon"].ToString();
                ngayMuon0 = dtmNgayMuon0.Text;
                dtmNgayTra0.Text = myTable.Rows[row]["NgayhenTra"].ToString();
                ngayTra0 = dtmNgayTra0.Text;
                //cboMaSach0.Text = myTable.Rows[row]["MaSach"].ToString();
                //maSach0 = cboMaSach0.Text;
                txtSLMuon0.Text = myTable.Rows[row]["SLMuon"].ToString();
                slMuon0 = txtSLMuon0.Text;
                
                
                //cboTinhTrang0.Text = myTable.Rows[row]["TinhTrang"].ToString();
                //tinhTrang0 = cboTinhTrang0.Text;
                txtGhiChu0.Text = myTable.Rows[row]["GhiChu"].ToString();
                ghiChu0 = txtGhiChu0.Text;

            }
            catch (Exception)
            {

            }
        }
        public int sosachdangmuondg;
        public DateTime ngayhethanthe;
        private void cboMaDG0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strlaydulieu = "select * from tblDocGia where MaDG='" + cboMaDG0.SelectedValue.ToString() + "'";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = strlaydulieu;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataReaderSach = myCommand.ExecuteReader();
            
            while (myDataReaderSach.Read())
            {
                //luuMaSach = cboMaSach0.Text;
                txtcmnd.Text = myDataReaderSach.GetString(6);
                
                //MaSachmuon = txtTTMaSach.Text;
                txtTenDG.Text = myDataReaderSach.GetString(1); 
                dtmNgLapThe.Text = myDataReaderSach.GetDateTime(11).ToString();
                
                string query = "set dateformat dmy; SELECT COUNT(*) FROM ChiTietPM, tblPhieuMuon WHERE ChiTietPM.MaPhieu = tblPhieuMuon.MaPhieu AND MaDG = '" + cboMaDG0.SelectedValue.ToString() + "' AND ChiTietPM.Datra = '0' ";
                ketnoithaotackhac(query);
                sosachdangmuondg = (int)myCommand.ExecuteScalar();
                sosachdangmuon.Text = sosachdangmuondg.ToString();

            }
            
            


        }

        //private void xemctpm_Click(object sender, EventArgs e)
        //{
        //    xemctpmcs ctpm = new xemctptcs(maPhieu0);
        //    ctpm.Show();
        //}

       
        //Them sach muon
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (row_dsqsm <= slmuonds)
            {
                string[] row = new string[] { row_dsqsm.ToString(), MaSachmuon, TenSachmuon, strluuSLCon };
                dsqsmuon.Rows.Add(row);

                //Them thong tin vao CTPM
                gt = dsqsmuon.Rows[row_dsqsm - 1].Cells["MaSach_DSQS"].Value.ToString();
                //MessageBox.Show(gt);
                row_dsqsm++;
            }
            else
            {
                MessageBox.Show("Không thể nhập nhiều hơn số lượng mượn");
            }
            
        }

        //private void xemctpm_Click(object sender, EventArgs e)
        //{
        //    //dataGridViewDSMuon0.DataSource = null;
        //    string query = "Select * from ChiTietPM";
        //    dataGridViewDSMuon0.DataSource = ketnoictpm(query);
        //    dataGridViewDSMuon0.AutoGenerateColumns = false;
        //    myConnection.Close();
        //}

        //private void xemphieumuon_Click(object sender, EventArgs e)
        //{
        //    //dataGridViewDSMuon0.DataSource = null;
        //    string query = "Select* from tblPhieuMuon";
        //    dataGridViewDSMuon0.DataSource = ketnoi(query);
        //    dataGridViewDSMuon0.AutoGenerateColumns = false;
        //    myConnection.Close();
        //}

        public void soSanhNgay()
        {
            catngaymuon = dtmNgayMuon0.Text.IndexOf("/");
            ngaymuon = dtmNgayMuon0.Text.Substring(0, catngaymuon);
            catthangmuon = dtmNgayMuon0.Text.LastIndexOf("/");
            hieumuon = (catthangmuon - 1) - catngaymuon;
            thangmuon = dtmNgayMuon0.Text.Substring(catngaymuon + 1, hieumuon);
            nammuon = dtmNgayMuon0.Text.Substring(catthangmuon + 1, 4);

            songaymuon= Convert.ToInt32(ngaymuon);
            sothangmuon= Convert.ToInt32(thangmuon);
            sonammuon= Convert.ToInt32(nammuon);

            catngaytra = dtmNgayTra0.Text.IndexOf("/");
            ngaytra = dtmNgayTra0.Text.Substring(0, catngaytra);
            catthangtra = dtmNgayTra0.Text.LastIndexOf("/");
            hieutra = (catthangtra - 1) - catngaytra;
            thangtra = dtmNgayTra0.Text.Substring(catngaytra + 1, hieutra);
            namtra = dtmNgayTra0.Text.Substring(catthangtra + 1, 4);

            songaytra = Convert.ToInt32(ngaytra);
            sothangtra = Convert.ToInt32(thangtra);
            sonamtra = Convert.ToInt32(namtra);

            DateTime tgMuon = new DateTime(sonammuon, sothangmuon, songaymuon);
            DateTime tgTra = new DateTime(sonamtra, sothangtra, songaytra);


            //MessageBox.Show("Ngày mượn: " + ngaymuon + "Tháng mượn: " + thangmuon + "Năm mượn: " + nammuon);
            kq=tgTra.CompareTo(tgMuon);
            //MessageBox.Show("kq: " + kq, "Thông Báo");
            //DateTime ngaymuon= new DateTime()
        }

       

        public string strluuSLCon,MaSachmuon,TenSachmuon;
        private void cboMaSach0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strlaydulieu = "select * from tblSach where MaSach='" + cboMaSach0.SelectedValue.ToString() + "'";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = strlaydulieu;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataReaderSach = myCommand.ExecuteReader();
            while (myDataReaderSach.Read())
            {
                //luuMaSach = cboMaSach0.Text;
                txtTTMaSach.Text = myDataReaderSach.GetString(0);
                MaSachmuon = txtTTMaSach.Text;
                txtTTTenSach.Text = myDataReaderSach.GetString(2);
                TenSachmuon = txtTTTenSach.Text;
                txtTTTenTG.Text = myDataReaderSach.GetString(4);
                txtTTSLCon.Text = myDataReaderSach.GetInt32(7).ToString();
                strluuSLCon = txtTTSLCon.Text;
            }
        }

       
        // Kiểm tra số lượng sách đg đã mượn
        public int luuSLSachDGDaMuon;

       

        private void slSachDaMuon()
        {
            string strTinhSLSachDaMuon = "select sum(SLMuon) as Tong from tblPhieuMuon where MaDG='" + cboMaDG0.Text + "' group by MaDG";
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = strTinhSLSachDaMuon;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataReaderSLSachDaMuon = myCommand.ExecuteReader();
            while (myDataReaderSLSachDaMuon.Read())
            {
                luuSLSachDGDaMuon = Convert.ToInt32(myDataReaderSLSachDaMuon.GetInt32(0).ToString());
            }

        }
        

        public int luuSLCon, luuSLMuon;
        public int luuSLSauChoMuon;
        public int ktmuonchua;
        //public static DateTime today= DateTime.Now;
        //public static DateTime newday = today.AddDays(21);

        //DateTime today = DateTime.Now;  //Get Date time now on system
        //DateTime newday = today.AddDays(21);
        //dsqsmuon,slmuonds
        
        private void muonSach()
        {
            if (cboMaDG0.Text == "")
            {
                errMaDG0.SetError(cboMaDG0, "Vui lòng chọn Mã ĐG");
            }
            else
            {
                errMaDG0.Clear();
            }

            if (cboMaSach0.Text == "")
            {
                errMaSach0.SetError(cboMaSach0, "Vui lòng chọn Mã Sách");
            }
            else
            {
                errMaSach0.Clear();
            }

            if (txtSLMuon0.Text == "")
            {
                errSLMuon0.SetError(txtSLMuon0, "Vui lòng chọn SL Mượn");
            }
            else
            {
                errSLMuon0.Clear();
            }

            bool isNumberSLNhap = int.TryParse(txtSLMuon0.Text, out luuSLMuon);
            if (isNumberSLNhap == false)
            {
                MessageBox.Show("Vui lòng nhập số trong ô SL", "Thông Báo");
            }

            //slSachDaMuon();
            luuSLCon = Convert.ToInt32(strluuSLCon);
            //luuSLSauChoMuon = luuSLCon - luuSLMuon;
            luuSLSauChoMuon = luuSLCon - luuSLMuon;
            //soSanhNgay();
            //txtMaPhieu0.Text
            if (txtSLMuon0.Text.Length > 0 && cboMaDG0.Text.Length > 0 && cboMaSach0.Text.Length > 0)
            {
                if (luuSLMuon <= luuSLCon)
                {
                    //MessageBox.Show("SL đã mượn: " + luuSLSachDGDaMuon);
                    //MessageBox.Show("SL còn: " + luuSLCon);
                    //MessageBox.Show("Sl mượn: " + txtSLMuon0.Text);
                    //Thỏa mọi điều kiện để cho mượn sách 
                    /*(luuSLSachDGDaMuon + luuSLMuon) <= 5 && (luuSLSachDGDaMuon + luuSLMuon) > 0*/
                    //slmuonds + sosachdangmuondg > sosachdmuonmax
                    if (sosachdangmuondg<=sosachdmuonmax && sosachdangmuondg+ slmuonds<= sosachdmuonmax)
                    {
                        if (kq == 1)
                        {
                            try
                            {
                                ktmuonchua = 0;
                                string themdongsqlMuon;
                                //Them phieu muon 
                                themdongsqlMuon = "set dateformat dmy; insert into tblPhieuMuon values ('" + txtMaPhieu0.Text + "','" + cboMaDG0.Text + "','"  + dtmNgayMuon0.Text + "','" + dtmNgayTra0.Text + "','" + txtSLMuon0.Text + "',N'" + txtGhiChu0.Text + "')";
                                ketnoi(themdongsqlMuon);
                                //MessageBox.Show("Cho mượn thành công.", "Thông Báo");
                                //ktmuonchua = 0;
                                myCommand.ExecuteNonQuery();
                                myConnection.Close();
                                ktmuonchua = 0;
                            }
                            catch (Exception)
                            {
                                //ktmuonchua = 1;
                            }
                            //update ChiTietPM
                            if (ktmuonchua == 0)
                            {
                                //MessageBox.Show(slmuonds.ToString());
                                try
                                {   //Dem so ctpm hien co
                                    string query = "set dateformat dmy; select count(*) from ChiTietPM ";
                                    ketnoithaotackhac(query);
                                    int soctpm = (int)myCommand.ExecuteScalar();
                                    for (int i = 0; i < slmuonds; i++)
                                    {   string masachbang;
                                        int slconbang;
                                        masachbang = dsqsmuon.Rows[i].Cells["MaSach_DSQS"].Value.ToString();
                                        slconbang = Convert.ToInt32(dsqsmuon.Rows[i].Cells["slcon"].Value.ToString())-1;
                                        //MessageBox.Show("i: "+i.ToString());
                                        string strluuSLSauChoMuon = luuSLSauChoMuon.ToString();
                                        string strCapNhatSLCon = "update tblSach set SLNhap='" + slconbang.ToString() + " ' where MaSach='" + masachbang + "'";
                                        ketnoi(strCapNhatSLCon);
                                        myCommand.ExecuteNonQuery();
                                        myConnection.Close();
                                        //MessageBox.Show("Đã cập nhật SL Sách vào trong kho.", "Thông Báo");
                                        //month(NgayThang) = " + dtmNgayMuon0.Value.Month + " and year(NgayThang) =
                                        
                                        //MessageBox.Show(cnt.ToString());


                                        //string query = "select * from ChiTietPM";
                                        //dataGridViewDSMuon0.DataSource = ketnoi(query);
                                        //dataGridViewDSMuon0.AutoGenerateColumns = false;
                                        //myConnection.Close();

                                        string maTuDong = "";
                                        if (soctpm == 0)
                                        {
                                            maTuDong = "CTPM001";
                                        }
                                        else
                                        {
                                            int k;
                                            maTuDong = "CTPM";
                                            k = soctpm+1;
                                            
                                            if (k < 10)
                                            {
                                                maTuDong = maTuDong + "00";
                                            }
                                            else if (k < 100)
                                            {
                                                maTuDong = maTuDong + "0";
                                            }
                                            maTuDong = maTuDong + k.ToString();
                                        }
                                        //dang sua 
                                        string datra = "0";
                                        query = "set dateformat dmy; insert into ChiTietPM values('" + maTuDong + "','" + masachbang + "','" + txtMaPhieu0.Text + "','" + dtmNgayTra0.Text + "','" + datra + "')";
                                        ketnoithaotackhac(query);
                                        myCommand.ExecuteNonQuery();
                                        myConnection.Close();
                                        //else
                                        //{
                                        //    //query = "set dateformat dmy; update ChiTietPM set SoLanMuon += " + txtSLMuon0.Text + " where month(NgayThang) = " + dtmNgayMuon0.Value.Month + " and year(NgayThang) = " + dtmNgayMuon0.Value.Year + " and MaSach = '" + cboMaSach0.Text + "'";
                                        //    //ketnoi(query);
                                        //    //myCommand.ExecuteNonQuery();
                                        //}
                                        soctpm ++;
                                    }

                                    //else
                                    //{
                                    //    //query = "set dateformat dmy; update ChiTietPM set SoLanMuon += " + txtSLMuon0.Text + " where month(NgayThang) = " + dtmNgayMuon0.Value.Month + " and year(NgayThang) = " + dtmNgayMuon0.Value.Year + " and MaSach = '" + cboMaSach0.Text + "'";
                                    //    //ketnoi(query);
                                    //    //myCommand.ExecuteNonQuery();
                                    //}


                                    btnNhap.Enabled = true;
                                    btnChoMuon0.Enabled = false;
                                    btnHuy0.Enabled = false;
                                    btnGiaHan.Enabled = true;
                                    setControlsMuon(false);
                                    dataGridViewDSMuon0.Enabled = true;
                                    MessageBox.Show("Mượn sách thành công!");
                                    MessageBox.Show("Đã cập nhật SL Sách vào trong kho.", "Thông Báo");
                                }
                                catch (Exception)
                                {

                                }
                            }
                            else
                                MessageBox.Show("Mượn thất bại.", "Thông Báo");

                            string cauTruyVan = "select * from tblPhieuMuon";
                            dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
                            dataGridViewDSMuon0.AutoGenerateColumns = false;
                            myConnection.Close();
                        }
                        else
                            MessageBox.Show("Vui lòng chọn ngày trả lớn hơn ngày mươn.", "Thông Báo");



                    }
                    else
                    {
                        MessageBox.Show("Không thể mượn.\nSố sách bạn mượn quá 10 cuốn", "Vui lòng trả bớt sách!");
                        txtSLMuon0.Text = "";
                        txtSLMuon0.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Không thể mượn nhiều hơn số lượng còn.", "Thông Báo");

                    txtSLMuon0.Text = "";
                    txtSLMuon0.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo");
                txtSLMuon0.Text = "";
                txtSLMuon0.Focus();
            }
        }

        private void giaHanSach()
        {
            //soSanhNgay();
            if (kq == 1)
            {
                string strCapNhatSLCon = "set dateformat dmy; update tblPhieuMuon set NgayMuon='" + dtmNgayMuon0.Text + " ', NgayhenTra='" + dtmNgayTra0.Text + "' where MaPhieu='" + txtMaPhieu0.Text + "'";
                ketnoi(strCapNhatSLCon);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Gia hạn thành công.", "Thông Báo");

                string cauTruyVan = "select * from tblPhieuMuon";
                dataGridViewDSMuon0.DataSource = ketnoi(cauTruyVan);
                dataGridViewDSMuon0.AutoGenerateColumns = false;
                myConnection.Close();

                setControlsMuon(false);
                btnNhap.Enabled = true;
                btnChoMuon0.Text = "Cho Mượn";
                
                btnChoMuon0.Enabled = false;
                btnGiaHan.Enabled = true;
                btnHuy0.Enabled = false;
                
                dataGridViewDSMuon0.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày trả lớn hơn ngày mượn.", "Thông Báo");
            }
                
        }
        private void btnChoMuon0_Click(object sender, EventArgs e)
        {
            //Lấy giá trị tham số 
            string query = "Select GiaTri from ThamSo Where TenTS='GiaTriThe'";
            ketnoi(query);
            int GiaTriThe = Convert.ToInt32(myCommand.ExecuteScalar());
            query = "set dateformat dmy; Select Ngayhethan from tblDocGia Where MaDG='" + cboMaDG0.Text + "'";
            ketnoi(query);
            DateTime ngayhethan = Convert.ToDateTime(myCommand.ExecuteScalar());

            

            TimeSpan han = DateTime.Now - ngayhethan;
            if (han.Days > 0)
            {
                MessageBox.Show("Thẻ đã hết hạn!Vui lòng gia hạn thẻ trước khi mượn!");
                return;
            }

            if (xuly==0)
            {
                muonSach();
            }
            else if(xuly==1)
            {
                giaHanSach();

                
            }
            //xoa du lieu trong bang ds muon
            if (dsqsmuon.DataSource != null)
            {
                dsqsmuon.DataSource = null;
            }
            else
            {
                dsqsmuon.Rows.Clear();
            }
        }

        private void btnxemchitiet_Click(object sender, EventArgs e)
        {
            xemCTPT pm = new xemCTPT(maPhieu1);
            pm.Show();
        }

        private void xemctpm_Click(object sender, EventArgs e)
        {
            xemCTPM pm = new xemCTPM(maPhieu0);
            pm.Show();
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            txtMaPhieu0.Text = maPhieu0;
            cboMaDG0.Text = maDG0;
            //cboMaSach0.Text = maSach0;
            txtSLMuon0.Text = slMuon0;
            dtmNgayMuon0.Text = Convert.ToString(today);

            dtmNgayTra0.Text = Convert.ToString(newday);
            txtGhiChu0.Text = ghiChu0;

            setControlsMuon(true);
            cboMaDG0.Enabled = false;
            cboMaSach0.Enabled = false;
            txtSLMuon0.Enabled = false;
            groupBox13.Enabled = false;

            btnNhap.Enabled = false;
            btnChoMuon0.Text = "Lưu";
            
            btnChoMuon0.Enabled = true;
            btnGiaHan.Enabled = false;
            btnHuy0.Enabled = true;
            xuly = 1;
        }

        private void btnHuy0_Click(object sender, EventArgs e)
        {
            txtMaPhieu0.Text = tangMaTuDong();
            cboMaDG0.Text = "";
            cboMaSach0.Text = "";
            txtSLMuon0.Text = "";
            dtmNgayMuon0.Value = DateTime.Now;
            dtmNgayTra0.Value = DateTime.Now.AddDays(5);
            txtGhiChu0.Text = "";

            btnChoMuon0.Text = "Cho Mượn";
            

            btnNhap.Enabled = true;
            btnChoMuon0.Enabled = false;
            btnGiaHan.Enabled = true;
            btnHuy0.Enabled = false;
            setControlsMuon(false);
            dataGridViewDSMuon0.Enabled = true;

            lblNhapSLNhap.Text = "";
            if (dsqsmuon.DataSource != null)
            {
                dsqsmuon.DataSource = null;
            }
            else
            {
                dsqsmuon.Rows.Clear();
            }
        }

        private void btnThoat0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // tabTraSach
        //public void layMaPhieuTra()
        //{
        //    string strLayMaPhieu = "select * from tblPhieuMuon";
        //    cboMaPhieu1.DataSource = ketnoitblSach(strLayMaPhieu);
        //    cboMaPhieu1.DisplayMember = "MaPhieu";
        //    cboMaPhieu1.ValueMember = "MaPhieu";
        //    myConnection.Close();
        //}
        public int xulytra = 0;
        public string tangMatratudong()
        {
            string query = "set dateformat dmy; select count(*) from PhieuTra ";
            ketnoithaotackhac(query);
            int soctpt = (int)myCommand.ExecuteScalar();

            myConnection.Close();

            string maTuDong = "";
            if (myTable.Rows.Count <= 0)
            {
                maTuDong = "MPT001";
            }
            else
            {
                int k;
                maTuDong = "MPT";
                //k = Convert.ToInt32(myTable.Rows[myTable.Rows.Count - 1][0].ToString().Substring(2, 3));
                k = soctpt + 1;
                if (k < 10)
                {
                    maTuDong = maTuDong + "00";
                }
                else if (k < 100)
                {
                    maTuDong = maTuDong + "0";
                }
                maTuDong = maTuDong + k.ToString();
            }
            return maTuDong;
        }
        private void comboMaDGtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoMasachtra.Enabled = true;
            combosltra.Enabled = true;
            //comboBoMasachtra.Enabled = true;
            string query = "set dateformat dmy; SELECT COUNT(*) FROM ChiTietPM, tblPhieuMuon WHERE ChiTietPM.MaPhieu = tblPhieuMuon.MaPhieu AND MaDG = '" + comboMaDGtra.SelectedValue.ToString() + "' AND ChiTietPM.Datra = '0' ";
            ketnoithaotackhac(query);
            sosachdangmuondg = (int)myCommand.ExecuteScalar();

            this.combosltra.Items.Clear();
            for (int i = 1; i <= sosachdangmuondg; i++)
            {
                this.combosltra.Items.AddRange(new object[] {
            i.ToString()
            });
            }
            
            if (comboMaDGtra.SelectedValue.ToString().Substring(0, 1) == "D")
            {
                layMasachTra(comboMaDGtra.SelectedValue.ToString());
                if (comboBoMasachtra.Items.Count == 0)
                {
                    MessageBox.Show("Độc giả này không mượn sách nào hết! "+
                        " Vui lòng kiểm tra lại! ");
                    comboBoMasachtra.Enabled = false;
                    combosltra.Enabled = false;
                }
            }
            //int sosachdangmuoncu = sosachdangmuondg;
            //MessageBox.Show(comboMaDGtra.SelectedValue.ToString().Substring(0,1));
            //layMasachTra(comboMaDGtra.SelectedValue.ToString());

        }
        public string mactpm1, masach1, ngayhentra1;
        private void comboBoMasachtra_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public int row_index = 0;
        private DataTable dsquyentra;
        public int row_dsqstra;
        private void Themsachtra_Click(object sender, EventArgs e)
        {
            
            string ketnoiCTPM = "set dateformat dmy;Select MaCTPM,MaSach,ct.NgayhenTra from ChiTietPM ct,tblPhieuMuon pm where ct.MaPhieu=pm.MaPhieu and MaSach='" + comboBoMasachtra.SelectedValue.ToString()+"' and MaDG='"+comboMaDGtra.SelectedValue.ToString()+"'";
            dsquyentra = ketnoictpm(ketnoiCTPM);
            dsqstra.AutoGenerateColumns = false;
            myConnection.Close();
            //MessageBox.Show(dsquyentra.Rows[0][1].ToString());
            
            row_dsqstra = Convert.ToInt32(combosltra.Text);
            if (row_dsqstra > row_index)
            {
                string[] row = new string[] { dsquyentra.Rows[0][0].ToString(), dsquyentra.Rows[0][1].ToString(), dsquyentra.Rows[0][2].ToString() };
                dsqstra.Rows.Add(row);
                //dsqstra.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                row_index++;
            }
            else
            {
                MessageBox.Show("Không thể nhập nhiều hơn số lượng mượn");
            }
        }
        
        private void setControlsTra(bool edit)
        {
            txtMaPhieutra.Enabled = edit;
            comboMaDGtra.Enabled = edit;
            combosltra.Enabled = edit;
            comboBoMasachtra.Enabled = edit;
            dtmNgayTra1.Enabled = edit;
            Themsachtra.Enabled = edit;
            dstra.Enabled = edit;
        }
        
        private void btnHuytrasach_Click(object sender, EventArgs e)
        {
            setControlsTra(false);
            btnTraSach1.Enabled = true;

            //if (dsqstra.DataSource != null)
            //{
            //    dsqstra.DataSource = null;
            //}
            //else
            //{
            //    dsqstra.Rows.Clear();
            //}
        }
        public DataTable bangqhtra=new DataTable();
        private void btnLuutrasach_Click(object sender, EventArgs e)

        {
            //MessageBox.Show(dsqstra.Rows[0].Cells["MaCTPM"].Value.ToString());
            bangqhtra.Columns.Add("Mactpm",typeof(string));
            bangqhtra.Columns.Add("Masach", typeof(string));
            bangqhtra.Columns.Add("Ngayhentra", typeof(string));
            if (comboMaDGtra.Text == "")
            {
                errMaDG0.SetError(cboMaDG0, "Vui lòng chọn Mã ĐG");
            }
            else
            {
                errMaDG0.Clear();
            }

            if (comboBoMasachtra.Text == "")
            {
                errMaSach0.SetError(cboMaSach0, "Vui lòng chọn Mã Sách");
            }
            else
            {
                errMaSach0.Clear();
            }

            if (combosltra.Text == "")
            {
                errSLMuon0.SetError(txtSLMuon0, "Vui lòng chọn SL Trả");
            }
            else
            {
                errSLMuon0.Clear();
            }

            try
            {
                //ktmuonchua = 0;
                string themdongsqlMuon;
                //Them phieu muon 
                themdongsqlMuon = "set dateformat dmy; insert into PhieuTra values ('" + txtMaPhieutra.Text + "','" + comboMaDGtra.Text + "','" + dtmNgayTra1.Text + "','" + combosltra.Text + "')";
                ketnoi(themdongsqlMuon);
                //MessageBox.Show("Phiếu Trả thành công.", "Thông Báo");
                //ktmuonchua = 0;
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                ktmuonchua = 0;
            }
            catch (Exception)
            {
               
            }
            if (ktmuonchua == 0)
            {
                
                try
                {   //Dem so ctpt hien co
                    string query = "set dateformat dmy; select count(*) from ChiTietPT ";
                    ketnoithaotackhac(query);
                    int soctpt = (int)myCommand.ExecuteScalar();
                    //MessageBox.Show(soctpt.ToString());
                    int n = Convert.ToInt32(combosltra.Text);
                    for (int i = 0; i < n; i++)
                    {
                        string mactpm,masach;
                        string ngayhentrabang;
                        mactpm = dsqstra.Rows[i].Cells["MaCTPM"].Value.ToString();
                        masach = dsqstra.Rows[i].Cells["MaSach"].Value.ToString();
                        ngayhentrabang = dsqstra.Rows[i].Cells["NgayhenTra"].Value.ToString();
                        //MessageBox.Show(mactpm);
                        
                        string capnhatctpm = "update ChiTietPM set Datra='1' where MaCTPM='" + mactpm + "'";
                        ketnoi(capnhatctpm);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        

                        string maTuDong = "";
                        if (soctpt == 0)
                        {
                            maTuDong = "CTPT001";
                        }
                        else
                        {
                            int k;
                            maTuDong = "CTPT";
                            k = soctpt + 1;

                            if (k < 10)
                            {
                                maTuDong = maTuDong + "00";
                            }
                            else if (k < 100)
                            {
                                maTuDong = maTuDong + "0";
                            }
                            maTuDong = maTuDong + k.ToString();
                        }
                        //dang sua 
                        //Kiem tra co qua han hay khong
                        
                        string vipham = "0";
                        TimeSpan han = DateTime.Now - Convert.ToDateTime(ngayhentrabang);
                        if ( han.Days>0)
                        {
                            vipham = "1";
                            bangqhtra.Rows.Add(dsqsmuon.Rows[i]);
                        }
                        query = "set dateformat dmy; insert into ChiTietPT values('" + maTuDong + "','" + txtMaPhieutra.Text + "','"+ mactpm +"','" + comboBoMasachtra.Text + "','" + dtmNgayTra1.Text + "','" + vipham + "')";
                        ketnoithaotackhac(query);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        //else
                        //{
                        //    //query = "set dateformat dmy; update ChiTietPM set SoLanMuon += " + txtSLMuon0.Text + " where month(NgayThang) = " + dtmNgayMuon0.Value.Month + " and year(NgayThang) = " + dtmNgayMuon0.Value.Year + " and MaSach = '" + cboMaSach0.Text + "'";
                        //    //ketnoi(query);
                        //    //myCommand.ExecuteNonQuery();
                        //}
                        soctpt++;
                    }

                    //else
                    //{
                    //    //query = "set dateformat dmy; update ChiTietPM set SoLanMuon += " + txtSLMuon0.Text + " where month(NgayThang) = " + dtmNgayMuon0.Value.Month + " and year(NgayThang) = " + dtmNgayMuon0.Value.Year + " and MaSach = '" + cboMaSach0.Text + "'";
                    //    //ketnoi(query);
                    //    //myCommand.ExecuteNonQuery();
                    //}


                    btnTraSach1.Enabled = true;
                    btnHuytrasach.Enabled = false;
                    btnLuutrasach.Enabled = false;
                    
                    setControlsMuon(false);
                    dataGridViewDSMuon0.Enabled = true;

                    MessageBox.Show("Đã cập nhật lại phiếu mượn và tạo thành phiếu trả", "Thông Báo");
                }
                catch (Exception)
                {

                }
            }
            else
                MessageBox.Show("Mượn thất bại.", "Thông Báo");
        }
        public string maPhieu1, maDG1, maSach1, luuSLTra1, ngayTra1;
        private void dataGridViewDSMuon1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                txtMaPhieutra.Text=myTable.Rows[row]["MaPhieuTra"].ToString();
                maPhieu1 = txtMaPhieutra.Text;
                comboMaDGtra.Text = myTable.Rows[row]["MaDG"].ToString();
                maDG1 = comboMaDGtra.Text;
                //txtMaSach1.Text = myTable.Rows[row]["MaSach"].ToString();
                //maSach1 = txtMaSach1.Text;
                //combosltra.Text = myTable.Rows[row]["Soluongtra"].ToString();
                //luuSLTra1 = combosltra.Text;
                //dtmNgayMuon1.Text = myTable.Rows[row]["NgayMuon"].ToString();
                //ngayMuon1 = dtmNgayMuon1.Text;
                dtmNgayTra1.Text = myTable.Rows[row]["NgayTra"].ToString();
                ngayTra1 = dtmNgayTra1.Text;
                //txtTinhTrang1.Text = myTable.Rows[row]["TinhTrang"].ToString();
                //tinhTrang1 = txtTinhTrang1.Text;
                //txtGhiChu1.Text = myTable.Rows[row]["GhiChu"].ToString();
                //ghiChu1 = txtGhiChu1.Text;
            }
            catch(Exception)
            {

            }
        }
        public void layMaDGTra()
        {
            string strLayMaDG = "select * from tblDocGia";
            comboMaDGtra.DataSource = ketnoitblSach(strLayMaDG);
            comboMaDGtra.DisplayMember = "MaDG";
            comboMaDGtra.ValueMember = "MaDG";
            myConnection.Close();
        }
        public int slsachdangmuondg;
        public void layMasachTra(string madocgia)
        {
            string strLayMasach = "select * from tblPhieuMuon pm,ChiTietPM ct where pm.MaPhieu=ct.MaPhieu and Datra='0'and pm.MaDG='"+madocgia+"'";
            comboBoMasachtra.DataSource = ketnoitblSach(strLayMasach);
            comboBoMasachtra.DisplayMember = "MaSach";
            comboBoMasachtra.ValueMember = "MaSach";
            myConnection.Close();
        }
        public int luuSLSauTra;
        public string luuSLConTabMuon;

        private void traSach()
        {
            
        }
        private void btnTraSach1_Click(object sender, EventArgs e)
        {
            layMaDGTra();
            //layMasachTra();
            setControlsTra(true);
            btnTraSach1.Enabled = false;
            btnHuytrasach.Enabled = true;
            btnLuutrasach.Enabled = true;
            dataGridViewDStra.Enabled = false;
            txtMaPhieutra.Text = tangMatratudong();
            txtMaPhieutra.Enabled = false;
            //layMaSachMuon();
            comboMaDGtra.Text = "";
            combosltra.Text = "";
            comboBoMasachtra.Text = "";
            dataGridViewDStra.Enabled = false;
            //traSach();
        }
 
        private void btnThoat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNDTimKiem1_TextChanged(object sender, EventArgs e)
        {
            if (radMaDG1.Checked)
            {
                string timkiemDG1 = "select * from tblPhieuMuon where MaDG like '%" + txtNDTimKiem1.Text + "%'";
                ketnoi(timkiemDG1);
                myCommand.ExecuteNonQuery();
                dataGridViewDStra.DataSource = ketnoi(timkiemDG1);
                dataGridViewDStra.AutoGenerateColumns = false;
                myConnection.Close();
            }
            else if (radMaSach1.Checked)
            {
                string timkiemMS2 = "select * from tblPhieuMuon where MaPhieu like '%" + txtNDTimKiem1.Text + "%'";
                ketnoi(timkiemMS2);
                myCommand.ExecuteNonQuery();
                dataGridViewDStra.DataSource = ketnoi(timkiemMS2);
                dataGridViewDStra.AutoGenerateColumns = false;
                myConnection.Close();
            }
        }

        private void btnLoadDS1_Click(object sender, EventArgs e)
        {
            //layMaPhieuTra();
            string cauTruyVan = "select * from tblPhieuMuon";
            dataGridViewDStra.DataSource = ketnoi(cauTruyVan);
            dataGridViewDStra.AutoGenerateColumns = false;
            myConnection.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            string cauTruyVan = "select * from tblPhieuTra";
            dataGridViewDStra.DataSource = ketnoi(cauTruyVan);
            dataGridViewDStra.AutoGenerateColumns = false;
            myConnection.Close();
        }

       

        //private void cboMaPhieu1_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    setControlsTra(true);
            
        //    //dataGridViewDSMuon1.DataSource = ketnoi(cauTruyVan);
        //    //dataGridViewDSMuon1.AutoGenerateColumns = false;
        //    //myConnection.Close();
        //    //string cauTruyVan = "";
        //    string strlaydulieu = "select * from tblPhieuMuon where MaPhieu='" + cboMaPhieu1.SelectedValue.ToString() + "'";
        //    myConnection = new SqlConnection(strKetNoi);
        //    myConnection.Open();
        //    string thuchiencaulenh = strlaydulieu;
        //    myCommand = new SqlCommand(thuchiencaulenh, myConnection);
        //    myDataReaderMuonTra = myCommand.ExecuteReader();
        //    while (myDataReaderMuonTra.Read())
        //    {
        //        //luuMaSach = cboMaSach0.Text;
                
        //        txtMaDG1.Text = myDataReaderMuonTra.GetString(1);
        //        txtMaSach1.Text = myDataReaderMuonTra.GetString(2);
        //        txtSLMuon1.Text = myDataReaderMuonTra.GetInt32(5).ToString();
        //        dtmNgayMuon1.Text = myDataReaderMuonTra.GetString(3);
        //        dtmNgayTra1.Text = myDataReaderMuonTra.GetString(4);
        //        txtGhiChu1.Text = myDataReaderMuonTra.GetString(6);
        //    }






        //}   
    }
}
