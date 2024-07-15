using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Application.IRepository;
using Domain.Entities.Base;
using Persistance.Context;

namespace Persistance.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IBaseEntity
    {
        private readonly FormProjectDbContext _context;

        public WriteRepository(FormProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Remove(T model)
        {
            //model.IsActive = false;
            //Table.Update(model);
            return true;
        }

        public bool RemoveRange(List<T> model)
        {
            //foreach (var item in model)
            //    item.IsActive = false;
            //Table.UpdateRange(model);
            return true;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return Remove(model);
        }
        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> model)
        {
            Table.UpdateRange(model);
            return true;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

    }
}
