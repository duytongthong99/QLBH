using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBH
{
    public partial class GUI_DonHang : Form
    {
        BUS_DonHang bus;
        public GUI_DonHang()
        {
            InitializeComponent();
            bus = new BUS_DonHang();
        }

        private void GUI_DonHang_Load(object sender, EventArgs e)
        {
            bus.LayDSDH(gVDH);
            bus.LayDSKH(cbKhachhang);
            bus.LayDSNV(cbNhanVien);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.25 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.25 * gVDH.Width);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
            cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
            cbKhachhang.Text = gVDH.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();

            
            

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            
        }

        

    }
}
