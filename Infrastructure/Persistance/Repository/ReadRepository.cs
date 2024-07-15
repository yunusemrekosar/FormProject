using Microsoft.EntityFrameworkCore;
using Application.IRepository;
using System.Linq.Expressions;
using Domain.Entities.Base;
using Persistance.Context;

namespace Persistance.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IBaseEntity
    {
        private readonly FormProjectDbContext _context;

        public ReadRepository(FormProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var parameter = expression.Parameters.Single();
            var isActiveCheckExpression = Expression.Equal(
                Expression.Property(parameter, "IsActive"),
                Expression.Constant(true)
            );

            var combinedExpression = Expression.AndAlso(expression.Body, isActiveCheckExpression);
            var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

            var query = Table.Where(lambda);

            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetById(int id, bool tracking = true)
        {
            var query = Table.Where(a => a.Id == id);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }
    }
}
