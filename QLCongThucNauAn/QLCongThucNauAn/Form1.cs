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
            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu! Vui lòng nhấn 'Xu Ly CSV' trước.");
                return;
            }

            // Tạo bảng mới chỉ chứa 10 dòng đầu tiên
            DataTable top10Table = table.Clone(); // sao chép cấu trúc cột

            int maxRows = Math.Min(10, table.Rows.Count);
            for (int i = 0; i < maxRows; i++)
            {
                top10Table.ImportRow(table.Rows[i]);
            }

            // Hiển thị lên DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = top10Table;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
        }
    }
}
