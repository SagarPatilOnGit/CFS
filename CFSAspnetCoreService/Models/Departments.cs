using System.ComponentModel.DataAnnotations;

namespace CFSAspnetCoreService.Models
{
	public class Departments
    {
	    [Required]
	    [Key]
	    public int Id { get; set; }
	    public string Name { get; set; }
	}
}
