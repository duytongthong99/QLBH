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
    public partial class FSanPham : Form
    {
        BUS_SanPham bus;
        public FSanPham()
        {

            InitializeComponent();
            bus = new BUS_SanPham();
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            bus.layDSSP(dGSP);

            dGSP.Columns[0].Width = (int)(dGSP.Width * 0.1);
            dGSP.Columns[1].Width = (int)(dGSP.Width * 0.2);
            dGSP.Columns[2].Width = (int)(dGSP.Width * 0.2);
            dGSP.Columns[3].Width = (int)(dGSP.Width * 0.2);
            dGSP.Columns[4].Width = (int)(dGSP.Width * 0.1);
            dGSP.Columns[5].Width = (int)(dGSP.Width * 0.11);

            bus.layDScate(cbLoaiSP);
            bus.layDSNCC(cbNCC);
        }




        private void btThem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductName = txtTenSP.Text;
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
            p.UnitPrice = decimal.Parse(txtDonGia.Text);
            p.UnitsInStock = Convert.ToInt16(txtSoLuong.Text);

            bus.themSP(p);
            bus.layDSSP(dGSP);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductID = int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());
            p.ProductName = txtTenSP.Text;
            p.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            p.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());
            p.UnitPrice = decimal.Parse(txtDonGia.Text);
            p.UnitsInStock = Convert.ToInt16(txtSoLuong.Text);

            bus.suaSP(p);
            
            bus.layDSSP(dGSP);
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.RowIndex < dGSP.Rows.Count)
            {
                txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbLoaiSP.Text = dGSP.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbNCC.Text = dGSP.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSoLuong.Text = dGSP.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        } 

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maSP = int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());

            bus.xoaSP(maSP);
            bus.layDSSP(dGSP);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
