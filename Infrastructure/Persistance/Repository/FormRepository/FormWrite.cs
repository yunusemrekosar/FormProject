using Application.IRepository.IFormRepository;
using Persistance.Context;
using Domain.Entities;

namespace Persistance.Repository.FormRepository
{
    public class FormWrite : WriteRepository<Form>, IFormWrite
    {
        public FormWrite(FormProjectDbContext context) : base(context)
        {
        }
    }
}
