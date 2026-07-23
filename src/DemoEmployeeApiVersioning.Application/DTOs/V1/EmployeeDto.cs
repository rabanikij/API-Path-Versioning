namespace DemoEmployeeApiVersioning.Application.DTOs.V1;


public sealed class EmployeeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}