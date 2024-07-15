using Application.IRepository.IUserRepository;
using Persistance.Context;
using Domain.Entities;

namespace Persistance.Repository.UserRepository
{
    public class UserWrite : WriteRepository<AppUser>, IUserWrite
    {
        public UserWrite(FormProjectDbContext context) : base(context)
        {
        }
    }
}
