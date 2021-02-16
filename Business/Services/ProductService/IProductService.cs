using Core.Utilities.Result;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductService
{
    public interface IProductService
    {
        IResult Create(ProductCreateDto createDto);
        IResult Delete(ProductDeleteRequest request);
        IDataResult<List<ProductListDto>> GetActiveProductList();
        IResult Update(ProductCreateDto createDto);
    }
}
