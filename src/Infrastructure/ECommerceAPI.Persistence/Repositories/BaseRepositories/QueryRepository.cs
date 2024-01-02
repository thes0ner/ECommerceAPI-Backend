using ECommerceAPI.Application.Repositories.BaseRepository.Abstract;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories.Concrete
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;

        public QueryRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var result = Table.AsQueryable();
            if (!tracking)
                result = result.AsNoTracking();

            return result;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var result = Table.Where(filter);
            if (!tracking)
                result = Table.AsNoTracking();

            return result;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var result = Table.AsQueryable();
            if (!tracking)
                result = Table.AsNoTracking();

            return await result.FirstOrDefaultAsync();
        }

        public async Task<T> GetBtIdAsync(string id, bool tracking = true)
        {
            var result = Table.AsQueryable();
            if (!tracking)
                result = Table.AsNoTracking();

            return await result.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }

    }
}
