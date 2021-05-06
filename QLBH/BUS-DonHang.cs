using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBH
{
    class BUS_DonHang
    {
        DAO_DonHang db;
        public BUS_DonHang() {
            db = new DAO_DonHang();
        }
        public void LayDSDH(DataGridView dg)
        {
            dg.DataSource = db.LayDSDH();
        }
        public void LayDSKH(ComboBox cb) {
            cb.DataSource = db.layDSKH();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember="CustomerID";
        }
        public void LayDSNV(ComboBox cbnv) {
            cbnv.DataSource = db.layDSNV();
            cbnv.DisplayMember = "LastName";
            cbnv.ValueMember = "EmployeeID";
        }

    }
}
