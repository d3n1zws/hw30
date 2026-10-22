using Solution1.Entity.Entities;

namespace Solution1.Business.Dtos.DepartmentDto;

public record DepartmentCreateDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Location { get; set; }
    public int Limit { get; set; }
}
