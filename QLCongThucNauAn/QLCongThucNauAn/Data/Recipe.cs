using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCongThucNauAn.Data
{
    internal class Recipe
    {

        // Tên của công thức
        public string Title { get; set; }
        //Danh mục công thức chính
        public string Category { get; set; }
        //Danh mục công thức cụ thể
        public string Subcategory { get; set; }
        //Mô tả ngắn gọn về công thức
        public string Description { get; set; }
        //Danh sách các thành phần cần thiết
        public string Ingredients { get; set; }
        //Hướng dẫn nấu ăn từng bước
        public string Directions { get; set; }
        //Số lượng thành phần
        public int Num_Ingredients { get; set; }
        //Số bước theo hướng
        public int Num_Steps { get; set; }

       
    }
}
