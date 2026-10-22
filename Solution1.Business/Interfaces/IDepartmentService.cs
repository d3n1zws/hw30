using Solution1.Business.Dtos.DepartmentDto;

namespace Solution1.Business.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateDepartmentByIdAsync(DepartmentCreateDto departmentDto);
        Task DeleteDepartmentAsync(int id);
        Task<List<DepartmentReturnDto>> GetAllDepartmentsAsync();
        Task<DepartmentReturnDto> GetDepartmentByIdAsync(int id);
        Task UpdateDepartment(int id, DepartmentUpdateDto departmentDto);
    }
}