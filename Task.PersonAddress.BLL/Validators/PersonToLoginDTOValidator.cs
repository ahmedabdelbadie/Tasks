using Task.PersonAddress.DTO.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.BLL.Validators;

public class PersonToLoginDTOValidator : AbstractValidator<PersonToLoginDTO>
{
    public PersonToLoginDTOValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
