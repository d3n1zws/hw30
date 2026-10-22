using Solution1.Entity.Entities;
using Solution1.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Business.Dtos.EmployeeDto;

public record EmployeeUpdateDto
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}
