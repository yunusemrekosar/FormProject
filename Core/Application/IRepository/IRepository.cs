using Microsoft.EntityFrameworkCore;
using Domain.Entities.Base;

namespace Application.IRepository
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        DbSet<T> Table { get; }
    }
}
