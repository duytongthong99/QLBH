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
    public partial class Form_OrderDetail : Form
    {
        BUS_DonHang busDH;
        public Form_OrderDetail()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }
        public int MaDH;
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void Form_OrderDetail_Load(object sender, EventArgs e)
        {
            
            txtMaDH.Text = MaDH.ToString();
            txtMaDH.Enabled = false;
            busDH.LayDSCTDH(gVCTDH, MaDH);
            gVCTDH.Columns[0].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.25 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.25 * gVCTDH.Width);

        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDH.Text = gVCTDH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaSP.Text = gVCTDH.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDonGia.Text = gVCTDH.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order_Detail donhangct = new Order_Detail();
            Order donhang = new Order();
            donhang.OrderID = int.Parse(txtMaDH.Text);
            donhangct.OrderID = int.Parse(txtMaDH.Text);
            donhangct.ProductID = int.Parse(txtMaSP.Text);
            donhangct.UnitPrice = decimal.Parse(txtDonGia.Text);
            donhangct.Quantity = Convert.ToInt16(txtSoLuong.Text);
            busDH.ThemSPCTDH(donhangct);
            busDH.themDH(donhang);
            busDH.LayDSCTDH(gVCTDH, int.Parse(txtMaDH.Text));

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order_Detail ctdh = new Order_Detail();
            ctdh.OrderID = int.Parse(gVCTDH.CurrentRow.Cells[0].Value.ToString());
            ctdh.ProductID = int.Parse(txtMaSP.Text);
            ctdh.UnitPrice = decimal.Parse(txtDonGia.Text);
            ctdh.Quantity = Convert.ToInt16(txtSoLuong.Text);
            busDH.SuaCTDH(ctdh);
            busDH.LayDSCTDH(gVCTDH, int.Parse(txtMaDH.Text));
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Order_Detail ctdh = new Order_Detail();
            ctdh.OrderID = int.Parse(gVCTDH.CurrentRow.Cells[0].Value.ToString());
            busDH.XoaCTDH(ctdh);
            busDH.LayDSCTDH(gVCTDH, int.Parse(txtMaDH.Text));
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if(IsNumeric(txtDonGia.Text)!=true)
            {
                MessageBox.Show("Vui lòng nhập số!");
                txtDonGia.Text = " ";
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if(IsNumeric(txtSoLuong.Text)!=true)
            {
                MessageBox.Show("Vui lòng nhập số!");
                txtSoLuong.Text = " ";
            }
        }
    }
}
