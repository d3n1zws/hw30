
using Solution1.DataAccess.Contexts;
using Solution1.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Solution1.Business.Services;

public class EmployeeService
{
    private readonly AppDbContext context;
    public EmployeeService(AppDbContext _context)
    {
        context = _context;
    }
    public async Task<List<Employee>> GetAllEmployeesAsync() =>
        await context.Employees.Include(e => e.Department).ToListAsync();
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        var employee = await context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        if (employee is null)
        {
            throw new KeyNotFoundException("Employee tapilmadi");
        }
        return employee;
    }
    public async Task CreateEmployeeAsync(Employee employee)
    {
        if (employee is null)
        {
            throw new ArgumentException("Employee null gonderile bilmez");
        }
        var existingEmployee = await context.Employees.AnyAsync(e => e.Email == employee.Email);
        if (existingEmployee)
        {
            throw new InvalidOperationException("Employee email-i tekrarlanmamalidir");
        }
        var departmentExists = await context.Departments.AnyAsync(d => d.Id == employee.DepartmentId);
        if (!departmentExists)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
    }
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var existingEmployee = await GetEmployeeByIdAsync(employee.Id);
        if (existingEmployee is null)
        {
            throw new KeyNotFoundException("Employee tapilmadi");
        }
        var duplicateEmail = await context.Employees.AnyAsync(e => e.Email == employee.Email && e.Id != employee.Id);
        if (duplicateEmail)
        {
            throw new InvalidOperationException("Employee email-i tekrarlanmamalidir");
        }
        var departmentExists = await context.Departments.AnyAsync(d => d.Id == employee.DepartmentId);
        if (!departmentExists)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Email = employee.Email;
        existingEmployee.PhoneNumber = employee.PhoneNumber;
        existingEmployee.HireDate = employee.HireDate;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Status = employee.Status;
        existingEmployee.DepartmentId = employee.DepartmentId;
        existingEmployee.UpdatedAt = DateTime.UtcNow;
        await context.SaveChangesAsync();
    }
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (employee is null)
        {
            throw new KeyNotFoundException("Employee tapilmadi");
        }
        context.Employees.Remove(employee);
        await context.SaveChangesAsync();
    }
}
