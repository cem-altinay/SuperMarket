using Core.Utilities.Result;
using Entity.Dto;
using System.Collections.Generic;

namespace Business.Services.BasketService
{
    public interface IBasketService
    {
        IDataResult<List<BasketListDto>> GetWaitingBasketList();
        IDataResult<List<BasketListDto>> GetWaitingBasketListWithId(BasketListRequestDto request);
    }
}