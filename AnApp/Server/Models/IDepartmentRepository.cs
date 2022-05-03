using AnApp.Shared.Data;
using AnApp.Shared.Models;

namespace AnApp.Server.Models
{
    public interface IDepartmentRepository
    {
        PagedResult<Department> GetDepartments(string? name, int page);
        Task<Department?> GetDepartment(int Id);
        Task<Department> AddDepartment(Department department);
        Task<Department?> UpdateDepartment(Department department);
        Task<Department?> DeleteDepartment(int Id);
    }
}
