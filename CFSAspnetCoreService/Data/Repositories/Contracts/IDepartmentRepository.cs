using CFSAspnetCoreService.Models;

namespace CFSAspnetCoreService.Data.Repositories.Contracts
{
    public interface IDepartmentRepository : IRepository<Departments>
    {
        Departments GetFirstDepartment();
        Departments GetRecentDepartment();
    }
}