using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DAL.Entities;
using Task.PersonAddress.DAL.Repositories;
using Task.PersonAddress.DAL.Repositories.IRepositories;
using Task.PersonAddress.DTO.DTOs;
using Th = System.Threading.Tasks;
namespace Task.PersonAddress.BLL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressService> _logger;

        public AddressService(IAddressRepository AddressRepository, IMapper mapper, ILogger<AddressService> logger)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<AddressDTO>> GetAddresssAsync(CancellationToken cancellationToken = default)
        {
            var AddressDTO = await _AddressRepository.GetListAsync(cancellationToken: cancellationToken);
            _logger.LogInformation("List of {Count} Addresss has been returned", AddressDTO.Count);

            return _mapper.Map<List<AddressDTO>>(AddressDTO);
        }

        public async Task<AddressDTO> GetAddressAsync(int AddressId, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Address with AddressId = {AddressId} was requested", AddressId);
            var AddressToReturn = await _AddressRepository.GetAsync(x => x.AddressId == AddressId, cancellationToken);

            if (AddressToReturn is null)
            {
                _logger.LogError("Address with AddressId = {AddressId} was not found", AddressId);
                throw new AddressNotFoundException();
            }

            return _mapper.Map<AddressDTO>(AddressToReturn);
        }

        public async Task<AddressDTO> AddAddressAsync(AddressToAddDTO AddressToAddDTO)
        {
            var addedAddress = await _AddressRepository.AddAsync(_mapper.Map<Address>(AddressToAddDTO));

            return _mapper.Map<AddressDTO>(addedAddress);
        }

        public async Task<AddressDTO> UpdateAddressAsync(AddressToUpdateDTO AddressToUpdateDTO)
        {
            var Address = await _AddressRepository.GetAsync(x => x.AddressId == AddressToUpdateDTO.AddressId);

            if (Address is null)
            {
                _logger.LogError("Address with AddressId = {AddressId} was not found", AddressToUpdateDTO.AddressId);
                throw new AddressNotFoundException();
            }

            var AddressToUpdate = _mapper.Map<Address>(AddressToUpdateDTO);

            _logger.LogInformation("Address with these properties: {@AddressToUpdate} has been updated", AddressToUpdateDTO);

            return _mapper.Map<AddressDTO>(await _AddressRepository.UpdateAsync(AddressToUpdate));
        }

        public async Th.Task DeleteAddressAsync(int AddressId)
        {
            var AddressToDelete = await _AddressRepository.GetAsync(x => x.AddressId == AddressId);

            if (AddressToDelete is null)
            {
                _logger.LogError("Address with AddressId = {AddressId} was not found", AddressId);
                throw new AddressNotFoundException();
            }

            await _AddressRepository.DeleteAsync(AddressToDelete);
        }
    }
}
