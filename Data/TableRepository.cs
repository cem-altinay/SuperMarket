using Data.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface ITableRepository<T> : IRepository<T> where T : class
    { }
    public sealed class TableRepository<T> : Repository<T>, ITableRepository<T> where T : class, new()
    {
        public TableRepository(DbContext dbContext) : base(dbContext)
        { }
    }
}
