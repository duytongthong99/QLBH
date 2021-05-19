using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace QLBH
{
    class BUS_NhanVien
    {
        DAO_NhanVien da;
        public BUS_NhanVien()
        {
            da = new DAO_NhanVien();
        }

        public void layDSNV(DataGridView dg)
        {
            dg.DataSource = da.layDSNV();
        }

        public void themNV(Employee e)
        {
            da.themNV(e);
        }

        public void SuaNV(Employee e)
        {
            if (!da.suaNV(e))
            {
                MessageBox.Show("Loi khong tim thay nhan vien");
            }
        }

        public void xoaNV(int maNV)
        {
            da.xoaNV(maNV);
        }
    }
}
