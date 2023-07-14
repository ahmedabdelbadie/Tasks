using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.API.Controllers;


[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _AddressService;

    public AddressController(IAddressService AddressService)
    {
        _AddressService = AddressService;
    }

    [HttpGet("getAddresss")]
    public async Task<IActionResult> GetAddresss()
    {
        try
        {
            return Ok(await _AddressService.GetAddresssAsync());
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpGet("getAddress")]
    public async Task<IActionResult> GetAddress(int AddressId, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _AddressService.GetAddressAsync(AddressId, cancellationToken));
        }
        catch (AddressNotFoundException)
        {
            return NotFound("Address not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPost("addAddress")]
    public async Task<IActionResult> AddAddress(AddressToAddDTO AddressToAddDTO)
    {
        try
        {
            return Ok(await _AddressService.AddAddressAsync(AddressToAddDTO));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPut("updateAddress")]
    public async Task<IActionResult> UpdateAddress(AddressToUpdateDTO AddressToUpdateDTO)
    {
        try
        {
            return Ok(await _AddressService.UpdateAddressAsync(AddressToUpdateDTO));
        }
        catch (AddressNotFoundException)
        {
            return NotFound("Address not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpDelete("deleteAddress")]
    public async Task<IActionResult> DeleteAddress(int AddressId)
    {
        try
        {
            await _AddressService.DeleteAddressAsync(AddressId);
            return Ok();
        }
        catch (AddressNotFoundException)
        {
            return NotFound("Address not found");
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}
