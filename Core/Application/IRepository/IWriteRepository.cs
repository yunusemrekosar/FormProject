using Domain.Entities.Base;

namespace Application.IRepository
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        bool Update(T model);
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        Task<bool> RemoveByIdAsync(int id);
        bool RemoveRange(List<T> model);
        bool UpdateRange(List<T> model);
        Task<int> SaveAsync();
    }
}
