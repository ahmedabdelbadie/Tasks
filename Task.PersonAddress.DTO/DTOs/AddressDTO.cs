using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.DTO.DTOs
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        
    }
}
