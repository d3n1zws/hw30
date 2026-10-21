using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution1.Entity.Entities;
using Solution1.Entity.Enums;

namespace Solution1.DataAccess.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employees");

        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(e => e.LastName)
            .HasMaxLength(50);

        builder
            .Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder
            .Property(e => e.HireDate)
            .IsRequired();

        builder
            .Property(e => e.Salary)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder
            .Property(e => e.Status)
            .HasDefaultValue(EmployeeStatus.Active);

        builder
            .HasIndex(e => e.Email)
            .IsUnique();

        builder
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(e => e.EmployeeProjects)
            .WithOne(ep => ep.Employee)
            .HasForeignKey(ep => ep.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
