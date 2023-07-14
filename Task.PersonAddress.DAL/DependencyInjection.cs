using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DAL.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Task.PersonAddress.DAL.Repositories.IRepositories;
using Task.PersonAddress.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Task.PersonAddress.DAL;

public static class DependencyInjection
{
    public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<AspNetCoreTasksDbContext>(options =>
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
    }
}