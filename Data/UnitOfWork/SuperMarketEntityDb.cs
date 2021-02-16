using Entity.ModelDb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
    public interface ISuperMarketEntityDb : IUnitOfWork
    {
        #region Repository
        ITableRepository<Users> UserRepository { get; }
        ITableRepository<Product> ProductRepository { get; }
        ITableRepository<Basket> BasketRepository { get; }
        ITableRepository<BasketDetail> BasketDetailRepository { get; }
        #endregion
    }

    public class SuperMarketEntityDb : ISuperMarketEntityDb
    {
        #region Fields and Constructor

        private readonly DbContext _dbContext;
        private bool _disposed;

        public SuperMarketEntityDb(IDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.GetDbContext();
            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }
        #endregion

        #region IDisposeble
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion


        #region IUnitOfWork
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion

        #region Repository
        private ITableRepository<Users> _UsersRepository;
        public ITableRepository<Users> UserRepository => _UsersRepository ?? (_UsersRepository = new TableRepository<Users>(_dbContext));


        private ITableRepository<Product> _ProductRepository;
        public ITableRepository<Product> ProductRepository => _ProductRepository ?? (_ProductRepository = new TableRepository<Product>(_dbContext));


        private ITableRepository<Basket> _BasketRepository;
        public ITableRepository<Basket> BasketRepository => _BasketRepository ?? (_BasketRepository = new TableRepository<Basket>(_dbContext));

        private ITableRepository<BasketDetail> _BasketDetailRepository;
        public ITableRepository<BasketDetail> BasketDetailRepository => _BasketDetailRepository ?? (_BasketDetailRepository = new TableRepository<BasketDetail>(_dbContext));

        #endregion
    }
}
