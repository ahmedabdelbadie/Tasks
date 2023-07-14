
using Task.PersonAddress.DAL.DataContext;
using Task.PersonAddress.DAL.Entities;
using Task.PersonAddress.DAL.Repositories.IRepositories;

namespace Task.PersonAddress.DAL.Repositories;
public class AddressRepository : GenericRepository<Address>, IAddressRepository
{

    public AddressRepository(AspNetCoreTasksDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
    {

    }

   
}
