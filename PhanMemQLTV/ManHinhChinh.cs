using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQLTV
{
    public partial class ManHinhChinh : Form
    {
        public ManHinhChinh()
        {
            InitializeComponent();
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            //frmDangKy dangkydocgia = new frmDangKy();
            //dangkydocgia.Show();
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            frmQLSach QLSach = new frmQLSach();
            QLSach.Show();
            
            
            

        }

        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            frmQLDocGia QLDocGia = new frmQLDocGia();
            QLDocGia.Show();

        }

        private void btnPhieuThuTienPhat_Click(object sender, EventArgs e)
        {
            frmPhieuthutienphat Phieuthutienphat = new frmPhieuthutienphat();
            Phieuthutienphat.Show();

        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe BaoCaoThongKe = new frmBaoCaoThongKe();
            BaoCaoThongKe.Show();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btbQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            frmQLMuonTra QLMuonTra = new frmQLMuonTra();
            QLMuonTra.Show();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMKDG doimatkhaudocgia = new frmDoiMKDG();
            doimatkhaudocgia.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Clock.Text = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
            timer1.Start();
        }

        private void ManHinhChinh_Load(object sender, EventArgs e)
        {
            
                timer1.Start();
                Clock.Text = DateTime.Now.ToString("dddd , dd MMM  yyyy, hh:mm:ss");
            

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clock_Click(object sender, EventArgs e)
        {

        }
    }
}
