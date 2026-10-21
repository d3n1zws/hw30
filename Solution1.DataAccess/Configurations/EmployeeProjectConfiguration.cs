using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.DataAccess.Configurations;

public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        builder
            .ToTable("EmployeeProjects");

        builder
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        builder
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProject)
            .HasForeignKey(ep => ep.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
