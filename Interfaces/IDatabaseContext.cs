using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmallMVC.Models;

namespace SmallMVC.Interfaces;

public interface IDatabaseContext
{
    DbSet<Person> People { get; set; }
    DbSet<Address> Addresses { get; set; }
    DbSet<PhoneNumber> PhoneNumbers { get; set; }
    DbSet<SpouseDetails> SpouseDetails { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}