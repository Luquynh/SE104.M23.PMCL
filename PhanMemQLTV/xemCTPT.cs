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
    public partial class xemCTPT : Form
    {
        string maphieuphat;

        public xemCTPT(string maphieuphat1)
        {
            InitializeComponent();
            maphieuphat = maphieuphat1;
            string cauTruyVan = "select * from ChiTietPhieuPhat where MaPhieuPhat='" + maphieuphat + "' ";
            ctpt.DataSource = ketnoi(cauTruyVan);
            ctpt.AutoGenerateColumns = false;

        }
        string strKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private DataTable myTable;
        private DataTable myTableDG;
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            ctpt.DataSource = myTable;

            return myTable;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
