using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DemoEmployeeApiVersioning.WebAPI.Setup.Swagger;


public sealed class SwaggerDefaultValues : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var response in operation.Responses)
        {
            response.Value.Description ??= "Success";
        }

        if (operation.Parameters is null)
            return;

        foreach (var parameter in operation.Parameters)
        {
            parameter.Description ??= string.Empty;

            if (parameter.Schema.Default is null && parameter.Schema.Example is not null)
            {
                parameter.Schema.Default = parameter.Schema.Example;
            }
        }
    }
}