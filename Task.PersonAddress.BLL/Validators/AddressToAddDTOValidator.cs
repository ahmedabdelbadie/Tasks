using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.BLL.Validators;

public class AddressToAddDTOValidator : AbstractValidator<AddressToAddDTO>
{
    public AddressToAddDTOValidator()
    {
        RuleFor(x => x.Zip).NotEmpty();
    }
}
