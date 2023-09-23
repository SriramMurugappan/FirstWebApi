using DemoWebApi.Models;
using WebApiClientConsole;

Console.WriteLine("API CLient");
EmpViewModel employeeToUpdate = new EmpViewModel();
//{
//    EmpId = 5,
//    FirstName = "Update",
//    LastName = "Update",
//    City = "London",
//    BirthDate = new DateTime(1960,01,01),
//    HireDate = new DateTime(2000,01,01),
//    Title = "Manager"
//};
EmployeeAPIClient.UpdateEmployee(5, employeeToUpdate).Wait();