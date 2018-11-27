using CFSAspnetCoreService.Data.Repositories.Contracts;
using System;

namespace CFSAspnetCoreService.Data.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        int Complete();
    }
}
