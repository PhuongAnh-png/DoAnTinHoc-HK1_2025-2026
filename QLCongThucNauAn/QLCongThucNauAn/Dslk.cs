using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongThucNauAn
{
    public partial class Dslk : Form
    {
        private List<string[]> csvData;

        // Nhận dữ liệu từ Form1
        public Dslk(List<string[]> data)
        {
            InitializeComponent();
            this.csvData = data;
        }

        private void Dslk_Load(object sender, EventArgs e)
        {
            if (csvData == null || csvData.Count <= 1)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!");
                return;
            }

            DataTable table = new DataTable();

            // Tạo cột từ dòng đầu tiên
            foreach (var col in csvData[0])
                table.Columns.Add(col);

            // Thêm các dòng còn lại
            for (int i = 1; i < csvData.Count; i++)
                table.Rows.Add(csvData[i]);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
