![titulo](/docs/titulo.JPG)

# TDD-NetCore-XUnit

Simple TDD example with .Net Core and xUnit

## Technologies

- .Net Core 2.2
- xUnit
- TDD (Test Driven Development)
- Swagger
- FluentValidation
- AutoMapper

## Objective

In this guide you will learn how to program automated tests in a .Net Core Web API by using [xUnit](https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-dotnet-test).

## Behind The Code

The APITest solution inside the "api" folder is composed by two layers: Presentation and Test.
The Presentation layer contains the Web API structure such as Controllers, Models, [Swagger](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio), [AutoMapper](https://www.codeproject.com/Articles/1256100/Automapper-Using-NET-Core-API-2-1) and [FluentValidation](https://www.c-sharpcorner.com/article/using-fluentvalidation-in-asp-net-core/).
The Test layer contains the unit tests.

![code01](/docs/code01.JPG)

### Presentation Layer

The User Controller has two methods: Post and Put. Both follow the same steps:

- Copy the view model to the domain model by using the AutoMapper.
- Validate the domain model with FluentValidation and return a BadRequest in case of business exception.
- In case of success, if there's an object to return, the AutoMapper copies the domain model to another view model.

The POST method sets the user id to 1 by simulating the auto-incrementation in a database when a new user is created.

![code03](/docs/code03.JPG)

The PUT method does not return an object.

![code04](/docs/code04.JPG)

### Test Layer

When using the Test Manager, 4 unit tests will be shown inside the xUnit project.
The "TestPostUser_BadRequest" and "TestPostUser_Ok" methods will simulate a POST request to the User Controller expecting business exception ("BadRequest") and success ("Ok"), respectively.
The "TestPutUser_BadRequest" and "TestPutUser_Ok" methods do the same but as a PUT request.

![code02](/docs/code02.JPG)

All the methods have the same behavior:

- Create an AutoMapper object.
- Instantiate the User Controller and the User view model.
- Run the Controller method and receive the result.
- Check if the result is the same as expected.

TestPostUser_BadRequest

![code05](/docs/code05.JPG)

TestPostUser_Ok

![code06](/docs/code06.JPG)

TestPutUser_BadRequest

![code07](/docs/code07.JPG)

TestPutUser_Ok

![code08](/docs/code08.JPG)

## How to run the project

In the Test Manager, click with the right button over "UnitTestUser" and debug or run the selected tests.

![code09](/docs/code09.JPG)

All the tests will be successful.

![code10](/docs/code10.JPG)

Now, let's change the UserPutVM's age from 33 to 15 and remove the id inside the "TestPutUser_Ok" method.

![code11](/docs/code11.JPG)

Run the test again and there will be a failure.

![code12](/docs/code12.JPG)

Why?
Because the "PutUserValidation" class (inside the "Put" method of the User Controller) was checking if the id was greater than zero.

![code14](/docs/code14.JPG)

As it was using the same rules from the "PostUserValidation" class, the age had to be equal or greater than 18.

![code13](/docs/code13.JPG)

## Swagger

Now, let's check how the business exception will be treated outside the xUnit.

Run the API and access the Swagger page.

![swagger01](/docs/swagger01.JPG)

The Put method has the same example used in the "TestPutUser_Ok" method.

![swagger02](/docs/swagger02.JPG)

Remove the id and change the age as done before.

![swagger03](/docs/swagger03.JPG)

Execute the method and the business exception will be described like this:

![swagger04](/docs/swagger04.JPG)

## Conclusion

Although no database connection was present in this project, it was possible to test POST and PUT requests to create and update a user because the unit tests validate the view models and the results.
