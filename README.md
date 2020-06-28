# AccountWebApi

AccountWebApi is an ASP.NetCore Web application that allows a user to view their accounts
and subsequently view transaction on every account they hold.
Functionalities Available
- View Account List
- View Account Transactions

#### Environment Setup

AccountWebApi application uses an in built SQLite database and entiity framework. Everytime the application is started, a setup method is called. 
The database file will be deleted if existing. It then creates a new database file and populates them with some mock data for testing.
The application can be integrated to any database. This can be configured to use any supported database by updating the DB details in OnConfiguring
method of AccountDBContext


#### Dotnet Core & Nuget Packages Installed

- DotnetCore Version : 3.1 
- Micrososft.EntityFrameworkCore(3.1.5)
- Micrososft.EntityFrameworkCore.Sqlite(3.1.5)
- Micrososft.EntityFrameworkCore.Tools(3.1.5)
- SwashBuckle.AspNetCore(5.5.1)

#### Swagger

Swagger is integrated into the application. The launch url of the application is configured as the swagger URL.
All the endpoints and schema details are available in below URL once the application is running:
URL : https://localhost:44327/swagger
Api can be tested out in Swagger with the below sample data.

- CustomerId: 101, 102, 103, 104
- AccountNumber : 123-2223-212


#### Unit Testing

AccountWebApiTest is the unit testing project created for AccountWebApi. The project uses Xunit for unit testing.

Run Unit Test Cases.

1. Righ click on the AccountWebApiTest project.
2. Click Run Tests.

Sample Output of Unit Test
--------------------------
AccountWebApiTest
  Tests in group: 4
   Total Duration: 12 ms

Outcomes
   4 Passed
