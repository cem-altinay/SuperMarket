using Core.Utilities.Business;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Data.UnitOfWork;
using Entity.Dto;
using Entity.ModelDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services.UserService
{
    public class UserService : IUserService
    {

        #region Fields
        private readonly ISuperMarketEntityDb _db;
        private readonly ITokenHelper _tokenHelper;
        #endregion

        #region Constructor
        public UserService(ISuperMarketEntityDb db, ITokenHelper tokenHelper)
        {
            _db = db;
            _tokenHelper = tokenHelper;
        }
        #endregion

        public List<Users> TestList()
            => _db.UserRepository.All().ToList();

        public IDataResult<LoginResponseModel> Login(LoginDto login)
        {

            var user = GetUsersWithNameAndPassword(login);
            if (user is null)
            {
                return new ErrorDataResult<LoginResponseModel>();
            }
            var token = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<LoginResponseModel>(data: new LoginResponseModel() { Token = token.Token, UserId = user.Id,UserName=user.UserName });
        }

        public IResult Add()
        {
            return new SuccessResult();
        }
        public Users GetUsersWithNameAndPassword(LoginDto login)
        {
            var user = _db.UserRepository.Find(x => x.UserName == login.UserName && x.Password == login.Password);
            return user;
        }
    }
}
