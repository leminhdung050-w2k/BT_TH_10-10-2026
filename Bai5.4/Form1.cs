using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Bai5_4
{
    public partial class Form1 : Form
    {
        private List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadImages();
            LoadEmployees();
            BuildTree();

            cboViewMode.SelectedIndex = 0; // Details

            // Mặc định chọn Node gốc (Công ty) để hiển thị toàn bộ nhân viên
            tvDepartments.SelectedNode = tvDepartments.Nodes[0];
        }

        #region ImageList - biểu tượng cho TreeView và ListView

        private void LoadImages()
        {
            string[] keys = { "company", "department", "group", "employee" };
            foreach (string key in keys)
            {
                imgSmall.Images.Add(key, CreateIcon(key, 16));
                imgLarge.Images.Add(key, CreateIcon(key, 32));
            }
        }

        private Bitmap CreateIcon(string kind, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.ScaleTransform(size / 16f, size / 16f);

                switch (kind)
                {
                    case "company": // Tòa nhà
                        g.FillRectangle(Brushes.SteelBlue, 3, 1, 10, 14);
                        for (int row = 0; row < 3; row++)
                        {
                            g.FillRectangle(Brushes.White, 5, 3 + row * 3, 2, 2);
                            g.FillRectangle(Brushes.White, 9, 3 + row * 3, 2, 2);
                        }
                        g.FillRectangle(Brushes.Gold, 7, 12, 2, 3);
                        break;

                    case "department": // Thư mục
                        g.FillRectangle(Brushes.DarkGoldenrod, 1, 3, 6, 3);
                        g.FillRectangle(Brushes.Goldenrod, 1, 5, 14, 9);
                        break;

                    case "group": // Hai người
                        g.FillEllipse(Brushes.MediumSeaGreen, 8, 1, 5, 5);
                        g.FillPie(Brushes.MediumSeaGreen, 6, 7, 9, 12, 180, 180);
                        g.FillEllipse(Brushes.SeaGreen, 3, 4, 5, 5);
                        g.FillPie(Brushes.SeaGreen, 1, 10, 9, 12, 180, 180);
                        break;

                    default: // Một người (nhân viên)
                        g.FillEllipse(Brushes.RoyalBlue, 5, 1, 6, 6);
                        g.FillPie(Brushes.RoyalBlue, 2, 8, 12, 14, 180, 180);
                        break;
                }
            }
            return bmp;
        }

        #endregion

        #region 1. Dữ liệu mẫu và cây TreeView

        private void LoadEmployees()
        {
            employees.Add(new Employee("NV001", "Lê Minh Dũng", "Giám đốc", new DateTime(2015, 3, 1), "CTY"));
            employees.Add(new Employee("NV002", "Phạm Minh Đức", "Phó giám đốc", new DateTime(2016, 6, 15), "CTY"));

            employees.Add(new Employee("NV003", "Lê Hoàng Cường", "Trưởng phòng Kỹ thuật", new DateTime(2017, 1, 10), "PB_KT"));
            employees.Add(new Employee("NV004", "Lê Minh Tuấn ", "Trưởng nhóm Phát triển", new DateTime(2018, 4, 2), "N_DEV"));
            employees.Add(new Employee("NV005", "Võ Thị Hà", "Lập trình viên", new DateTime(2020, 8, 20), "N_DEV"));
            employees.Add(new Employee("NV006", "Đặng Quốc Huy", "Lập trình viên", new DateTime(2021, 11, 5), "N_DEV"));
            employees.Add(new Employee("NV007", "Bùi Thanh Hương", "Trưởng nhóm Kiểm thử", new DateTime(2019, 2, 18), "N_TEST"));
            employees.Add(new Employee("NV008", "Ngô Văn Khánh", "Kiểm thử viên", new DateTime(2022, 5, 9), "N_TEST"));

            employees.Add(new Employee("NV009", "Hoàng Thị Lan", "Trưởng phòng Kinh doanh", new DateTime(2016, 9, 1), "PB_KD"));
            employees.Add(new Employee("NV010", "Đỗ Minh Long", "Nhân viên bán hàng", new DateTime(2021, 3, 22), "N_SALE"));
            employees.Add(new Employee("NV011", "Trịnh Thu Mai", "Nhân viên bán hàng", new DateTime(2023, 7, 3), "N_SALE"));
            employees.Add(new Employee("NV012", "Lý Gia Nam", "Chuyên viên Marketing", new DateTime(2020, 10, 12), "N_MKT"));
            employees.Add(new Employee("NV013", "Mai Phương Oanh", "Thiết kế đồ họa", new DateTime(2022, 1, 17), "N_MKT"));

            employees.Add(new Employee("NV014", "Vũ Đức Phúc", "Trưởng phòng Nhân sự", new DateTime(2017, 5, 8), "PB_NS"));
            employees.Add(new Employee("NV015", "Cao Thị Quỳnh", "Chuyên viên tuyển dụng", new DateTime(2021, 9, 27), "N_TD"));
            employees.Add(new Employee("NV016", "Tạ Văn Sơn", "Chuyên viên đào tạo", new DateTime(2019, 12, 2), "N_DT"));
        }

        private void BuildTree()
        {
            tvDepartments.BeginUpdate();
            tvDepartments.Nodes.Clear();

            // Cấp 1: Công ty
            TreeNode company = CreateNode("CTY", "Công ty TNHH ABC", "company");
            tvDepartments.Nodes.Add(company);

            // Cấp 2: Phòng ban  -  Cấp 3: Nhóm
            TreeNode kt = CreateNode("PB_KT", "Phòng Kỹ thuật", "department");
            kt.Nodes.Add(CreateNode("N_DEV", "Nhóm Phát triển", "group"));
            kt.Nodes.Add(CreateNode("N_TEST", "Nhóm Kiểm thử", "group"));
            company.Nodes.Add(kt);

            TreeNode kd = CreateNode("PB_KD", "Phòng Kinh doanh", "department");
            kd.Nodes.Add(CreateNode("N_SALE", "Nhóm Bán hàng", "group"));
            kd.Nodes.Add(CreateNode("N_MKT", "Nhóm Marketing", "group"));
            company.Nodes.Add(kd);

            TreeNode ns = CreateNode("PB_NS", "Phòng Nhân sự", "department");
            ns.Nodes.Add(CreateNode("N_TD", "Nhóm Tuyển dụng", "group"));
            ns.Nodes.Add(CreateNode("N_DT", "Nhóm Đào tạo", "group"));
            company.Nodes.Add(ns);

            tvDepartments.ExpandAll();
            tvDepartments.EndUpdate();
        }

        private TreeNode CreateNode(string key, string text, string imageKey)
        {
            TreeNode node = new TreeNode(text);
            node.Name = key;
            node.Tag = key;
            node.ImageKey = imageKey;
            node.SelectedImageKey = imageKey;
            return node;
        }

        #endregion

        #region 2. Chọn Node -> lọc nhân viên vào ListView

        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Lấy mã của Node được chọn và tất cả Node con bên dưới nó
            List<string> keys = new List<string>();
            CollectKeys(e.Node, keys);

            List<Employee> result = employees
                .Where(emp => keys.Contains(emp.GroupKey))
                .OrderBy(emp => emp.EmployeeId)
                .ToList();

            LoadListView(result);
            lblInfo.Text = string.Format("{0}  -  {1} nhân viên", e.Node.Text, result.Count);
        }

        // Duyệt đệ quy để lấy mã của Node và các Node con
        private void CollectKeys(TreeNode node, List<string> keys)
        {
            keys.Add(node.Tag.ToString());
            foreach (TreeNode child in node.Nodes)
            {
                CollectKeys(child, keys);
            }
        }

        // Thêm dữ liệu vào ListView với các cột: Mã NV, Họ Tên, Chức vụ, Ngày vào làm
        private void LoadListView(List<Employee> list)
        {
            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();

            foreach (Employee emp in list)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId, "employee");
                item.SubItems.Add(emp.FullName);
                item.SubItems.Add(emp.Position);
                item.SubItems.Add(emp.HireDate.ToString("dd/MM/yyyy"));
                item.Tag = emp;
                lsvEmployees.Items.Add(item);
            }

            lsvEmployees.EndUpdate();
        }

        #endregion

        #region ComboBox - chuyển chế độ xem của ListView

        private void cboViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboViewMode.Text)
            {
                case "Details":
                    lsvEmployees.View = View.Details;
                    break;
                case "SmallIcon":
                    lsvEmployees.View = View.SmallIcon;
                    break;
                case "LargeIcon":
                    lsvEmployees.View = View.LargeIcon;
                    break;
                case "List":
                    lsvEmployees.View = View.List;
                    break;
                case "Tile":
                    lsvEmployees.View = View.Tile;
                    break;
            }
        }

        #endregion
    }
}
