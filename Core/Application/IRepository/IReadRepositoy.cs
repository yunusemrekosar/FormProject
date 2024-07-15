using System.Linq.Expressions;
using Domain.Entities.Base;

namespace Application.IRepository
{
    public interface IReadRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);

        IQueryable<T> GetById(int id, bool tracking = true);
    }
}
