using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBH
{
    
    class BUS_SanPham
    {
        DAO_SanPham da;
        public BUS_SanPham()
        {
            da = new DAO_SanPham();
        }
        public void LayDSSP(DataGridView dg)
        {
            dg.DataSource = da.layDSSP();
        }
        public void LayDSLSP(ComboBox cb)
        {
            cb.DataSource = da.layDSLSP();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }
        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = da.layDSNCC();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }
        public void ThemSP(string tenSP, decimal Uprice, int UinStock, int CateID, int SuppID)
        {
            da.ThemSanPham(tenSP, Uprice, UinStock, CateID, SuppID);
        }
        public void SuaSP(int ProductID, string ten, decimal Uprice, int UinStock, int cateID, int suppid)
        {
            da.SuaSP(ProductID, ten, Uprice, UinStock, cateID, suppid);
        }
        public void xoaSP(int ProductID)
        {
            da.XoaSP(ProductID);

        }
    }
}
