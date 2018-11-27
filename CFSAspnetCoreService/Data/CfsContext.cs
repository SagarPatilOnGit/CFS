using CFSAspnetCoreService.Models;
using CFSAspnetCoreService.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CFSAspnetCoreService.Data
{
	public class CfsContext : DbContext
    {
	    public CfsContext(DbContextOptions<CfsContext> options)
		    : base(options)
	    { }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(@"Server=.; Database=CFS;Integrated Security=True;Trusted_Connection=True");
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new DepartmentsMap());
			modelBuilder.ApplyConfiguration(new EmployeesMap());
		}

		public DbSet<Employees> Employees { get; set; }
	    public DbSet<Departments> Departments { get; set; }
	}
}	
