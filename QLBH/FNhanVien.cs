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
        BUS_NhanVien bus;
        public FNhanVien()
        {
            InitializeComponent();
            bus = new BUS_NhanVien();
        }

        

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            bus.layDSNV(dGNhanVien);     
           
            dGNhanVien.Columns[0].Width = (int)(dGNhanVien.Width * 0.1);
            dGNhanVien.Columns[1].Width = (int)(dGNhanVien.Width * 0.2);
            dGNhanVien.Columns[2].Width = (int)(dGNhanVien.Width * 0.2);
            dGNhanVien.Columns[3].Width = (int)(dGNhanVien.Width * 0.2);
            dGNhanVien.Columns[4].Width = (int)(dGNhanVien.Width * 0.2);
            
           
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGNhanVien.Rows.Count)
            {
                txtHoTen.Text = dGNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHoTen.Text = dGNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Text = dGNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                string mavasdt = dGNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                string[] ma_sdt = mavasdt.Split(' ');
                cbMavung.Text = ma_sdt[0];
                txtDienThoai.Text = ma_sdt[1];
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            
            if(txtHoTen.Text.Contains(' '))
            {
                if(txtHoTen.Text!=null && txtDiaChi.Text!=null && txtDienThoai!=null)
                {
                    string hoten = txtHoTen.Text;
                    string[] ho_ten = hoten.Split(' ');
                    em.FirstName = ho_ten[0];
                    em.LastName = ho_ten[1];
                    em.BirthDate = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString());
                    em.Address = txtDiaChi.Text;
                    string maVung = cbMavung.Text;
                    string[] splitmaVung = maVung.Split(' ');
                    em.HomePhone = string.Format(splitmaVung[0] + " " + int.Parse(txtDienThoai.Text));

                    bus.themNV(em);
                    bus.layDSNV(dGNhanVien);
                }
                else
                {
                    MessageBox.Show("Không được bỏ trống!!!");
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên");
            }
            

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.EmployeeID = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());
            em.LastName = txtHoTen.Text;
            em.BirthDate = dtpNgaySinh.Value;
            em.Address = txtDiaChi.Text;
            em.HomePhone = txtDienThoai.Text;

            bus.SuaNV(em);
            bus.layDSNV(dGNhanVien);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(dGNhanVien.CurrentRow.Cells[0].Value.ToString());

            bus.xoaNV(maNV);
            bus.layDSNV(dGNhanVien);
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {
            if(IsNumeric(txtDienThoai.Text)==true)
            {
                if (!(txtDienThoai.Text.Length < 11))
                {
                    MessageBox.Show("So dien thoai khong duoc lon hon 10");
                    txtDienThoai.Text = " ";
                }
            }
            else
            {
                MessageBox.Show("Ban phai nhap so!!");
                txtDienThoai.Text = " ";
            }
            

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
