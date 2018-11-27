using CFSAspnetCoreService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFSAspnetCoreService.Data.Mappers
{
	public class EmployeesMap : IEntityTypeConfiguration<Employees>
	{
		public void Configure(EntityTypeBuilder<Employees> builder)
		{
			builder.ToTable("Employees");
			builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
			builder.Property(a => a.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
			builder.Property(a => a.LastName).HasColumnName("LastName").HasMaxLength(50);
			builder.Property(a => a.DepartmentId).HasColumnName("DepartmentId").IsRequired();
		}
	}
}
