using Application.IRepository.IUserRepository;
using Persistance.Context;
using Domain.Entities;

namespace Persistance.Repository.UserRepository
{
    public class UserRead : ReadRepository<AppUser>, IUserRead
    {
        public UserRead(FormProjectDbContext context) : base(context)
        {
        }
    }
}
