using Task.PersonAddress.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.BLL.Services.IServices;

public interface IAuthService
{
    Task<PersonToReturnDTO> LoginAsync(PersonToLoginDTO userToLoginDTO);
    Task<PersonToReturnDTO> RegisterAsync(PersonToRegisterDTO userToRegisterDTO);
}
