using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFSService.Models
{
	public class Employees
	{
		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[MaxLength(50)]
		public string LastName { get; set; }

		[ForeignKey("Department")]
		public int DepartmentId { get; set; } //Foreign Key  
		public Department Department { get; set; } //Navigation Property  

	}
}