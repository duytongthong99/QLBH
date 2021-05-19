using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH
{
    class DAO_NhanVien
    {
        NWDataContext db;
        public DAO_NhanVien()
        {
            db = new NWDataContext();
        }

        public dynamic layDSNV()
        {
            dynamic ds = db.Employees.Select(s => new
            {
                s.EmployeeID,
                s.LastName,
                s.BirthDate,
                s.Address,
                s.HomePhone
            });
            return ds;
        }

        

        public void themNV(Employee e)
        {
            db.Employees.InsertOnSubmit(e);
            db.SubmitChanges();
        }

        public bool suaNV(Employee em)
        {
            bool tinhtrang = false;
            Employee e = new Employee();
            try
            {
                e = db.Employees.FirstOrDefault(s => s.EmployeeID == em.EmployeeID);
                tinhtrang = true;
                e.LastName = em.LastName;
                e.BirthDate = em.BirthDate;
                e.Address = em.Address;
                e.HomePhone = em.HomePhone;

                
                db.SubmitChanges();
            }
            catch (Exception)
            {
                tinhtrang = false;
                
            }
            return tinhtrang;
        }

        public void xoaNV(int maNV)
        {
            var xoa = db.Employees.FirstOrDefault(s => s.EmployeeID == maNV);

            db.Employees.DeleteOnSubmit(xoa);
            db.SubmitChanges();
        }
    }
}
