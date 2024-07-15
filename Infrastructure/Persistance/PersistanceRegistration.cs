using Microsoft.Extensions.DependencyInjection;
using Application.IRepository.IUserRepository;
using Persistance.Repository.UserRepository;
using Application.IRepository.IFormRepository;
using Persistance.Repository.FormRepository;

namespace Persistance
{
    public static class PersistanceRegistration
    {
        public static void AddPersistanceRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IUserRead, UserRead>();
            services.AddScoped<IUserWrite,UserWrite>();

            services.AddScoped<IFormRead, FormRead>();
            services.AddScoped<IFormWrite, FormWrite>();
        }
    }
}
