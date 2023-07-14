using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.BLL.Utilities.CustomExceptions;

public class AddressNotFoundException : Exception
{
    public AddressNotFoundException()
    {
    }

    public AddressNotFoundException(string message)
        : base(message)
    {
    }

    public AddressNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
