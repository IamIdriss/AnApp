using AnApp.Shared.Data;
using AnApp.Shared.Models;

namespace AnApp.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task<Department> AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> DeleteDepartment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> GetDepartment(int Id)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Department> GetDepartments(string? name, int page)
        {
            throw new NotImplementedException();
        }

        public Task<Department?> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
