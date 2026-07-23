using Asp.Versioning;
using DemoEmployeeApiVersioning.Application.DTOs.V1;
using DemoEmployeeApiVersioning.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmployeeApiVersioning.WebAPI.Controllers.V1;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public sealed class EmployeesController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get(CancellationToken cancellationToken)
    {
        var employees = await employeeService.GetEmployeesAsync(cancellationToken);

        var result = employees.Select(x => new EmployeeDto
        {
            Id = x.Id,
            Name = x.FullName
        });

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmployeeDto>> Get(Guid id, CancellationToken cancellationToken)
    {
        var employee = await employeeService.GetEmployeeAsync(id, cancellationToken);

        if (employee is null)
            return NotFound();

        return Ok(new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.FullName
        });
    }
}