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
        
        public void layDSSP(DataGridView dg)
        {
            dg.DataSource = da.layDSSP();
        }

        public void layDScate(ComboBox cb)
        {
            cb.DataSource = da.layDSCate();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }

        public void layDSNCC(ComboBox cb)
        {
            cb.DataSource = da.layDSNCC();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }

        public void themSP(Product p)
        {
            da.themSP(p);
        }

        public void suaSP(Product p)
        {
            if(!da.suaSP(p))
            {
                MessageBox.Show("San pham không ton tai!");
            }
        }

        public void xoaSP(int masp)
        {
            da.xoaSP(masp);
        }
    }
}
