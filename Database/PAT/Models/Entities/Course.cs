namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class Course: BaseEntity
{
	/// <summary>
	/// Gets or sets the course's name.
	/// </summary>
	[Required]
	public string CourseName { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the course's Course code.
	/// </summary>
	public string CourseCode { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the course's credit amount.
	/// </summary>
	public double CourseCredits { get; set; }

	/// <summary>
	/// Gets or sets if the Course is deleted.
	/// </summary>
	public bool IsDeleted { get; set; }
}