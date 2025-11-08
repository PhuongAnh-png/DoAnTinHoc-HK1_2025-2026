using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCongThucNauAn.Data
{
    public class RecipeNode
    {
        // Dữ liệu lưu trong node
        public Recipe Data { get; set; }

        // Trỏ tới node tiếp theo
        public RecipeNode Next { get; set; }

        // Hàm khởi tạo node
        public RecipeNode(Recipe data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
