using Solution1.Entity.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution1.Entity.Entities;

public class EmployeeProject : BaseEntity
{
    [NotMapped]
    public override int Id { get => base.Id; set => base.Id = value; }
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
}
