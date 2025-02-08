using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RashutSdotHateufa.Data;
using RashutSdotHateufa.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RashutSdotHateufa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Get All Employees with Department Name & Latest Salary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployees()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries) // ✅ Include salary records
                .Select(e => new
                {
                    e.EmployeeId,
                    e.Name,
                    DepartmentName = e.Department.Name,
                    LatestSalary = e.Salaries.OrderByDescending(s => s.PaymentDate).Select(s => s.Amount).FirstOrDefault()
                })
                .ToListAsync();

            return Ok(employees);
        }

        // ✅ Get a Single Employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries)
                .Where(e => e.EmployeeId == id)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.Name,
                    DepartmentName = e.Department.Name,
                    Salaries = e.Salaries.OrderByDescending(s => s.PaymentDate).Select(s => new
                    {
                        s.Amount,
                        s.PaymentDate
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // ✅ Create a New Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // ✅ Update an Existing Employee
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // ✅ Delete an Employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ Helper Method to Check if Employee Exists
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
