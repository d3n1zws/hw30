using Solution1.DataAccess.Contexts;
using Solution1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Solution1.Business.Dtos.DepartmentDto;
using AutoMapper;

namespace Solution1.Business.Services;

public class DepartmentService : IDepartmentService
{
    private readonly AppDbContext context;
    readonly IMapper mapper;
    public DepartmentService(AppDbContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    public async Task<List<DepartmentReturnDto>> GetAllDepartmentsAsync() =>
        await context.Departments.Select(d => mapper.Map<DepartmentReturnDto>(d)).ToListAsync();

    public async Task<DepartmentReturnDto> GetDepartmentByIdAsync(int id)
    {
        var department = await context.Departments.FindAsync(id);
        if (department is null)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        return mapper.Map<DepartmentReturnDto>(department);
    }
    public async Task CreateDepartmentByIdAsync(DepartmentCreateDto departmentDto)
    {
        if (departmentDto is null)
        {
            throw new ArgumentException("department null gonderile bilmez");
        }
        var existingDepartment = await context.Departments.FirstOrDefaultAsync(d => d.Name == departmentDto.Name);
        if (existingDepartment != null)
        {
            throw new Exception("department name-i tekrarlanmamalidir");
        }
        var department = mapper.Map<Department>(departmentDto);
        await context.Departments.AddAsync(department);
    }
    public async Task UpdateDepartment(int id, DepartmentUpdateDto departmentDto)
    {
        var existingDepartment = await GetDepartmentByIdAsync(id);
        var duplicateDepartment = await context.Departments.FirstOrDefaultAsync(d => departmentDto.Name == d.Name && d.Id != id);
        if (duplicateDepartment != null)
        {
            throw new InvalidOperationException("name unique olmalidir");
        }
        mapper.Map(departmentDto, existingDepartment);
        await context.SaveChangesAsync();
    }
    public async Task DeleteDepartmentAsync(int id)
    {
        var department = await context.Departments.FindAsync(id);
        if (department is null)
        {
            throw new KeyNotFoundException("Department tapilmadi");
        }
        context.Departments.Remove(department);
        await context.SaveChangesAsync();
    }
}
