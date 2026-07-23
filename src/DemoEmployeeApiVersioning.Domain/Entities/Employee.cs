using DemoEmployeeApiVersioning.Domain.Common;
using DemoEmployeeApiVersioning.Domain.Exceptions;

namespace DemoEmployeeApiVersioning.Domain.Entities;


public class Employee : BaseEntity
{
    private Employee()
    {
        // Required by ORM
    }

    public Employee(
        string firstName,
        string lastName,
        string department,
        string email)
    {

        ValidateName(firstName);

        ValidateName(lastName);

        FirstName = firstName;

        LastName = lastName;

        Department = department;

        Email = email;
    }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Department { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string? Phone { get; private set; }

    public DateTime DateOfJoining { get; private set; }

    public string FullName => $"{FirstName} {LastName}";

    public void UpdateDepartment(
        string department)
    {

        if (string.IsNullOrWhiteSpace(department))
        {
            throw new DomainException(
                "Department cannot be empty.");
        }


        Department = department;

        UpdateModifiedDate();
    }

    public void UpdateContactInformation(
        string email,
        string? phone)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new DomainException(
                "Email is required.");
        }

        Email = email;

        Phone = phone;

        UpdateModifiedDate();
    }

    private static void ValidateName(
        string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(
                "Employee name cannot be empty.");
        }
    }

}