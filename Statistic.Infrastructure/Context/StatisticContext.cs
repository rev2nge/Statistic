using Microsoft.EntityFrameworkCore;
using Statistic.Domain.Models;

namespace Statistic.Infrastructure.Context
{
    public class StatisticContext : DbContext
    {
        public StatisticContext(DbContextOptions<StatisticContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Meteorology> Meteorologies { get; set; }
        public DbSet<Source> Source { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meteorology>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Meteorology>()
                .Property(m => m.AirTemperature)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Meteorology>()
                .Property(m => m.PrecipitationQuantity)
                .HasMaxLength(50);

            modelBuilder.Entity<Meteorology>()
                .Property(m => m.AverageMonthlyWindSpeed)
                .HasMaxLength(50);

            modelBuilder.Entity<Meteorology>()
                .Property(m => m.Month)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Meteorology>()
                .Property(m => m.Year)
                .IsRequired();

            modelBuilder.Entity<Meteorology>()
                .HasOne(m => m.Contact)
                .WithMany()
                .HasForeignKey(m => m.ContactId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Meteorology>()
                .HasOne(m => m.Source)
                .WithMany()
                .HasForeignKey(m => m.SourceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Address)
                .HasMaxLength(500); 

            modelBuilder.Entity<Contact>()
                .Property(c => c.Phone)
                .HasMaxLength(50);

            modelBuilder.Entity<Contact>()
                .Property(c => c.Email)
                .HasMaxLength(255);

            modelBuilder.Entity<Source>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Source>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Source>()
                .Property(s => s.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<Source>()
                .Property(s => s.Link)
                .HasMaxLength(500);

            base.OnModelCreating(modelBuilder);
        }
    }
}