![titulo](/docs/titulo.JPG)

# TDD-NetCore-XUnit
Simple TDD example with .Net Core and XUnit

## Technologies
- .Net Core 2.2
- XUnit
- TDD (Test Driven Development)
- Swagger 
- FluentValidation
- AutoMapper

## Objective
In this guide you will learn how to program automated tests in a .Net Core Web API by using XUnit.

## How it works
The APITest solution inside the "api" folder is composed by two layers: Presentation and Test.
The Presentation layer contains the Web API structure such as Controllers, Swagger, AutoMapper, Models and Validations.
The Test layer contains the unit tests.

![code01](/docs/code01.JPG)

### Presentation Layer
The User Controller has two methods: POST and PUT. Both follow the same steps:
- Copy the view model to the domain model by using the AutoMapper.
- Validate the domain model with FluentValidation and return a BadRequest in case of business exception.
- In case of success, if there's an object to return, the AutoMapper copies the domain model to another view model.

The POST method sets the user id to 1 by simulating the auto-incrementation in a database when a new user is created.

![code03](/docs/code03.JPG)

The PUT method does not make any operation.

![code04](/docs/code04.JPG)

### Test Layer
When using the Test Manager, 4 unit tests will be shown inside the XUnit project.
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

All the tests were successful.

![code10](/docs/code10.JPG)

Now, let's change the UserPutVM's age inside the TestPutUser_Ok from 33 to 15.

![code11](/docs/code11.JPG)

Run the test again and it will be a failure.

![code12](/docs/code12.JPG)

Why?
Because the "PostUserValidation" class (inside the "Post" method of the User Controller) was obligating the age to be equal or greater than 18.

![code13](/docs/code13.JPG)

The "PutUserValidation" class has the same rule and validates the user id as well.

![code14](/docs/code14.JPG)

## Conclusion

Although no database connection was present in this project, the tests would be the same because what matters is the validation of the view model and the verification of the result.