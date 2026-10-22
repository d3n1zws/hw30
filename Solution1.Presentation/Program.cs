using Microsoft.Extensions.DependencyInjection;
using Solution1.Business.Mapping;
using Solution1.Business.Services;
using Solution1.DataAccess.Contexts;
using System.Collections.Specialized;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<AppDbContext>();
serviceCollection.AddScoped<DepartmentService>();
serviceCollection.AddScoped<EmployeeService>();
serviceCollection.AddAutoMapper(opt =>
{
    opt.AddProfile<DepartmentProfile>();
    opt.AddProfile<EmployeeProfile>();
});
serviceCollection.AddLogging();

var serviceProvider = serviceCollection.BuildServiceProvider();
var departmentService = serviceProvider.GetRequiredService<DepartmentService>();
var departments = await departmentService.GetAllDepartmentsAsync();
foreach (var department in departments)
{
    Console.WriteLine(department.Name);
}