using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DemoEmployeeApiVersioning.WebAPI.Setup.Swagger;


public sealed class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    : IConfigureOptions<SwaggerGenOptions>
{
    private static readonly Dictionary<string, string> Descriptions = new()
    {
        ["v1"] = "Employee API Base Version - Using URI Path versioning",
        ["v2"] = "Employee API V2 - Using URI Path versioning. Breaking changes introduced, so only Clients updated to V2 spec. are compatible.",
        ["v3"] = "Employee API V3 - Using URI Path versioning. Backward compatible with V2 while providing additional fields for UI enrichment.",
        ["v4"] = "Employee API V4 Future plan",
    };

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = "Employee API Versioning Demo",
                Version = description.GroupName.ToUpper(),
                Description = Descriptions.GetValueOrDefault(description.GroupName, "Employee API Path versioning ")
                //Description = $"Employee API {description.GroupName.ToUpper()}"
            });
        }
    }
}
