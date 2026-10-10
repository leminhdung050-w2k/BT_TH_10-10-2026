using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ServiceItem
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Price.ToString("N0")} VNĐ";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Sửa chữa phần cứng");
            comboBox1.Items.Add("Cài đặt phần mềm");
            comboBox1.Items.Add("Nâng cấp linh kiện");
            comboBox1.Items.Add("Vệ sinh bảo dưỡng");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAvailableServices.Items.Clear();
            if (comboBox1.SelectedItem == null) return;
            string category = comboBox1.SelectedItem.ToString();

            if (category == "Sửa chữa phần cứng")
            {
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Thay bàn phím Laptop", Price = 350000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Thay Pin Laptop", Price = 550000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Sửa bản lề màn hình", Price = 250000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Sửa sạc Laptop", Price = 150000 });
            }
            else if (category == "Cài đặt phần mềm")
            {
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Cài Windows + Office", Price = 150000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Cài phần mềm đồ họa", Price = 100000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Cấp cứu dữ liệu", Price = 800000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Diệt virus & Tối ưu", Price = 100000 });
            }
            else if (category == "Nâng cấp linh kiện")
            {
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Nâng cấp RAM 8GB DDR4", Price = 600000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Nâng cấp RAM 16GB DDR4", Price = 1100000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Nâng cấp SSD 256GB", Price = 750000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Nâng cấp SSD 512GB", Price = 1200000 });
            }
            else if (category == "Vệ sinh bảo dưỡng")
            {
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Vệ sinh Laptop cơ bản", Price = 150000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Vệ sinh PC Gaming", Price = 200000 });
                lstAvailableServices.Items.Add(new ServiceItem { Name = "Tra keo tản nhiệt", Price = 100000 });
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstAvailableServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Add(lstAvailableServices.SelectedItem);
                TinhTien();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.SelectedItem != null)
            {
                lstSelectedServices.Items.Remove(lstSelectedServices.SelectedItem);
                TinhTien();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstSelectedServices.Items.Clear();
            TinhTien();
        }

        private void TinhTien()
        {
            double tongTien = 0;

            foreach (ServiceItem item in lstSelectedServices.Items)
            {
                tongTien += item.Price;
            }

            double chietKhau = (double)nudChietKhau.Value;

            double thanhTien = tongTien - (tongTien * chietKhau / 100.0);

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblThanhTien.Text = thanhTien.ToString("N0") + " VNĐ";
        }

        private void nudChietKhau_ValueChanged(object sender, EventArgs e)
        {
            TinhTien(); 
        }

        private void lstAvailableServices_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

 
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblTongTien_Click(object sender, EventArgs e) { }
        private void lblThanhTien_Click(object sender, EventArgs e) { }
        private void lstAvailableServices_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lstSelectedServices_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtChietKhau_TextChanged(object sender, EventArgs e) { }
        private void txtChietKhau_Click(object sender, EventArgs e) { }
    }
}