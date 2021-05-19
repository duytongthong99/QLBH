using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBH
{
    class BUS_DonHang
    {
        DAO_DonHang da;
        public BUS_DonHang() {
            da = new DAO_DonHang();
        }
        public void LayDSDH(DataGridView dg)
        {
            dg.DataSource = da.LayDSDH();
        }
        public void LayDSKH(ComboBox cb) {
            cb.DataSource = da.layDSKH();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember="CustomerID";
        }
        public void LayDSNV(ComboBox cbnv) {
            cbnv.DataSource = da.layDSNV();
            cbnv.DisplayMember = "LastName";
            cbnv.ValueMember = "EmployeeID";
        }
        public void themDH(Order donHang)
        {
            da.themDH(donHang);
        }
        public void SuaDH(Order donHang)
        {
            if(!da.SuaDH(donHang))
            {
                MessageBox.Show("Lỗi không tìm thấy sản phẩm");
            }
            
        }
        public void xoaDH(int maDH)
        {
            da.xoaDH(maDH);
        }

        public void LayDSCTDH(DataGridView dg, int MaDH)
        {
            dg.DataSource = da.LayDSCTDH(MaDH);
        }

        public void ThemSPCTDH(Order_Detail donhang)
        {
            da.ThemSPCTDH(donhang);
        }

        public void SuaCTDH(Order_Detail ctdh)
        {
            if(!da.SuaCTDH(ctdh))
            {
                MessageBox.Show("Không tìm thấy sản phẩm");
            }
        }

        public void XoaCTDH(Order_Detail ctdh)
        {
            da.XoaCTDH(ctdh);
        }
    }
}
