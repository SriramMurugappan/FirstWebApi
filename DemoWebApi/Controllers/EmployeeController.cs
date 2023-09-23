using DemoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/ListAllEmployees")]
        public IEnumerable<EmpViewModel> ListAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            IEnumerable<EmpViewModel> empList = _repositoryEmployee.Lister(employees);
            return empList;
        }
        [HttpGet("/FindEmployee")]
        public EmpViewModel FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.GetEmployeeById(id);
            EmpViewModel empList = _repositoryEmployee.Viewer(employeeById);
            return empList;
        }
        [HttpPost("/AddEmployee")]
        public string AddEmployee(EmpViewModel newEmployeeView)
        {
            Employee newEmployee = _repositoryEmployee.ViewToEmp(newEmployeeView);
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }
        [HttpPut("/ModifyEmployee")]
        public Employee ModifyEmployee(int id, [FromBody] EmpViewModel newEmployeeView)
        {
            Employee newEmployee = _repositoryEmployee.GetEmployeeById(id);
            newEmployee = _repositoryEmployee.ViewToEmp(newEmployeeView);
            _repositoryEmployee.UpdateEmployee(newEmployee);
            return newEmployee;
        }
        [HttpDelete("/DeleteEmployee")]
        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }
        /*[HttpGet]
        public IEnumerable<EmpViewModel> GetAllEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            var empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = (DateTime)emp.BirthDate,
                    HireDate = (DateTime)emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = (int)emp.ReportsTo
                }
                ).ToList();
            return empList;
        }
        // GET: api/Employee/5
        [HttpGet("{id}")]
        public List<Employee> GetEmployees(int id)
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmployees();
            return employees;
        }
        // POST: api/Employee
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeById(id);
            return employees;
        }
        /*public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(); // Return a 400 Bad Request response if the request body is empty
            }
            _repositoryEmployee.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmployeeId }, employee); // Return the newly created employee as JSON
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null || id != employee.EmployeeId)
            {
                return BadRequest(); // Return a 400 Bad Request response if the request body is empty or the IDs do not match
            }
            _repositoryEmployee.UpdateEmployee(employee);
            return NoContent(); // Return a 204 No Content response
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _repositoryEmployee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(); // Return a 404 Not Found response if the employee is not found
            }
            _repositoryEmployee.DeleteEmployee(id);
            return NoContent(); // Return a 204 No Content response 
        }*/
    }
}
