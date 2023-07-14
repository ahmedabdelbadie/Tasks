

using Task.PersonAddress.DTO.DTOs;
using T = System.Threading.Tasks;
namespace Task.PersonAddress.BLL.Services.IServices;

public interface IPersonService
{
    T.Task<List<PersonDTO>> GetPersonsAsync(CancellationToken cancellationToken = default);
    T.Task<PersonDTO> GetPersonAsync(int PersonId, CancellationToken cancellationToken = default);
    T.Task<PersonDTO> AddPersonAsync(PersonToAddDTO PersonToAddDTO);
    T.Task<PersonDTO> UpdatePersonAsync(PersonToUpdateDTO PersonToUpdateDTO);
    T.Task DeletePersonAsync(int PersonId);
}
