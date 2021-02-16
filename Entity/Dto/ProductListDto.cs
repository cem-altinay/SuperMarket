using Entity.Enums;
using Entity.ModelDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dto
{
    public class ProductListDto : Product
    {
        public string ProductTypeText => Enums.Enums.GetProductTypeText(this.ProductType);
    }

    public class ProductCreateDto : Product
    {

    }

    public class ProductDeleteRequest
    {
        public int Id { get; set; }
    }
}
