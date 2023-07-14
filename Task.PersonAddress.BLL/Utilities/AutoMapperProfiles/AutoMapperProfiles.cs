using Task.PersonAddress.DTO.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.DAL.Entities;

namespace Task.PersonAddress.BLL.Utilities.AutoMapperProfiles;

public static class AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, PersonToAddDTO>().ReverseMap();
            CreateMap<Person, PersonToUpdateDTO>().ReverseMap();
            CreateMap<Person, PersonToRegisterDTO>().ReverseMap();
            CreateMap<Person, PersonToReturnDTO>().ReverseMap();

            //// Address
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, AddressToAddDTO>().ReverseMap();
            CreateMap<Address, AddressToUpdateDTO>().ReverseMap();

        }
    }
}
