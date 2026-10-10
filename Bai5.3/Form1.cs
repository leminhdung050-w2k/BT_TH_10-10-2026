namespace Bai5_3
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            products.Add(new Product("SP01", "iPhone 15", 22000000, 10, "Điện thoại"));
            products.Add(new Product("SP02", "Dell XPS 13", 30000000, 5, "Laptop"));
            products.Add(new Product("SP03", "iPad Air", 15000000, 8, "Máy tính bảng"));
            products.Add(new Product("SP04", "Tai nghe AirPods", 4500000, 20, "Phụ kiện"));

            bindingSource.DataSource = products;
            dgvProducts.DataSource = bindingSource;

            dgvProducts.Columns["ProductId"].HeaderText = "Mã SP";
            dgvProducts.Columns["ProductName"].HeaderText = "Tên SP";
            dgvProducts.Columns["UnitPrice"].HeaderText = "Đơn giá";
            dgvProducts.Columns["Quantity"].HeaderText = "Số lượng";
            dgvProducts.Columns["Category"].HeaderText = "Danh mục";
            dgvProducts.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";

            cboCategory.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            bindingSource.DataSource = null;
            bindingSource.DataSource = products;
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = 0;
            txtProductId.Focus();
        }

        private Product ReadInput()
        {
            string id = txtProductId.Text.Trim();
            string name = txtProductName.Text.Trim();
            string category = cboCategory.Text.Trim();

            if (id == "" || name == "")
            {
                MessageBox.Show("Vui lòng nhập Mã SP và Tên SP!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá phải là số không âm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitPrice.Focus();
                return null;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return null;
            }

            return new Product(id, name, price, quantity, category);
        }

        private Product GetSelectedProduct()
        {
            if (dgvProducts.CurrentRow == null)
                return null;
            return dgvProducts.CurrentRow.DataBoundItem as Product;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = ReadInput();
            if (p == null) return;

            if (products.Any(x => x.ProductId.Equals(p.ProductId, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã SP đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductId.Focus();
                return;
            }

            products.Add(p);
            RefreshGrid();
            ClearInputs();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Product selected = GetSelectedProduct();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Product p = ReadInput();
            if (p == null) return;

            if (products.Any(x => x != selected &&
                x.ProductId.Equals(p.ProductId, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã SP đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selected.ProductId = p.ProductId;
            selected.ProductName = p.ProductName;
            selected.UnitPrice = p.UnitPrice;
            selected.Quantity = p.Quantity;
            selected.Category = p.Category;

            RefreshGrid();
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product selected = GetSelectedProduct();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm \"{selected.ProductName}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                products.Remove(selected);
                RefreshGrid();
                ClearInputs();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "")
            {
                RefreshGrid();
                return;
            }

            List<Product> result = products
                .Where(x => x.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            bindingSource.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            RefreshGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Product p = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (p == null) return;

            txtProductId.Text = p.ProductId;
            txtProductName.Text = p.ProductName;
            txtUnitPrice.Text = p.UnitPrice.ToString();
            txtQuantity.Text = p.Quantity.ToString();
            cboCategory.Text = p.Category;
        }
    }
}
