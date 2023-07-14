using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.PersonAddress.BLL.Services.IServices;

namespace Task.PersonAddress.API.Controllers.V2;

//[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _PersonService;

    public PersonController(IPersonService PersonService)
    {
        _PersonService = PersonService;
    }

    [HttpGet("getusers")]
    public async Task<IActionResult> GetPersons(CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _PersonService.GetPersonsAsync(cancellationToken));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}
