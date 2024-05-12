namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class Program: BaseEntity
{
	/// <summary>
	/// Gets or sets the Program's Code.
	/// </summary>
	[Required]
	[MaxLength(40)]
	public string ProgramCode { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the Program's Name.
	/// </summary>
	[Required]
	[MaxLength(200)]
	public string ProgramName { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the Program's Courses.
	/// </summary>
	public virtual IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();

	/// <summary>
	/// Gets or sets if the Program is deleted.
	/// </summary>
	public bool IsDeleted { get; set; }
}