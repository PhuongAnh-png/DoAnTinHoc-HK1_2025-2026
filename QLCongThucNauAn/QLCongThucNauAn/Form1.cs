using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongThucNauAn
{
    public partial class Form1 : Form
    {
        private DataTable table; 

        public Form1()
        {
            InitializeComponent();

            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\DoAnTinHoc\QLCongThucNauAn\QLCongThucNauAn\bin\Debug\1_Recipe_csv.csv";
            var data = XuLy.ReadCsvFile(filePath);

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hoặc file CSV trống!");
                return;
            }

            
            table = new DataTable();

            
            foreach (var col in data[0])
                table.Columns.Add(col);

            
            for (int i = 1; i < data.Count; i++)
            {
                var rowValues = data[i];

                if (rowValues == null || rowValues.Length == 0)
                    continue;

                
                if (rowValues.Length > table.Columns.Count)
                    rowValues = rowValues.Take(table.Columns.Count).ToArray();
                else if (rowValues.Length < table.Columns.Count)
                {
                    var temp = rowValues.ToList();
                    while (temp.Count < table.Columns.Count)
                        temp.Add("");
                    rowValues = temp.ToArray();
                }

                table.Rows.Add(rowValues);
            }

            // Hiển thị bảng ra DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = table;
        }

        private void btnxemds_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đã load chưa
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Vui lòng nhấn 'Xử lý CSV' trước khi xem danh sách!");
                return;
            }

            // Lấy các dòng người dùng chọn
            var selectedRows = dataGridView1.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 dòng!");
                return;
            }

            if (selectedRows.Count > 10)
            {
                MessageBox.Show("Chỉ được chọn tối đa 10 dòng!");
                return;
            }

            // Chuẩn bị dữ liệu để truyền sang form Dslk
            List<string[]> selectedData = new List<string[]>();

            // Lấy header
            selectedData.Add(table.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName).ToArray());

            // Lấy giá trị từ các dòng người dùng chọn
            foreach (DataGridViewRow row in selectedRows)
            {
                if (row.IsNewRow) continue;
                List<string> values = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    values.Add(cell.Value?.ToString() ?? "");
                }
                selectedData.Add(values.ToArray());
            }

            // Mở form Dslk và truyền dữ liệu người dùng chọn vào
            Dslk formDanhSach = new Dslk(selectedData);
            formDanhSach.Show();
        }
    }
}
