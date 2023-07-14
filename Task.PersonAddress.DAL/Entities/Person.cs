using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.DAL.Entities;

public class Person
{
    public int PersonId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public virtual Address Address { get; set; } 
}
