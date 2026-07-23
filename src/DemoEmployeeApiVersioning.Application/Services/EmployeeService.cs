using DemoEmployeeApiVersioning.Application.Interfaces;
using DemoEmployeeApiVersioning.Domain.Entities;
using DemoEmployeeApiVersioning.Domain.Interfaces;

namespace DemoEmployeeApiVersioning.Application.Services;


public sealed class EmployeeService(IRepository<Employee> repository) : IEmployeeService
{
    public async Task<IReadOnlyList<Employee>> GetEmployeesAsync(CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }

    public async Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
    {
        await repository.AddAsync(employee, cancellationToken);
    }

    public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(employee, cancellationToken);
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = await repository.GetByIdAsync(id, cancellationToken);
        if (employee is not null)
            await repository.DeleteAsync(employee, cancellationToken);
    }
}