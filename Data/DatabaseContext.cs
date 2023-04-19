using Microsoft.EntityFrameworkCore;
using SmallMVC.Interfaces;
using SmallMVC.Models;

namespace SmallMVC.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<SpouseDetails> SpouseDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.SpouseDetails)
                .WithOne()
                .HasForeignKey<SpouseDetails>(s => s.PersonId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}