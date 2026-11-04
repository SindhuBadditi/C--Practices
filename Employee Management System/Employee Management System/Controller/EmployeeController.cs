using Employee_Management_System.Model;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controller
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=501,FirstName="Peter",LastName="Parker",Email="peter@gmail.com",PhoneNumber="9875641230",Department="IT",Designation="Software Developer",Salary=25000,DateOfJoining=new DateOnly(2025,10,03)},
            new Employee{Id=502,FirstName="Tony",LastName="Stark",Email="tony@gmail.com",PhoneNumber="8457963210",Department="HR",Designation="HR Executive",Salary=30000,DateOfJoining=new DateOnly(2026,11,02)}
        };
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            Employee employee = employees.FirstOrDefault(a => a.Id == id);
            if (employee==null)
            {
                return NotFound(new { Message = "Employee has not found." });
            }
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return NotFound(new { Message = "Employee has not found." });
            }
            employees.Add(employee);
            return employee;
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee updatedEmployee)
        {
            Employee? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(new { Message = "Employee not found." });
            }

            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.PhoneNumber = updatedEmployee.PhoneNumber;
            employee.Department = updatedEmployee.Department;
            employee.Designation = updatedEmployee.Designation;
            employee.Salary = updatedEmployee.Salary;
            employee.DateOfJoining = updatedEmployee.DateOfJoining;
            employee.IsActive = updatedEmployee.IsActive;

            return employee;
        }
        [HttpPatch("{id}")]
        public ActionResult<Employee> PatchEmployee(int id, Employee updatedData)
        {
            Employee? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound(new { Message = "Employee not found." });
            }

            if (!string.IsNullOrEmpty(updatedData.Department))
                employee.Department = updatedData.Department;

            if (!string.IsNullOrEmpty(updatedData.Designation))
                employee.Designation = updatedData.Designation;

            if (updatedData.Salary > 0)
                employee.Salary = updatedData.Salary;

            return employee;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employees.Remove(employee);

            return Ok("Employee deleted successfully");
        }
    }
}
