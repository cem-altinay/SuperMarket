using Business.Services.UserService;
using Core.Utilities.Result;
using Data.UnitOfWork;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Services.BasketService
{
    public class BasketService : IBasketService
    {

        #region Fields
        private readonly ISuperMarketEntityDb _db;
        private readonly IUserInfoService _userInfo;
        #endregion

        #region Constructor
        public BasketService(ISuperMarketEntityDb db, IUserInfoService userInfo)
        {
            _db = db;
            _userInfo = userInfo;
        }
        #endregion

        public IDataResult<List<BasketListDto>> GetWaitingBasketList()
        {
            return new SuccessDataResult<List<BasketListDto>>((from basket in _db.BasketRepository.All()
                                                               join basketDetail in _db.BasketDetailRepository.All() on basket.Id equals basketDetail.BasketId
                                                               join product in _db.ProductRepository.All() on basketDetail.ProductId equals product.Id
                                                               where basket.BasketStatus == Entity.Enums.Enums.BasketStatus.InCart
                                                               select new BasketListDto()
                                                               {
                                                                   BasketDetailId = basketDetail.Id,
                                                                   BasketId = basket.Id,
                                                                   Price = basketDetail.Price,
                                                                   ProductId = basketDetail.ProductId,
                                                                   ProductName = product.Name,
                                                                   Quantity = basketDetail.Quantity,
                                                                   UserId = basket.UserId
                                                               }).ToList());
        }

        public IDataResult<List<BasketListDto>> GetWaitingBasketListWithId(BasketListRequestDto request)
        {
            return new SuccessDataResult<List<BasketListDto>>((from basket in _db.BasketRepository.All()
                                                               join basketDetail in _db.BasketDetailRepository.All() on basket.Id equals basketDetail.BasketId
                                                               join product in _db.ProductRepository.All() on basketDetail.ProductId equals product.Id
                                                               where basket.BasketStatus == Entity.Enums.Enums.BasketStatus.InCart && basket.Id == request.BasketId
                                                               select new BasketListDto()
                                                               {
                                                                   BasketDetailId = basketDetail.Id,
                                                                   BasketId = basket.Id,
                                                                   Price = basketDetail.Price,
                                                                   ProductId = basketDetail.ProductId,
                                                                   ProductName = product.Name,
                                                                   Quantity = basketDetail.Quantity,
                                                                   UserId = basket.UserId
                                                               }).ToList());
        }
    }
}
