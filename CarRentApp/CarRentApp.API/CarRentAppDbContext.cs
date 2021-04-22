using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CarRentApp.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using CarRentApp.Domain.EFMapping.Schemas;
using CarRentApp.Domain.EFMapping;
using CarRentApp.Domain;

namespace CarRentApp.API
{
     public class CarRentAppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
     {
          public CarRentAppDbContext(DbContextOptions<CarRentAppDbContext> options) : base(options)
          {
          }

          public DbSet<Car> Cars { get; set; }
          public DbSet<Photo> Photos { get; set; }
          public DbSet<Client> Clients { get; set; }
          public DbSet<Reservation> Reservations { get; set; }
          public DbSet<Admin> Admins { get; set; }


          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new CarConfig());
               modelBuilder.ApplyConfiguration(new PhotoConfig());
               modelBuilder.ApplyConfiguration(new ReservationConfig());
               modelBuilder.ApplyConfiguration(new ClientConfig());

               ApplyIdentityMapConfiguration(modelBuilder);
          }

          private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
          {
               modelBuilder.Entity<User>().ToTable("Users", SchemaConsts.Auth);
               modelBuilder.Entity<Client>().ToTable("Clients", SchemaConsts.Auth);
               modelBuilder.Entity<Admin>().ToTable("Admin", SchemaConsts.Auth);
               modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConsts.Auth);
               modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConsts.Auth);
               modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConsts.Auth);
               modelBuilder.Entity<Role>().ToTable("Roles", SchemaConsts.Auth);
               modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConsts.Auth);
               modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConsts.Auth);
          }
     }
}
