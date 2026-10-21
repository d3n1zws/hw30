using Solution1.DataAccess.Contexts;
using Solution1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Solution1.Business.Services;

public class DepartmentService
{
    private readonly AppDbContext context;
    public DepartmentService(AppDbContext _context)
    {
        context = _context;
    }
    public async Task<List<Department>> GetAllDepartmentsAsync() =>
        await context.Departments.ToListAsync();

    public async Task<Department> GetDepartmentByIdAsync(int id)
    {
        var department = await context.Departments.FindAsync(id);
        if (department is null)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        return department;
    }
    public async Task CreateDepartmentByIdAsync(Department department)
    {
        if (department is null)
        {
            throw new ArgumentException("department null gonderile bilmez");
        }
        var existingDepartment = await context.Departments.FirstOrDefaultAsync(d => d.Name == department.Name);
        if (existingDepartment != null)
        {
            throw new Exception("department name-i tekrarlanmamalidir");
        }
        await context.Departments.AddAsync(department);
    }
    public async Task UpdateDepartment(Department department)
    {
        var existingDepartment = GetDepartmentByIdAsync(department.Id);
        var duplicateDepartment = await context.Departments.FirstOrDefaultAsync(d => department.Name == d.Name);
        if (duplicateDepartment != null)
        {
            throw new InvalidOperationException("name unique olmalidir");
        }
        existingDepartment.Name = department.Name;
        existingDepartment.Description = department.Description;
        await context.SaveChangesAsync();
    }
    public async Task DeleteDepartmentAsync()
    {

    }
}
