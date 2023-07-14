using Task.PersonAddress.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.DAL.Repositories.IRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DAL.Entities;
using TH = System.Threading.Tasks;
namespace Task.PersonAddress.BLL.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _PersonRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<PersonService> _logger;

    public PersonService(IPersonRepository PersonRepository, IMapper mapper, ILogger<PersonService> logger)
    {
        _PersonRepository = PersonRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<PersonDTO>> GetPersonsAsync(CancellationToken cancellationToken = default)
    {
        var PersonsToReturn = await _PersonRepository.GetListAsync(cancellationToken: cancellationToken);
        _logger.LogInformation("List of {Count} Persons has been returned", PersonsToReturn.Count);

        return _mapper.Map<List<PersonDTO>>(PersonsToReturn);
    }

    public async Task<PersonDTO> GetPersonAsync(int PersonId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Person with PersonId = {PersonId} was requested", PersonId);
        var PersonToReturn = await _PersonRepository.GetAsync(x => x.PersonId == PersonId, cancellationToken);

        if (PersonToReturn is null)
        {
            _logger.LogError("Person with PersonId = {PersonId} was not found", PersonId);
            throw new PersonNotFoundException();
        }

        return _mapper.Map<PersonDTO>(PersonToReturn);
    }

    public async Task<PersonDTO> AddPersonAsync(PersonToAddDTO PersonToAddDTO)
    {
        PersonToAddDTO.Username = PersonToAddDTO.Username.ToLower();
        var addedPerson = await _PersonRepository.AddAsync(_mapper.Map<Person>(PersonToAddDTO));

        return _mapper.Map<PersonDTO>(addedPerson);
    }

    public async Task<PersonDTO> UpdatePersonAsync(PersonToUpdateDTO PersonToUpdateDTO)
    {
        PersonToUpdateDTO.Username = PersonToUpdateDTO.Username.ToLower();
        var Person = await _PersonRepository.GetAsync(x => x.PersonId == PersonToUpdateDTO.PersonId);

        if (Person is null)
        {
            _logger.LogError("Person with PersonId = {PersonId} was not found", PersonToUpdateDTO.PersonId);
            throw new PersonNotFoundException();
        }

        var PersonToUpdate = _mapper.Map<Person>(PersonToUpdateDTO);

        _logger.LogInformation("Person with these properties: {@PersonToUpdate} has been updated", PersonToUpdateDTO);

        return _mapper.Map<PersonDTO>(await _PersonRepository.UpdatePersonAsync(PersonToUpdate));
    }

    public async TH.Task DeletePersonAsync(int PersonId)
    {
        var PersonToDelete = await _PersonRepository.GetAsync(x => x.PersonId == PersonId);

        if (PersonToDelete is null)
        {
            _logger.LogError("Person with PersonId = {PersonId} was not found", PersonId);
            throw new PersonNotFoundException();
        }

        await _PersonRepository.DeleteAsync(PersonToDelete);
    }
}