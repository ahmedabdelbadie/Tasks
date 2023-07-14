using Task.PersonAddress.DTO.DTOs;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.DAL.Repositories.IRepositories;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Task.PersonAddress.DAL.Entities;

namespace Task.PersonAddress.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IPersonRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public AuthService(
        IPersonRepository userRepository,
        IMapper mapper,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<PersonToReturnDTO> LoginAsync(PersonToLoginDTO userToLoginDTO)
    {
        var user = await _userRepository.GetAsync(
            u => u.Username == userToLoginDTO.Username.ToLower() && u.Password == userToLoginDTO.Password);

        if (user == null)
            throw new PersonNotFoundException();

        var userToReturn = _mapper.Map<PersonToReturnDTO>(user);
        userToReturn.Token = GenerateToken(user.PersonId, user.Username);

        return userToReturn;
    }

    public async Task<PersonToReturnDTO> RegisterAsync(PersonToRegisterDTO userToRegisterDTO)
    {
        userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

        var addedUser = await _userRepository.AddAsync(_mapper.Map<Person>(userToRegisterDTO));

        var userToReturn = _mapper.Map<PersonToReturnDTO>(addedUser);
        userToReturn.Token = GenerateToken(addedUser.PersonId, addedUser.Username);

        return userToReturn;
    }

    private string GenerateToken(int userId, string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}