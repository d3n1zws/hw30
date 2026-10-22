using Solution1.Business.Dtos.DepartmentDto;
using Solution1.Entity.Entities;
using Solution1.Entity.Enums;

namespace Solution1.Business.Dtos.EmployeeDto;

public record EmployeeReturnDto 
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    public int DepartmentId { get; set; }
    public DepartmentReturnDto DepartmentDto { get; set; } = null!;
}
