using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.API.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _PersonService;

    public PersonController(IPersonService PersonService)
    {
        _PersonService = PersonService;
    }

    [HttpGet("getPersons")]
    public async Task<IActionResult> GetPersons()
    {
        try
        {
            return Ok(await _PersonService.GetPersonsAsync());
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpGet("getPerson")]
    public async Task<IActionResult> GetPerson(int PersonId, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _PersonService.GetPersonAsync(PersonId, cancellationToken));
        }
        catch (PersonNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPost("addPerson")]
    public async Task<IActionResult> AddPerson(PersonToAddDTO PersonToAddDTO)
    {
        try
        {
            return Ok(await _PersonService.AddPersonAsync(PersonToAddDTO));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPut("updatePerson")]
    public async Task<IActionResult> UpdatePerson(PersonToUpdateDTO PersonToUpdateDTO)
    {
        try
        {
            return Ok(await _PersonService.UpdatePersonAsync(PersonToUpdateDTO));
        }
        catch (PersonNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpDelete("deletePerson")]
    public async Task<IActionResult> DeletePerson(int PersonId)
    {
        try
        {
            await _PersonService.DeletePersonAsync(PersonId);
            return Ok();
        }
        catch (PersonNotFoundException)
        {
            return NotFound("Person not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}
