using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.BLL.Utilities.CustomExceptions;

public class PersonNotFoundException : Exception
{
    public PersonNotFoundException()
    {
    }

    public PersonNotFoundException(string message)
        : base(message)
    {
    }

    public PersonNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
