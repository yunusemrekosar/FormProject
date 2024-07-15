using Application.IRepository.IFormRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Domain.Entities;

namespace Persistance.Repository.FormRepository
{
    public class FormRead : ReadRepository<Form>, IFormRead
    {
        readonly FormProjectDbContext _context;
        public FormRead(FormProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Form> GetUsersForms(int userId, bool tracking = true)
        {
            var query = _context.Forms.Where(x => x.CreatedBy == userId);
            if (!tracking) query = query.AsNoTracking();
            return query;
        }
    }
}
