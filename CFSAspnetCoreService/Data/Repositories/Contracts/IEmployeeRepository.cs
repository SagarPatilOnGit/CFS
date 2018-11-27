using CFSAspnetCoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CFSAspnetCoreService.Data.Repositories.Contracts
{
    public interface IEmployeeRepository: IRepository<Employees>
    {
        Employees GetFirstEmployee();
        Employees GetRecentEmployee();
        IEnumerable<Employees> GetEmployeesWithDepartment(Expression<Func<Employees,bool>> predicate);
        IEnumerable<Employees> GetEmployeesWithDepartment(int pageIndex, int pageSize);
    }
}
