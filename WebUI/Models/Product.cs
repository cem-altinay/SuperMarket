using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebUI.Models.Enums;

namespace WebUI.Models
{
    public class ProductListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public string ProductTypeText { get; set; }
    }
}
