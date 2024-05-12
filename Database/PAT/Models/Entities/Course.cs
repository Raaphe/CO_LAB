namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class Course: BaseEntity
{
	/// <summary>
	/// Gets or sets the course's name.
	/// </summary>
	[Required]
	[MaxLength(200)]
	public string CourseName { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the course's Course code.
	/// </summary>
	[MaxLength(200)]
	public string CourseCode { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the course's credit amount.
	/// </summary>
	public double CourseCredits { get; set; }

	/// <summary>
	/// Gets or sets if the Course is deleted.
	/// </summary>
	public bool IsDeleted { get; set; }


	/// <summary>
	/// Gets or sets The course's program.
	/// </summary>
	[Required]
	public virtual Program Program { get; set; } = new();

}