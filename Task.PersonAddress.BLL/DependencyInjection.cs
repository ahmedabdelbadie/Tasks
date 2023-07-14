using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.BLL.Services;
using Task.PersonAddress.BLL.Utilities.AutoMapperProfiles;
using Task.PersonAddress.BLL.Utilities.Swagger;
using FluentValidation.AspNetCore;
using FluentValidation;
using Task.PersonAddress.BLL.Validators;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Task.PersonAddress.DAL.Entities;

namespace Task.PersonAddress.BLL;
public static class DependencyInjection
{
    public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfiles));
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAddressService, AddressService>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<PersonToLoginDTOValidator>();
        services.AddValidatorsFromAssemblyContaining<PersonToRegisterDTOValidator>();
        services.AddValidatorsFromAssemblyContaining<AddressToAddDTOValidator>();

        #region Versioning

        services.AddApiVersioning(opt =>
        {
            opt.ReportApiVersions = true;
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ApiVersionReader = new UrlSegmentApiVersionReader();
            opt.AssumeDefaultVersionWhenUnspecified = true;
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        #endregion

        #region Swagger

        services.AddSwaggerGen(options =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Paste your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                { jwtSecurityScheme, Array.Empty<string>() }
                });
        });

        services.ConfigureOptions<SwaggerConfigurationOptions>();

        #endregion
    }
}