using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Entity.Entities.Common;

public class AuditEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
