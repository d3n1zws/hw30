using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Business.Dtos.DepartmentDto;

public record DepartmentUpdateDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Location { get; set; }
}
