using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkDieuKhoan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Bước 1: Xóa toàn bộ các lỗi cũ đã hiển thị trước đó
            epCheck.Clear();

            // Biến này để theo dõi xem form có hợp lệ toàn bộ không
            bool isValid = true;

            // 1. Kiểm tra Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                epCheck.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống!");
                isValid = false;
            }

            // 2. Kiểm tra Mật khẩu
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                epCheck.SetError(txtMatKhau, "Mật khẩu không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Xác nhận mật khẩu
            if (txtXacNhanMatKhau.Text != txtMatKhau.Text)
            {
                epCheck.SetError(txtXacNhanMatKhau, "Mật khẩu nhập lại không khớp!");
                isValid = false;
            }
            else if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text)) // Nếu để trống ô xác nhận
            {
                epCheck.SetError(txtXacNhanMatKhau, "Vui lòng xác nhận lại mật khẩu!");
                isValid = false;
            }

            // 4. Kiểm tra Độ tuổi (Phải >= 18)
            // Tính số tuổi = Năm hiện tại - Năm sinh
            int tuoi = DateTime.Now.Year - dtpNgaySinh.Value.Year;

            // Trừ đi 1 tuổi nếu chưa đến đúng ngày sinh nhật của năm nay
            if (dtpNgaySinh.Value.AddYears(tuoi) > DateTime.Now)
            {
                tuoi--;
            }

            if (tuoi < 18)
            {
                epCheck.SetError(dtpNgaySinh, "Bạn phải đủ 18 tuổi trở lên mới được đăng ký!");
                isValid = false;
            }

            // 5. Kiểm tra Điều khoản dịch vụ
            if (chkDieuKhoan.Checked == false)
            {
                epCheck.SetError(chkDieuKhoan, "Bạn phải đồng ý với Điều khoản dịch vụ!");
                isValid = false;
            }

            // Bước cuối: Nếu tất cả đều hợp lệ (isValid vẫn bằng true) -> Thông báo thành công
            if (isValid == true)
            {
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Có thể gọi hàm btnLamMoi_Click ở đây để tự reset form sau khi đăng ký xong
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu các TextBox
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhanMatKhau.Clear();

            // Reset ngày sinh và giới tính, điều khoản
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            chkDieuKhoan.Checked = false;

            // Xóa các biểu tượng lỗi của ErrorProvider
            epCheck.Clear();

            // Đưa con trỏ chuột về ô Tên đăng nhập
            txtTenDangNhap.Focus();
        }
    }
}
