# CS50 Library Project
This project is meant to give me a foundation to learn the basics of dotnet development as well as Azure Devops.

It's live on azure = https://codementor-library-app.azurewebsites.net/

## It focuses on a couple big topics:

## Dotnet Core 6
1. N-tier architecture
2. Database access + Entity framework
3. MVC + CSharp Views
4. Unit testing 

## Azure
1. SQL DB
2. App service
3. Application insights
4. Storage

## N-tier Architecture
[N-tier architecture](https://www.techopedia.com/definition/17185/n-tier-architecture)
![image](https://www.guru99.com/images/4-2016/042616_0902_NTierArchit1.png)

### Fundamental
- DataAccess (Libary.DataAccess)
- Services (Libary.Services)
- UI (Library.Web)
### Also
- Domain Models (universal)
- Utils (universal)

### When to separate services
- Business rules and domain rules

## Configuration
There's so much configuration 
- target project is the web project, all others depend on this one. solution specifies this as well 
- publishprofiles in the Properties/ folder. defines the build mode and other params like target output etc.

## Database Access
How to connect to the data source

### Fundamentals
- Swap out DB providers like `services.AddInMemoryLibraryDbContext();` in the `public void ConfigureServices(IServiceCollection services)` method
- using InMemory for testing and then connection to azure for live scenarios
- DataAccess deals with the access
- LINQ and EF for developing on top of DB
- For testing you need to be able to mock the DB, that's where the interface pattern is really useful. 

## Unit Testing
Testing methods, clesses etc.

```
[TestCase(null)]
[TestCase("")]
[TestCase(" ")]
```

### Naming convention
- [MethodName]_[Action]_[Result]

### Arrange Act Assert
- good convention for those who are maintaining code later

### When to write tests / how many
- each if statement can be a separate test
- if you are testing service class, service can not be a mock
- ock everything else (using interfaces)

### Notes

## Queries
- Complex joins, etc.   

## MVC
- More complex view models
- model binding 