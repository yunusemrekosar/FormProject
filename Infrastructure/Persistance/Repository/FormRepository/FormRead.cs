using Application.IRepository.IFormRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistance.Repository.FormRepository
{
    public class FormRead : ReadRepository<Form>, IFormRead
    {
        readonly FormProjectDbContext _context;
        public FormRead(FormProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Form> GetUsersForms(int userId, string search, bool tracking = true)
        {
            IQueryable<Form> query;

            if (!string.IsNullOrEmpty(search))
                query = _context.Forms
                    .Where(x => x.CreatedBy == userId && x.Name.ToLower()
                    .Contains(search.ToLower()));
            else
                query = _context.Forms.Where(x => x.CreatedBy == userId);

            if (!tracking) query = query.AsNoTracking();
            return query;
        }
    }
}
