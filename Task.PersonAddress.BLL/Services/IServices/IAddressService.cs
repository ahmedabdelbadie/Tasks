
using Task.PersonAddress.DTO.DTOs;
using T = System.Threading.Tasks;
namespace Task.PersonAddress.BLL.Services.IServices
{
    public interface IAddressService
    {
        T.Task<List<AddressDTO>> GetAddresssAsync(CancellationToken cancellationToken = default);
        T.Task<AddressDTO> GetAddressAsync(int AddressId, CancellationToken cancellationToken = default);
        T.Task<AddressDTO> AddAddressAsync(AddressToAddDTO AddressToAddDTO);
        T.Task<AddressDTO> UpdateAddressAsync(AddressToUpdateDTO userToUpdateDTO);
        T.Task DeleteAddressAsync(int AddressId);
    }
}
