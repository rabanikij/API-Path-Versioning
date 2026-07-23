using Asp.Versioning;
using DemoEmployeeApiVersioning.Application.DTOs.V2;
using DemoEmployeeApiVersioning.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmployeeApiVersioning.WebAPI.Controllers.V2;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public sealed class EmployeesController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get(CancellationToken cancellationToken)
    {
        var employees = await employeeService.GetEmployeesAsync(cancellationToken);

        var result = employees.Select(x => new EmployeeDto
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Department = x.Department
        });

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EmployeeDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);

        if (employee is null)
            return NotFound();

        return Ok(new EmployeeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Department = employee.Department
        });
    }
}