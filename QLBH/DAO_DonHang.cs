using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH
{
    class DAO_DonHang
    {
        NWDataContext db;
        public DAO_DonHang()
        {
            db = new NWDataContext();
        }

        public dynamic LayDSDH() {
            dynamic ds = db.Orders.Select(s => new
            {
                s.OrderID,
                s.OrderDate,
                s.Employee.LastName,
                s.Customer.CompanyName
            });
            return ds;
        }

        public dynamic layDSKH() {
            var kh = db.Customers.Select(s => new
            {
                s.CompanyName,
                s.CustomerID
            });
            return kh;
        }

        public dynamic layDSNV() {
            var nv = db.Employees.Select(s => new
            {
                s.LastName,
                s.EmployeeID
            });
            return nv;
        }
    }
}
