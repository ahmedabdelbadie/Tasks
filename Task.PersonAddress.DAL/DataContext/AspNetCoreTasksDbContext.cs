using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DAL.Entities;

namespace Task.PersonAddress.DAL.DataContext;

public class AspNetCoreTasksDbContext : DbContext
{
    public AspNetCoreTasksDbContext(DbContextOptions<AspNetCoreTasksDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>().HasData(new Address { AddressId = 1, City = "cairo", State = "12345", Street = "cc", Zip = "123456" });
        modelBuilder.Entity<Person>().HasData(
             new Person
             {
                 PersonId = 1,
                 Username = "ahmed",
                 Password = "123",
                 Name = "Ahmed",
                 Surname = "Badea",
             }
         );
    }
}