using InterViewProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InterViewProject.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<FamilyEntities> FamilyEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyEntities>(entity =>
            {
                entity.HasKey(e => e.FamilyId);

                entity.ToTable("Family");

                entity.Property(e => e.FamilySex)
                    .HasColumnName("FamilySex")
                    .HasMaxLength(256);
                entity.Property(e => e.FamilyId)
                    .HasColumnName("FamilyId")
                    .HasMaxLength(256);
                entity.Property(e => e.FamilyName)
                    .HasColumnName("FamilyName")
                    .HasMaxLength(256);
                entity.Property(e => e.BirthDate)
                    .HasColumnName("BirthDate")
                    .HasColumnType("datetime");
                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasColumnType("numeric(19, 0)");
            });
        }
    }
}
