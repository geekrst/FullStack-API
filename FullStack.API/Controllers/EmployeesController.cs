using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStack.API.Models;
using FullStack.API.Data;
using Microsoft.EntityFrameworkCore;

namespace FullSTack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullStackDbContext.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployees([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            
            if(employee==null){
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]

        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id  = Guid.NewGuid();
            await _fullStackDbContext.Employees.AddAsync(employeeRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(id);  
            if(employee==null){
                return NotFound();
            }

            employee.Name = updateEmployeeRequest.Name;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Department = updateEmployeeRequest.Department;

            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
    {
        var employee = await _fullStackDbContext.Employees.FindAsync(id);
        if(employee==null)
        {
            return NotFound();
        }
        _fullStackDbContext.Employees.Remove(employee);
        await _fullStackDbContext.SaveChangesAsync();

        return Ok(employee);
    }
    }
}
