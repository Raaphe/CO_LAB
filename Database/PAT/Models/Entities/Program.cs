namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class Program: BaseEntity
{
	/// <summary>
	/// Gets or sets the Program's Code.
	/// </summary>
	[Required]
	public string ProgramCode { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the Program's Name.
	/// </summary>
	[Required]
	public string ProgramName { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the Program's Courses.
	/// </summary>
	[Required]
	public virtual IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();

	/// <summary>
	/// Gets or sets if the Program is deleted.
	/// </summary>
	public bool IsDeleted { get; set; }
}