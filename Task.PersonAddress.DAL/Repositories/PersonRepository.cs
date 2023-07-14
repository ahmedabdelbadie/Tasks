using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DAL.DataContext;
using Task.PersonAddress.DAL.Entities;
using Task.PersonAddress.DAL.Repositories.IRepositories;

namespace Task.PersonAddress.DAL.Repositories;
public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    private readonly AspNetCoreTasksDbContext _aspNetCoreNTierDbContext;
    public PersonRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
    {
        _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
    }

    public async Task<Person> UpdatePersonAsync(Person person)
    {
        _ = _aspNetCoreNTierDbContext.Update(person);

        // Ignore password property update for user
        _aspNetCoreNTierDbContext.Entry(person).Property(x => x.Password).IsModified = false;

        await _aspNetCoreNTierDbContext.SaveChangesAsync();
        return person;
    }
}
