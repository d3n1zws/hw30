using Solution1.Entity.Entities;

namespace Solution1.Business.Dtos.DepartmentDto;

public record DepartmentReturnDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int Limit { get; set; }
    public List<Employee> Employees { get; set; }
}
