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
    public partial class frmPhieuthutienphat : Form
    {
        public frmPhieuthutienphat()
        {
            InitializeComponent();
        }
        string strKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private DataTable myTable, myTableSach;
        
        

        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            return myTable;
        }
        private void ketnoithaotackhac(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);

        }
        public string tangMaphattudong()
        {
            string query = "set dateformat dmy; select count(*) from PhieuPhat";
            ketnoithaotackhac(query);
            int soctpt = (int)myCommand.ExecuteScalar();

            myConnection.Close();

            string maTuDong = "";
            if (myTable.Rows.Count <= 0)
            {
                maTuDong = "MPP001";
            }
            else
            {
                int k;
                maTuDong = "MPP";
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
        private void trove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboMaDGtra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lapphieuphat_Click(object sender, EventArgs e)
        {
            txtMaPhieuphat.Text = tangMaphattudong();

        }

        private void inhoadon_Click(object sender, EventArgs e)
        {

        }

        public void layMaphieutra(string madocgia)
        {
            string strLayMasach = "select * from PhieuPhat where MaDG='" + comboMaDGtra.SelectedValue.ToString() + "'";
            combomaphieu.DataSource = ketnoitblSach(strLayMasach);
            combomaphieu.DisplayMember = "MaPhieuPhat";
            combomaphieu.ValueMember = "MaPhieuPhat";
            myConnection.Close();
        }
    }
}
