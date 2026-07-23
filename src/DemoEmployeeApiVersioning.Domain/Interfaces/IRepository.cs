namespace DemoEmployeeApiVersioning.Domain.Interfaces;


public interface IRepository<T>
    where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync(
        CancellationToken cancellationToken);

    Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken);

    Task AddAsync(
        T entity,
        CancellationToken cancellationToken);

    Task UpdateAsync(
        T entity,
        CancellationToken cancellationToken);

    Task DeleteAsync(
        T entity,
        CancellationToken cancellationToken);
}