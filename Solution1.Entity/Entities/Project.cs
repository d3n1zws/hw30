using Solution1.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Entity.Entities;

public class Project : AuditEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Budget { get; set; }
    public List<EmployeeProject> EmployeeProject { get; set; }
    public Project()
    {
        EmployeeProject = new List<EmployeeProject>();
    }
}
