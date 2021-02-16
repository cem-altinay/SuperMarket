using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dto
{
    public class BasketListDto
    {
        public int BasketId { get; set; }
        public int BasketDetailId { get; set; }
        public int? UserId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class BasketRequestDto
    {
        public int? BasketId { get; set; }
        public int ProductId { get; set; }
    }

    public class BasketListRequestDto
    {
        public int BasketId { get; set; } 
    }
}
