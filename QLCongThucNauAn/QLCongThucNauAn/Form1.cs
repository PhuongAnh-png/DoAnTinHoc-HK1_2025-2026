using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongThucNauAn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            string filePath = "1_Recipe_csv.csv"; 
            var data = XuLy.ReadCsvFile(filePath);

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hoặc file CSV trống!");
                return;
            }

            DataTable table = new DataTable();

            // Tạo cột từ dòng đầu tiên (header)
            foreach (var col in data[0])
            {
                table.Columns.Add(col);
            }

            // Thêm dữ liệu vào bảng
            for (int i = 1; i < data.Count; i++)
            {
                var rowValues = data[i];

                if (rowValues == null || rowValues.Length == 0)
                    continue;

                // Nếu nhiều cột hơn tiêu đề → cắt bớt
                if (rowValues.Length > table.Columns.Count)
                    rowValues = rowValues.Take(table.Columns.Count).ToArray();

                // Nếu ít cột hơn tiêu đề → thêm giá trị trống
                if (rowValues.Length < table.Columns.Count)
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
    }
}