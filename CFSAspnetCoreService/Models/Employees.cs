using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFSAspnetCoreService.Models
{
	public class Employees
    {
	    [Required]
	    [Key]
	    public int Id { get; set; }

	    [Required]
	    public string FirstName { get; set; }

	    public string LastName { get; set; }
		
		public int DepartmentId { get; set; } //Foreign Key
		[ForeignKey("DepartmentId")]
		public Departments Departments { get; set; } //Navigation Property  
	}
}
