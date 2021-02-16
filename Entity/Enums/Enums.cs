using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Enums
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

        public static string GetProductTypeText(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Phone:
                    return "Telefon";
                case ProductType.Computer:
                    return "Bilgisayar";
                case ProductType.Television:
                    return "Televizyon";
                case ProductType.Tablet:
                    return "Tablet";
                case ProductType.MusicPlayer:
                    return "Müzik Çalar";
                default:
                    return "";
            }
        }
    }
}
