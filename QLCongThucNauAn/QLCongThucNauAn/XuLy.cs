using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using QLCongThucNauAn.Data; 

namespace QLCongThucNauAn
{
    internal class XuLy
    {
     
        public static List<string[]> ReadCsvFile(string filePath)
        {
            List<string[]> rows = new List<string[]>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    rows.Add(values);
                }

                Console.WriteLine("CSV file read successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return rows;
        }

        //File ghi lại từ csdl dó
        public static RecipeLinkedList ReadCsvToLinkedList(string filePath)
        {
            RecipeLinkedList list = new RecipeLinkedList();

            try
            {
                // Bước 1: Lấy dữ liệu thô từ file CSV
                var rawData = ReadCsvFile(filePath);

                if (rawData == null || rawData.Count <= 1)
                {
                    // Trả về danh sách rỗng nếu không có dữ liệu (hoặc chỉ có header)
                    return list;
                }

                // Bỏ qua dòng tiêu đề (Header) - Duyệt từ dòng 1 (index 1)
                for (int i = 1; i < rawData.Count; i++)
                {
                    var row = rawData[i];

                    // Giả định công thức có 8 trường
                    if (row.Length >= 8)
                    {
                        // XỬ LÝ LỖI AN TOÀN: Dùng int.TryParse thay vì int.Parse
                        // Tránh lỗi crash nếu dữ liệu Num_Ingredients hoặc Num_Steps không phải là số
                        if (int.TryParse(row[6].Trim(), out int numIngredients) &&
                            int.TryParse(row[7].Trim(), out int numSteps))
                        {
                            // TẠO ĐỐI TƯỢNG RECIPE bằng Constructor đã tối ưu ở Recipe.cs
                            Recipe recipe = new Recipe(
                                title: row[0].Trim(),
                                category: row[1].Trim(), // Đã sửa lỗi chính tả 'Categoty' thành 'Category'
                                subcategory: row[2].Trim(),
                                description: row[3].Trim(),
                                ingredients: row[4].Trim(),
                                directions: row[5].Trim(),
                                num_Ingredients: numIngredients,
                                num_Steps: numSteps
                            );

                            // Thêm đối tượng Recipe vào Danh sách Liên kết
                            list.Add(recipe);
                        }
                        // else: Bỏ qua dòng nếu dữ liệu số bị lỗi
                    }
                    // else: Bỏ qua dòng nếu số cột không đủ
                }

                // Console.WriteLine("Linked List created successfully!");
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung trong quá trình xử lý dữ liệu
                // Console.WriteLine($"Error creating Linked List: {ex.Message}");
                MessageBox.Show($"Lỗi xử lý dữ liệu Linked List: {ex.Message}", "Lỗi Xử Lý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return list;
        }
    }
}
