
using Solution1.DataAccess.Contexts;
using Solution1.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Solution1.Business.Dtos.EmployeeDto;
using AutoMapper;
using Solution1.Business.Interfaces;

namespace Solution1.Business.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext context;
    private readonly IMapper mapper;
    public EmployeeService(AppDbContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    public async Task<List<EmployeeReturnDto>> GetAllEmployeesAsync()
    {
        var employees = await context.Employees.Include(e => e.Department).ToListAsync();
        return mapper.Map<List<EmployeeReturnDto>>(employees);
    }
    public async Task<EmployeeReturnDto> GetEmployeeByIdAsync(int id)
    {
        var employeeDto = await context.Employees.Select(e => mapper.Map<EmployeeReturnDto>(e)).Include(e => e.DepartmentDto).FirstOrDefaultAsync(e => e.Id == id);
        if (employeeDto is null)
        {
            throw new KeyNotFoundException("Employee tapilmadi");
        }
        return employeeDto;
    }
    public async Task CreateEmployeeAsync(EmployeeCreateDto employeeDto)
    {
        if (employeeDto is null)
        {
            throw new ArgumentException("Employee null gonderile bilmez");
        }
        var existingEmployee = await context.Employees.AnyAsync(e => e.Email == employeeDto.Email);
        if (existingEmployee)
        {
            throw new InvalidOperationException("Employee email-i tekrarlanmamalidir");
        }
        var departmentExists = await context.Departments.AnyAsync(d => d.Id == employeeDto.DepartmentId);
        if (!departmentExists)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        var employee = mapper.Map<Employee>(employeeDto);
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
    }
    public async Task UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeDto)
    {
        var existingEmployee = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        if (existingEmployee is null)
        {
            throw new KeyNotFoundException("Employee tapilmadi");
        }
        var duplicateEmail = await context.Employees.AnyAsync(e => e.Email == employeeDto.Email && e.Id != id);
        if (duplicateEmail)
        {
            throw new InvalidOperationException("Employee email-i tekrarlanmamalidir");
        }
        var departmentExists = await context.Departments.AnyAsync(d => d.Id == employeeDto.DepartmentId);
        if (!departmentExists)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        mapper.Map(existingEmployee, employeeDto);
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
