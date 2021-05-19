using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLBH
{
   
    class DAO_SanPham
    {
        NWDataContext db;
        public DAO_SanPham()
        {
            db = new NWDataContext();

        }
      
        public dynamic layDSSP()
        {
            dynamic list = db.Products.Select(s => new
            {
                s.ProductID,
                s.ProductName,
                s.Category.CategoryName,
                s.Supplier.CompanyName,
                s.UnitPrice,
                s.UnitsInStock

            });
            return list;
        }

        public dynamic layDSCate()
        {
            var ds = db.Categories.Select(s => new
            {
                s.CategoryID,
                s.CategoryName
            }).ToList();
            return ds;
        }

        public dynamic layDSNCC()
        {
            var ds = db.Suppliers.Select(s => new
            {
                s.SupplierID,
                s.CompanyName
            }).ToList();
            return ds;
        }

        public void themSP(Product p)
        {
            db.Products.InsertOnSubmit(p);
            db.SubmitChanges();
        }

        public bool suaSP(Product p)
        {
            bool status = false;
            Product sp = new Product();
            try
            {
                sp = db.Products.FirstOrDefault(s => s.ProductID == p.ProductID);
                status = true;
                sp.ProductName = p.ProductName;
                sp.CategoryID = p.CategoryID;
                sp.SupplierID = p.SupplierID;
                sp.UnitPrice = p.UnitPrice;
                sp.UnitsInStock = p.UnitsInStock;

                db.SubmitChanges();
                    
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }

        public void xoaSP(int masp)
        {
            var xoa = db.Products.FirstOrDefault(s => s.ProductID == masp);

            db.Products.DeleteOnSubmit(xoa);
            db.SubmitChanges();
        }
    }
   
    
}
