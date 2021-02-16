using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Enums
    {
        public enum ProductType
        {
            Phone,
            Computer,
            Television,
            Tablet,
            MusicPlayer
        }

        public enum PaymentType
        {
            CreditCard,
            Cash
        }

        public enum BasketStatus
        {
            InCart,
            SalesMade,
            Cancel
        }
    }
}
