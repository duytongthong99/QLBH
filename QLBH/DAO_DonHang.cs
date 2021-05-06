using QLBH;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public void themDH(Order donHang)
        {
            db.Orders.InsertOnSubmit(donHang);
            db.SubmitChanges();
        }

        public bool SuaDH(Order donHang)
        {
            bool tinhTrang = false;
            Order d = new Order();
            try
            {
                d = db.Orders.First(s => s.OrderID == donHang.OrderID);
                tinhTrang = true;
                d.OrderDate = donHang.OrderDate;
                d.CustomerID = donHang.CustomerID;
                d.EmployeeID = donHang.EmployeeID;

                db.SubmitChanges();
            }
            catch (Exception)
            {

                tinhTrang = false;
            }
            return tinhTrang;
        }

        public void xoaDH(int rowID)
        {

            Order d = new Order();
            d = db.Orders.First(s => s.OrderID == rowID);
            db.Orders.DeleteOnSubmit(d);
            db.SubmitChanges();
        }

        public dynamic LayDSCTDH(int MaDH)
        {
            var ds = db.Order_Details.Where(s => s.OrderID == MaDH)
                                     .Select(s => new
                                     {
                                         s.OrderID,
                                         s.ProductID,
                                         s.UnitPrice,
                                         s.Quantity
                                     });
            return ds; 
        }

        public void ThemSPCTDH(Order_Detail donhang)
        {
            db.Order_Details.InsertOnSubmit(donhang);
            db.SubmitChanges();
        }

        public bool SuaCTDH(Order_Detail ctdh)
        {
            bool tinhtrang = false;
            try
            {
                var ds = db.Order_Details.First(s => s.OrderID == ctdh.OrderID && s.ProductID == ctdh.ProductID);
                tinhtrang = true;
                //ds.OrderID = ctdh.OrderID;
                //ds.ProductID = ctdh.ProductID;
                ds.UnitPrice = ctdh.UnitPrice;
                ds.Quantity = ctdh.Quantity;
                
                db.SubmitChanges();
            }
            catch (Exception)
            {
                tinhtrang = false;
                
            }
            return tinhtrang;
        }

        public void XoaDH(Order_Detail ctdh)
        {
            var ds = db.Order_Details.First(s => s.OrderID == ctdh.OrderID);
            db.Order_Details.DeleteOnSubmit(ds);
            db.SubmitChanges();
                                     
        }
 }
}

