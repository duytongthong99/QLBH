using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;



namespace QLBH
{
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        string chuoiKetnoi;

        

        void Ketnoi()
        {
            chuoiKetnoi = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            conn = new SqlConnection(chuoiKetnoi);   

        }

        DataTable LayDSNV()
        {
            string query = "SELECT EmployeeID, LastName +' '+FirstName as Name, BirthDate, Address, HomePhone FROM Employees ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet db = new DataSet();
            da.Fill(db);
            return db.Tables[0];
       }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            Ketnoi();
            dGNhanVien.DataSource = LayDSNV();
        }
        void ThemNV()
        {
           
            string[] hoten = txtHoten.Text.Split(' ');
            string query = string.Format("INSERT INTO Employees(LastName, FirstName, HomePhone,Address, BirthDate) Values(N'{0}','{1}','{2}','{3}','{4}')", hoten[0], hoten[1], txtDienThoai.Text, txtDiaChi.Text, dtpNgaySinh.Value.ToShortDateString());
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            dGNhanVien.Columns.Clear();
            dGNhanVien.DataSource = LayDSNV();

        }
        void SuaNV(int id, string lastname, string homephone, string addr, DateTime birthday)
        {

            string excute = string.Format("Update Employees Set LastName = '{0}', HomePhone ='{1}', Address='{2}', BirthDate = '{3}' WHERE EmployeeID = '{4}'", lastname, homephone, addr, birthday, id);
            SqlCommand cmd = new SqlCommand(excute, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            dGNhanVien.DataSource = LayDSNV();
        }
        void XoaNV(int id)
        {
            string query = string.Format("Delete From Employees where EmployeeID='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            dGNhanVien.DataSource = LayDSNV();
                
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            ThemNV();
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHoten.Text = dGNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dGNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDienThoai.Text=dGNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int id;
            id = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            SuaNV(id,txtHoten.Text, txtDienThoai.Text, txtDiaChi.Text, dtpNgaySinh.Value);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int id;
            id = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            XoaNV(id);
        }
    }
}
