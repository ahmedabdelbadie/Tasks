using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.PersonAddress.BLL.Utilities.Swagger;

public class SwaggerConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerConfigurationOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var desc in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(desc.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "task.personaddress",
                Version = desc.ApiVersion.ToString()
            });
        }
    }
}
