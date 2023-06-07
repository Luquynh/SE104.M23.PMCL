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
    public partial class xemCTPM : Form
    {
        public string maphieu;
        public xemCTPM(string maphieu1)
        {
            InitializeComponent();
            maphieu = maphieu1;
            string cauTruyVan = "select * from ChiTietPM where MaPhieu='"+maphieu+"' ";
            ctpm.DataSource = ketnoi(cauTruyVan);
            ctpm.AutoGenerateColumns = false;
        }
        string strKetNoi = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
        private SqlConnection myConnection;
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private DataTable myTable;
        
        private DataTable ketnoi(string truyvan)
        {
            myConnection = new SqlConnection(strKetNoi);
            myConnection.Open();
            string thuchiencaulenh = truyvan;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myDataAdapter = new SqlDataAdapter(myCommand);
            myTable = new DataTable();
            myDataAdapter.Fill(myTable);
            ctpm.DataSource = myTable;
       
            return myTable;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
