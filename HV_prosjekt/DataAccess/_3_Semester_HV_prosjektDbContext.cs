using _3_Semester_HV_prosjekt.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _3_Semester_HV_prosjekt.DataAccess
{
    public class _3_Semester_HV_prosjektDbContext(DbContextOptions<_3_Semester_HV_prosjektDbContext> options) : DbContext(options)
    {
        public DbSet<Resource> Resources => Set<Resource>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resources");
                entity.HasKey(resource => resource.Id);
                entity.Property(resource => resource.Name)
                    .HasMaxLength(200)
                    .IsRequired();
                entity.Property(resource => resource.Description)
                    .HasMaxLength(2000)
                    .IsRequired();
                entity.Property(resource => resource.Type)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(resource => resource.Address)
                    .HasMaxLength(200)
                    .IsRequired(false);
                entity.Property(resource => resource.City)
                    .HasMaxLength(100)
                    .IsRequired(false);
                entity.Property(resource => resource.ZipCode)
                    .HasMaxLength(4)
                    .IsRequired(false);
                entity.Property(resource => resource.OwnerTelephoneNumber)
                    .HasMaxLength(20)
                    .IsRequired(false);
            });
        }
    }
}
