using System;
using System.Collections.Generic;
using System.Text;
using static Entity.Enums.Enums;

namespace Entity.ModelDb
{
    public class Basket : BaseUserEntity
    {
        public Basket()
        {
            BasketDetails = new HashSet<BasketDetail>();
        }

        public int UserId { get; set; }
        public DateTime BasketDate { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public BasketStatus BasketStatus { get; set; }

        public virtual ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
