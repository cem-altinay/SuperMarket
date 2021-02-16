using Business.Services.UserService;
using Core.Utilities.Result;
using Data.UnitOfWork;
using Entity.Dto;
using Entity.ModelDb;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services.ProductService
{
    public class ProductService : IProductService
    {

        #region Fields
        private readonly ISuperMarketEntityDb _db;
        private readonly IUserInfoService _userInfo;
        #endregion

        #region Constructor
        public ProductService(ISuperMarketEntityDb db, IUserInfoService userInfo)
        {
            _db = db;
            _userInfo = userInfo;
        }
        #endregion

        public IDataResult<List<ProductListDto>> GetActiveProductList()
        {
            return new SuccessDataResult<List<ProductListDto>>(_db.ProductRepository.Filter(v => v.IsDeleted == false).Select(s => new ProductListDto()
            {
                Description = s.Description,
                CreatedDate = s.CreatedDate,
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                ProductType = s.ProductType,
                StockAmount = s.StockAmount
            }).ToList());
        }

        public IResult Create(ProductCreateDto createDto)
        {
            Product product = new Product()
            {
                CreatedById = _userInfo.UserId,
                CreatedDate = DateTime.Now,
                Description = createDto.Description,
                IsDeleted = false,
                Name = createDto.Name,
                Price = createDto.Price,
                ProductType = createDto.ProductType,
                StockAmount = createDto.StockAmount
            };
            _db.ProductRepository.Create(product);
            return new SuccessResult();
        }

        public IResult Update(ProductCreateDto createDto)
        {
            Product product = GetProduct(createDto.Id);
            if (product != null)
            {
                product.ModifiedDate = DateTime.Now;
                product.Description = createDto.Description;
                product.IsDeleted = false;
                product.Name = createDto.Name;
                product.Price = createDto.Price;
                product.ProductType = createDto.ProductType;
                product.StockAmount = createDto.StockAmount;

                _db.ProductRepository.Update(product);
            }
            return new SuccessResult();
        }

        public IResult Delete(ProductDeleteRequest request)
        {
            Product product = GetProduct(request.Id);
            if (product != null)
            {
                product.IsDeleted = true;
                _db.ProductRepository.Update(product);
            }
            return new SuccessResult();
        }

        public Product GetProduct(int id)
        {
            return _db.ProductRepository.Find(v => v.Id == id);
        }


    }
}
