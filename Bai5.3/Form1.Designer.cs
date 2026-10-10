namespace Bai5_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpInfo = new GroupBox();
            cboCategory = new ComboBox();
            txtQuantity = new TextBox();
            txtUnitPrice = new TextBox();
            txtProductName = new TextBox();
            txtProductId = new TextBox();
            lblCategory = new Label();
            lblQuantity = new Label();
            lblUnitPrice = new Label();
            lblProductName = new Label();
            lblProductId = new Label();
            grpFunctions = new GroupBox();
            btnShowAll = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            dgvProducts = new DataGridView();
            grpInfo.SuspendLayout();
            grpFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(cboCategory);
            grpInfo.Controls.Add(txtQuantity);
            grpInfo.Controls.Add(txtUnitPrice);
            grpInfo.Controls.Add(txtProductName);
            grpInfo.Controls.Add(txtProductId);
            grpInfo.Controls.Add(lblCategory);
            grpInfo.Controls.Add(lblQuantity);
            grpInfo.Controls.Add(lblUnitPrice);
            grpInfo.Controls.Add(lblProductName);
            grpInfo.Controls.Add(lblProductId);
            grpInfo.Location = new Point(12, 12);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(440, 215);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin sản phẩm";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Phụ kiện", "Đồng hồ" });
            cboCategory.Location = new Point(120, 172);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(300, 28);
            cboCategory.TabIndex = 9;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(120, 137);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(300, 27);
            txtQuantity.TabIndex = 7;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(120, 102);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(300, 27);
            txtUnitPrice.TabIndex = 5;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(120, 67);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(300, 27);
            txtProductName.TabIndex = 3;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(120, 32);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(300, 27);
            txtProductId.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 175);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 20);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Danh mục:";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 140);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(72, 20);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Số lượng:";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(20, 105);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(65, 20);
            lblUnitPrice.TabIndex = 4;
            lblUnitPrice.Text = "Đơn giá:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(20, 70);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(55, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Tên SP:";
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(20, 35);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(53, 20);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Mã SP:";
            // 
            // grpFunctions
            // 
            grpFunctions.Controls.Add(btnShowAll);
            grpFunctions.Controls.Add(btnSearch);
            grpFunctions.Controls.Add(txtSearch);
            grpFunctions.Controls.Add(lblSearch);
            grpFunctions.Controls.Add(btnClear);
            grpFunctions.Controls.Add(btnDelete);
            grpFunctions.Controls.Add(btnEdit);
            grpFunctions.Controls.Add(btnAdd);
            grpFunctions.Location = new Point(468, 12);
            grpFunctions.Name = "grpFunctions";
            grpFunctions.Size = new Size(400, 215);
            grpFunctions.TabIndex = 1;
            grpFunctions.TabStop = false;
            grpFunctions.Text = "Chức năng";
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(206, 162);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(178, 40);
            btnShowAll.TabIndex = 7;
            btnShowAll.Text = "Hiển thị tất cả";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(20, 162);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(178, 40);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 125);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(364, 27);
            txtSearch.TabIndex = 5;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 100);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(154, 20);
            lblSearch.TabIndex = 4;
            lblSearch.Text = "Tìm kiếm theo Tên SP:";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(299, 32);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(85, 40);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(206, 32);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(113, 32);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(85, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 32);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 240);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(856, 300);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 552);
            Controls.Add(dgvProducts);
            Controls.Add(grpFunctions);
            Controls.Add(grpInfo);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý danh sách sản phẩm";
            Load += Form1_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpFunctions.ResumeLayout(false);
            grpFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private Label lblProductId;
        private Label lblProductName;
        private Label lblUnitPrice;
        private Label lblQuantity;
        private Label lblCategory;
        private TextBox txtProductId;
        private TextBox txtProductName;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private ComboBox cboCategory;
        private GroupBox grpFunctions;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnShowAll;
        private DataGridView dgvProducts;
    }
}
