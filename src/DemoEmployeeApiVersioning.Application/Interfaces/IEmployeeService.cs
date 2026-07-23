using DemoEmployeeApiVersioning.Domain.Entities;

namespace DemoEmployeeApiVersioning.Application.Interfaces;


public interface IEmployeeService
{
    Task<IReadOnlyList<Employee>> GetEmployeesAsync(CancellationToken cancellationToken);
    Task<Employee?> GetEmployeeAsync(Guid id, CancellationToken cancellationToken);
    Task CreateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
    Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);
    Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
}