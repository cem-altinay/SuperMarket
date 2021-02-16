using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ModelDb
{
    public class BasketDetail : BaseUserEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime BasketDate { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }

    }
}
