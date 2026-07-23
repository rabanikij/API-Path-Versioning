# API-Path-Versioning
API Versioning technique with Path (URI) Version approach - dotnet 8 Web Api demo


---


## Project Overview

**Employee API Versioning Demo** is a .NET 8 ASP.NET Core Web API sample application designed to demonstrate API Versioning using the **Path / URI Versioning** approach.

This project follows **Clean Architecture** principles and uses commonly adopted .NET technologies such as Swagger/OpenAPI to provide interactive API documentation.


## Objectives

The project demonstrates:

* Path / URI-based API Versioning
* Multiple API versions running simultaneously
* Breaking vs. non-breaking API changes
* Backward compatibility
* Version-specific API contracts
* Separation between Domain Model and API Contracts
* Clean Architecture implementation
* Swagger/OpenAPI integration
* InMemoryDatabase used for simplicity with seeded data


## Advantages of using **URI / Path Versioning**
*  Simple and easy to understand and develop
*  Easy to document
*  Easy to test
*  Clean separation and maintainability
*  Good for complex application expansion
*  Supported by almost every client

## Disadvantages
*  Multiple URLs for the same resource
*  Can lead to duplicated routes

## Best for: 
*  Public REST APIs, Fast growing applications



## Future Enhancements

The following enhancements can be gradually added in future iterations:

* FluentValidation
* AutoMapper
* Serilog logging
* Health Checks 
* Entity Framework Core
* SQL Server integration
* CQRS with MediatR
* Angular front-end
* API Deprecation support
* API Sunset headers
* Authentication using JWT
* API Rate Limiting
* Unit Tests
* Integration Tests
* Docker support
* GitHub Actions CI/CD
* Azure App Service deployment

---


## Architecture flow

```text
                Client
                   │
                   ▼
        ASP.NET Core Web API
                   │
                   ▼
            Application Layer
                   │
                   ▼
          Infrastructure Layer
                   │
                   ▼
              Domain Layer
```


---


## Project Solution Structure - Clean Architecture

```text
EmployeeApiVersioningDemo.sln

src
│
├── EmployeeApiVersioningDemo.Domain
│
├── EmployeeApiVersioningDemo.Application
│
├── EmployeeApiVersioningDemo.Infrastructure
│
└── EmployeeApiVersioningDemo.WebAPI
```


---


### Domain Layer

Responsibilities:
* Business entities
* Business rules
* Repository interfaces
* Domain exceptions

Dependencies: None


### Application Layer

Responsibilities:
* DTOs
* Services
* Mapping
* Business orchestration

Depends On: Domain


### Infrastructure Layer

Responsibilities:
* Repository implementation
* Data persistence
* Dependency Injection

Depends On: Domain


### Web API Layer

Responsibilities:
* Controllers
* Swagger
* API Versioning
* Exception Middleware
* Request handling

Depends On: Application, Infrastructure


---


## API Evolution strategies

### Version 1

**Description:**
Initial release of the Employee API. Start simple Employee portal with minimal data, so keep employee name field.

**Characteristics:**
* Initial API release
* Simple response model
* Single Name property


### Version 2

**Description:**
Breaking version of the API. During the next phase, it was identified and asked to have FirstName & LastName instead of empployee name, need to specify which department employee belongs to.

**Changes:**
* Name -replaced
* FirstName -added
* LastName -added
* Department -added


**Compatibility:**
*  Not backward compatible with Version 1.

**Reason:**
* Existing clients expect the Name property.
* Name Property has been removed.


### Version 3

**Description:**
Backward-compatible enhancement of Version 2. During the next phase, it was identified and asked to have Email, or phone contact details, also wanted to know Date of joining for tracking experience.

**Changes:**
* Email -added
* Phone -added
* DateOfJoining -added

**Compatibility:**
*  Backward compatible with Version 2.

**Reason:**
* Existing properties remain unchanged.
* Only optional fields are added.
* Older V2 clients ignore additional fields, but works.


---


## API Evolution map

```text
     +-------------+
     |  Version 1  |
     +-------------+
Name       |     First -cut
           │
           │ 
           ▼
     +-------------+
     |  Version 2  |
     +-------------+
FirstName  |     Breaking Change - split into FirstName & LastName
LastName   |
Department |
           │
           │ 
           ▼
     +-------------+
     |  Version 3  |
     +-------------+
FirstName  |     Non-Breaking Change
LastName   |
Department |
Email      │
Phone      │
DoJ        │
           │ 
           ▼
          Next version

```

---
