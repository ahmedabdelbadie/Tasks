using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.DAL.Entities;

public class Address
{
    
    public int AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    [ForeignKey("Person")]
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } 

}
