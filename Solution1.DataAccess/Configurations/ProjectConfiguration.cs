using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.DataAccess.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(p => p.Description)
            .HasMaxLength(500);

        builder
            .Property(p => p.StartDate)
            .IsRequired();

        builder
            .Property(p => p.EndDate)
            .IsRequired(false);

        builder
            .Property(p => p.Budget)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder
            .HasMany(p => p.EmployeeProject)
            .WithOne(ep => ep.Project)
            .HasForeignKey(ep => ep.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
