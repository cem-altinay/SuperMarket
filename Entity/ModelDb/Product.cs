using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Entity.Enums.Enums;

namespace Entity.ModelDb
{
    public class Product : BaseUserEntity
    {
        public string Name { get; set; }
        public string  Description { get; set; }
        public ProductType ProductType { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
    }
}
