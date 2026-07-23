using DemoEmployeeApiVersioning.Domain.Entities;

namespace DemoEmployeeApiVersioning.Infrastructure.Repositories;


public sealed class InMemoryDatabase
{
    public List<Employee> Employees { get; } = new();

    public InMemoryDatabase()
    {
        Seed();
    }

    private void Seed()
    {
        Employees.Add(new Employee(
            "John",
            "Smith",
            "IT Support Executive",
            "john.smith@morningstar.com"));

        Employees.Add(new Employee(
            "Alice",
            "Agen",
            "HR Manager",
            "alice.agen@morningstar.com"));
			
		Employees.Add(new Employee(
            "Jasinth",
            "Johnny",
            "Project Manager",
            "jasinth.johnny@morningstar.com"));	
			
		Employees.Add(new Employee(
            "Anni",
            "Stephen",
            "HR Executive",
            "anni.stephen@morningstar.com"));	
			
		Employees.Add(new Employee(
            "Rex",
            "George",
            "QA Manager",
            "rex.george@morningstar.com"));	
			
		Employees.Add(new Employee(
            "Rincy",
            "Renny",
            "Finance Manager",
            "rincy.renny@morningstar.com"));				
    }
}