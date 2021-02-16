using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.UnitOfWork
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
            _context = new SuperMarketContext();
        }
        public DbContext GetDbContext()
        {
            return _context;
        }
    }
}
