using DemoWebApi.Models;
using WebApiClientConsole;

Console.WriteLine("API CLient");
EmpViewModel employee = new EmpViewModel()
{
    EmployeeId = 15,
    FirstName = "William",
    LastName = "John Cooper",
    City = "London",
    BirthDate = new DateTime(1980, 01, 01),
    HireDate = new DateTime(2000, 01, 01),
    Title = "Manager"
};
//EmployeeAPIClient.UpdateEmployee(employee).Wait();
EmployeeAPIClient.DeleteEmployee(11).Wait();