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
            bus.LayDSSP(dGSP);
            bus.LayDSLSP(cbLoaiSP);
            bus.LayDSNCC(cbNCC);

           
        }
       

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int CateID, SuppID, UinStock;
            decimal Uprice;
            string tenSP;
            tenSP = txtTenSP.Text;
            Uprice = decimal.Parse(txtDonGia.Text.ToString());
            UinStock = int.Parse(txtSoLuong.Text);
            CateID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            SuppID = int.Parse(cbNCC.SelectedValue.ToString());
            bus.ThemSP(tenSP, Uprice, UinStock, CateID, SuppID);
            bus.LayDSSP(dGSP);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int ProductID, SuppID, UinStock, cateID;
            decimal Uprice;
            string tenSP;
            ProductID =int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());
            tenSP = txtTenSP.Text;
            Uprice = decimal.Parse(txtDonGia.Text);
            UinStock = int.Parse(txtSoLuong.Text);
            cateID = int.Parse(cbLoaiSP.SelectedValue.ToString());
            SuppID = int.Parse(cbNCC.SelectedValue.ToString());
            bus.SuaSP(ProductID, tenSP, Uprice, UinStock, cateID, SuppID);
            bus.LayDSSP(dGSP);
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoLuong.Text = dGSP.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbLoaiSP.Text = dGSP.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbNCC.Text = dGSP.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int ProductID;
            ProductID = int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());
            bus.xoaSP(ProductID);
            bus.LayDSSP(dGSP);
        }
    }
}
