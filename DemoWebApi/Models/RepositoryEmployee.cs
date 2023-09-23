using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace DemoWebApi.Models
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context; // Simulate in-memory storage
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }
        public int AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            return _context.SaveChanges();
            /*if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            EntityState es = _context.Entry(employee).State; //trainer code start
            Console.WriteLine($"EntityState B4Add: {es.GetDisplayName()}");
            _context.Employees.Add(employee);
            es = _context.Entry(employee).State;
            Console.WriteLine($"EntityState After Add:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(employee).State;
            Console.WriteLine($"EntityState After SaveChanges : {es.GetDisplayName()}");
            return result; //trainer code ends*/
            
        }
        public int UpdateEmployee(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            return _context.SaveChanges();
            /*if (updatedEmployee == null) // our code start
            {
                throw new ArgumentNullException(nameof(updatedEmployee));
            }
            var existingEmployee = GetEmployeeById(updatedEmployee.EmployeeId);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException($"Employee with ID {updatedEmployee.EmployeeId} not found.");
            } our code ends */
            /*EntityState es = _context.Entry(updatedEmployee).State; //trainer code start
            Console.WriteLine($"EntityState B4Update: {es.GetDisplayName()}");
            _context.Employees.Update(updatedEmployee);
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After Update:{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(updatedEmployee).State;
            Console.WriteLine($"EntityState After SaveChanges : {es.GetDisplayName()}");
            return result; //trainer code ends*/


            
        }
        public int DeleteEmployee(int id)
        {
            //Employee emp = _context.Employees.Find(id);
            //_context.Employees.Remove(emp);
            //return _context.SaveChanges();

            /*Employee empToDelete = _context.Employees.Find(id);
            EntityState es = EntityState.Detached;
            int result = 0;
            
            if(empToDelete != null )
            {
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState B4Update: {es.GetDisplayName()}");
                _context.Employees.Remove(empToDelete);
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState After Update: {es.GetDisplayName()}");
                result = _context.SaveChanges();
                es = _context.Entry(empToDelete).State;
                Console.WriteLine($"EntityState After SaveChanges :{es.GetDisplayName()}");
            }
            return result;*/
            /* var employeeToRemove = GetEmployeeById(id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }*/


            Employee employeetodelete = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employeetodelete != null)
            {
                _context.Employees.Remove(employeetodelete);
                _context.SaveChanges();



            }
            else
            {
                return 0;
            }
            return 1;
        }
        public IEnumerable<EmpViewModel> Lister(List<Employee> employees)
        {
            List<EmpViewModel> empList = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmployeeId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
                ).ToList();
            return empList;
        }
        public EmpViewModel Viewer(Employee employee)
        {
            EmpViewModel employeeView = new EmpViewModel();
            employeeView.EmployeeId = employee.EmployeeId;
            employeeView.FirstName = employee.FirstName;
            employeeView.LastName = employee.LastName;
            employeeView.BirthDate = (DateTime)employee.BirthDate;
            employeeView.HireDate = (DateTime)employee.HireDate;
            employeeView.Title = employee.Title;
            employeeView.City = employee.City;
            employeeView.ReportsTo = (int)employee.ReportsTo;
            return employeeView;
        }
        public Employee ViewToEmp(EmpViewModel newEmployeeView)
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = newEmployeeView.FirstName;
            newEmployee.LastName = newEmployeeView.LastName;
            newEmployee.BirthDate = newEmployeeView.BirthDate;
            newEmployee.HireDate = newEmployeeView.HireDate;
            newEmployee.Title = newEmployeeView.Title;
            newEmployee.City = newEmployeeView.City;
            newEmployee.ReportsTo = newEmployeeView.ReportsTo;
            return newEmployee;
        }
    }
}
