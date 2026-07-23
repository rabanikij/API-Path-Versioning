using DemoEmployeeApiVersioning.Domain.Entities;
using DemoEmployeeApiVersioning.Domain.Interfaces;
using DemoEmployeeApiVersioning.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DemoEmployeeApiVersioning.Infrastructure.Helpers;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<InMemoryDatabase>();

        services.AddScoped<IRepository<Employee>, EmployeeRepository>();

        return services;
    }
}