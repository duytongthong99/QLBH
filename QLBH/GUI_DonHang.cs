using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBH
{
    public partial class GUI_DonHang : Form
    {
        BUS_DonHang bus;
        public GUI_DonHang()
        {
            InitializeComponent();
            bus = new BUS_DonHang();
        }

        private void GUI_DonHang_Load(object sender, EventArgs e)
        {
            bus.LayDSDH(gVDH);
            bus.LayDSKH(cbKhachhang);
            bus.LayDSNV(cbNhanVien);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.25 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.25 * gVDH.Width);
            txtMaDH.Enabled = false;
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.RowIndex<gVDH.Rows.Count)
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                cbKhachhang.Text = gVDH.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
            }
            
           
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            int maDH = int.Parse(txtMaDH.Text);

            bus.xoaDH(maDH);
            bus.LayDSDH(gVDH);
                
               
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order donHang = new Order();
            donHang.CustomerID = cbKhachhang.SelectedValue.ToString();
            donHang.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());
            donHang.OrderDate = dtpNgayDH.Value;
            
            bus.themDH(donHang);

            bus.LayDSDH(gVDH);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            txtMaDH.Enabled = false;
            Order d = new Order();
            d.OrderID = int.Parse(txtMaDH.Text);
            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachhang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            bus.SuaDH(d);

            bus.LayDSDH(gVDH);
        }

        

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            Form_OrderDetail d = new Form_OrderDetail();
            d.MaDH = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            d.ShowDialog();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSanPham f = new FSanPham();
            f.ShowDialog();
        }

        private void quảnLýĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhanVien f = new FNhanVien();
            f.ShowDialog();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
