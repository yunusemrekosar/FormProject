using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Base;
using Domain.Entities;

namespace Persistance.Context
{
    public class FormProjectDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public FormProjectDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Form>()
             .HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.CreatedBy);

            builder.Entity<Form>()
             .HasIndex(x => x.Name)
             .IsUnique();

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<IBaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        if (data.Entity is not FormField)
                            data.Entity.CreatedAt = DateTime.Now;
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<IBaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        if (data.Entity is not FormField)
                            data.Entity.CreatedAt = DateTime.Now;
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}