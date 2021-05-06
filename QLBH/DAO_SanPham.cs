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
        SqlConnection conn;
        public DAO_SanPham()
        {
            string query = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            conn = new SqlConnection(query);    
        }
        public DataTable layDSSP()
        {
            
            string query1 = "SELECT ProductID, ProductName, UnitPrice, UnitsInStock, CompanyName, CategoryName FROM dbo.Categories,dbo.Products,dbo.Suppliers WHERE dbo.Products.CategoryID = dbo.Categories.CategoryID AND dbo.Products.SupplierID = dbo.Suppliers.SupplierID";
            SqlDataAdapter d = new SqlDataAdapter(query1, conn);
            DataSet ds = new DataSet();

            d.Fill(ds);
            
            return ds.Tables[0];
        }
        public DataTable layDSLSP()
        {
            
            string querylsp = "Select CategoryID, CategoryName From Categories";
            SqlDataAdapter da = new SqlDataAdapter(querylsp, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable layDSNCC()
        {
            
            string querylncc = "Select SupplierID, CompanyName From Suppliers";
            SqlDataAdapter da = new SqlDataAdapter(querylncc, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ThemSanPham(string tenSP, decimal Uprice, int UinStock, int CateID, int SuppID)
        {
            
            string query1 = string.Format("Insert into Products(ProductName, UnitsinStock, UnitPrice, CategoryID, SupplierID) Values(N'{0}','{1}','{2}','{3}','{4}')", tenSP,UinStock, Uprice, CateID, SuppID);
            SqlCommand cmd = new SqlCommand(query1, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void SuaSP(int ProductID,string tenSP, decimal Uprice, int UinStock, int CateID, int SuppID)
        {
            
            string query1 = string.Format("Update Products SET ProductName = '{0}', UnitsInStock='{1}', UnitPrice = '{2}', CategoryID='{3}', SupplierID='{4}' WHERE ProductID = '{5}'", tenSP, UinStock, Uprice, CateID, SuppID, ProductID);
            SqlCommand cmd = new SqlCommand(query1, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
        public void XoaSP(int ProductID)
        {
            
            string querry1 = string.Format("DELETE FROM Products WHERE ProductID = '{0}'", ProductID);
            SqlCommand cmd = new SqlCommand(querry1, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
   
    
}
