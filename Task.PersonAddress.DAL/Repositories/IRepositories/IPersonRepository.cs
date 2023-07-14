using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DAL.Entities;

namespace Task.PersonAddress.DAL.Repositories.IRepositories;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<Person> UpdatePersonAsync(Person user);
}
