using CFSAspnetCoreService.Data.Repositories;
using CFSAspnetCoreService.Data.Repositories.Contracts;

namespace CFSAspnetCoreService.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CfsContext _context;
        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public UnitOfWork(CfsContext context)
        {
            _context = context;
            Department = new DepartmentRepository(_context);
            Employee = new EmployeeRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
