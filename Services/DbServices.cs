using Microsoft.EntityFrameworkCore;
using SmallMVC.Interfaces;
using SmallMVC.Models;

namespace SmallMVC.Services;

public class DbServices
{
    private readonly IDatabaseContext _context;

    public DbServices(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Person>> GetPeopleWithSpouseDetailsAsync()
    {
        return await _context.People.Include(p => p.SpouseDetails).ToListAsync();
    }

    public async Task AddPersonAsync(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSpouseDetailsAsync(int personId, int spouseId)
    {
        var person = await _context.People.FindAsync(personId);
        var spouse = await _context.People.FindAsync(spouseId);
        if (person != null && spouse != null)
        {
            person.SpouseDetails = new SpouseDetails
            {
                SpouseId = spouseId,
                MaritalStatus = "Married",
                PersonId = personId
            };
            spouse.SpouseDetails = new SpouseDetails
            {
                SpouseId = personId,
                MaritalStatus = "Married",
                PersonId = spouseId
            };

            _context.Entry(person).State = EntityState.Modified;
            _context.Entry(spouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateSingleAsync(int personId)
    {
        var person = await _context.People.FindAsync(personId);
        if (person != null)
        {
            person.SpouseDetails = new SpouseDetails
            {
                MaritalStatus = "Single",
                PersonId = personId
            };
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<object>> GetSpouseOptionsAsync()
    {
        var people = await _context.People.ToListAsync();
        return people.Select(p => new
        {
            Id = p.Id,
            Name = $"{p.FirstName} {p.LastName}",
            Age = (DateTime.Now - p.BirthDate).Days / 365
        }).ToList<object>();
    }
}