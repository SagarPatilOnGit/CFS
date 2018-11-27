using CFSAspnetCoreService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFSAspnetCoreService.Data.Mappers
{
	public class DepartmentsMap : IEntityTypeConfiguration<Departments>
	{
		public void Configure(EntityTypeBuilder<Departments> builder)
		{
			builder.ToTable("Departments");
			builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
			builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
		}
	}
}
