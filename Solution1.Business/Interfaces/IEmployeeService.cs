using Solution1.Business.Dtos.EmployeeDto;

namespace Solution1.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(EmployeeCreateDto employeeDto);
        Task DeleteEmployeeAsync(int id);
        Task<List<EmployeeReturnDto>> GetAllEmployeesAsync();
        Task<EmployeeReturnDto> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeDto);
    }
}