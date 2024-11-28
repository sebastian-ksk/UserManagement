using Microsoft.EntityFrameworkCore;
using System.Configuration;
using UserManagement.Core.Models;

namespace UserManagement.Data.Context
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }

        public UserManagementContext(DbContextOptions<UserManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Area Configuration
            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(100);

                // Datos iniciales
                entity.HasData(
                    new Area { Id = 1, AreaName = "Nomina", IsActive = true },
                    new Area { Id = 2, AreaName = "Facturación", IsActive = true },
                    new Area { Id = 3, AreaName = "Servicio al Cliente", IsActive = true },
                    new Area { Id = 4, AreaName = "IT", IsActive = true }
                );
            });
        }
    }
}