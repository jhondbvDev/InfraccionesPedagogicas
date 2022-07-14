using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraccionesPedagogicas.Infrastructure.Data
{
    public sealed class InfraccionesDbContext : IdentityDbContext<Usuario>, IInfraccionesDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Infraccion> Infracciones { get; set; }
        public DbSet<DatosInfractor> DatosInfractor { get; set; }
        public DbSet<Infractor> Infractores { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public InfraccionesDbContext(DbContextOptions<InfraccionesDbContext> options) : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfraccionesDbContext).Assembly);
            modelBuilder.HasCharSet("utf8");
            SetMaxString(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private void SetMaxString(ModelBuilder builder)
        {
            int size = 100;
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(size));
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(size));
            builder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(size));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(size));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(size));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(size));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(size));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(size));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(size));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(size));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(size));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(size));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(size));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(size));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(size));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(size));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(size));
        }
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            IdentityRole tmb = new IdentityRole();
            tmb.Id = "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf24";
            tmb.Name = "TMB";
            tmb.NormalizedName = "TMB";

            IdentityRole sm = new IdentityRole();
            sm.Id = "ba3bc22c-0eda-4245-85a6-82ad5e0ca266";
            sm.Name = "SM";
            sm.NormalizedName = "SM";
            //Seed Data
            modelBuilder.Entity<IdentityRole>().HasData(tmb, sm);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            const string roleId = "c3f2ef86-8dc6-4604-ab8c-fd53f6bddf24";
            const string userId = "b5b8ed22-b18a-4496-bd9c-5be0dedee5a2";

            var hasher = new PasswordHasher<Usuario>();
            Usuario tmb = new Usuario();
            tmb.Id = userId;
            tmb.Nombre = "Admin";
            tmb.UserName = "tmb@transitobello.com";
            tmb.NormalizedUserName = "TMB@TRANSITOBELLO.COM";
            tmb.Email = "tmb@transitobello.com";
            tmb.PasswordHash = hasher.HashPassword(tmb, "Infracciones1.");
            tmb.SecurityStamp = new Guid().ToString("D");

            IdentityUserRole<string> userRole = new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            };

            //Seed Data
            modelBuilder.Entity<Usuario>().HasData(tmb);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
