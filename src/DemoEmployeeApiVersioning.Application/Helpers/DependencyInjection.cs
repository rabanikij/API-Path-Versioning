using AutoMapper;
using FluentValidation;
using DemoEmployeeApiVersioning.Application.Interfaces;
using DemoEmployeeApiVersioning.Application.Mapping;
using DemoEmployeeApiVersioning.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DemoEmployeeApiVersioning.Application.Helpers;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddAutoMapper(typeof(EmployeeMappingProfile).Assembly);
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        return services;
    }
}