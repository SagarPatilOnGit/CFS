using CFSAspnetCoreService.Data.Repositories.Contracts;
using CFSAspnetCoreService.Models;
using System.Linq;

namespace CFSAspnetCoreService.Data.Repositories
{
    public class DepartmentRepository : Repository<Departments>, IDepartmentRepository
    {
        public DepartmentRepository(CfsContext cfsContext) : base(cfsContext)
        {
        }
        public Departments GetFirstDepartment()
        {
            return _cfsContext.Departments.OrderBy(x => x.Id).FirstOrDefault();
        }

        public Departments GetRecentDepartment()
        {
            return _cfsContext.Departments.OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
