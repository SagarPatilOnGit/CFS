using CFSAspnetCoreService.Data.Repositories.Contracts;
using CFSAspnetCoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CFSAspnetCoreService.Data.Repositories
{
    public class EmployeeRepository : Repository<Employees>, IEmployeeRepository
    {        
        public EmployeeRepository(CfsContext cfsContext) : base(cfsContext)
        {
        }

        public IEnumerable<Employees> GetEmployeesWithDepartment(Expression<Func<Employees, bool>> predicate)
        {
            return _cfsContext.Employees
                    .Include(x => x.Departments)
                    .Where(predicate)
                    .OrderBy(x => x.Id)
                    .ToList();                 
        }

        public IEnumerable<Employees> GetEmployeesWithDepartment(int pageIndex, int pageSize = 10)
        {
            return _cfsContext.Employees
                    .Include(x => x.Departments)
                    .OrderBy(x => x.Id)
                    .Skip((pageIndex-1)*pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public Employees GetFirstEmployee()
        {
            return _cfsContext.Employees.OrderBy(x => x.Id).FirstOrDefault();
        }

        public Employees GetRecentEmployee()
        {
            return _cfsContext.Employees.OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
