using DemoEmployeeApiVersioning.Domain.Entities;
using DemoEmployeeApiVersioning.Domain.Interfaces;

namespace DemoEmployeeApiVersioning.Infrastructure.Repositories;


public sealed class EmployeeRepository(InMemoryDatabase database) : IRepository<Employee>
{
    public Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<Employee> employees = database.Employees;
        return Task.FromResult(employees);
    }

    public Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var employee = database.Employees.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(employee);
    }

    public Task AddAsync(Employee entity, CancellationToken cancellationToken)
    {
        database.Employees.Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Employee entity, CancellationToken cancellationToken)
    {
        var existing = database.Employees.FirstOrDefault(x => x.Id == entity.Id);

        if (existing is not null)
        {
            var index = database.Employees.IndexOf(existing);
            database.Employees[index] = entity;
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Employee entity, CancellationToken cancellationToken)
    {
        database.Employees.Remove(entity);
        return Task.CompletedTask;
    }
}