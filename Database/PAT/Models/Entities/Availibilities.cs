namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations.Schema;

public class Availability: BaseEntity
{
	public DayOfWeek DayOfWeek { get; set; }

	[Column(TypeName = "time")]
	public TimeSpan StartTime { get; set; }

	[Column(TypeName = "time")]
	public TimeSpan EndTime { get; set; }

	public virtual Student? Student { get; set; }
	public Boolean IsDeleted { get; set; } = false;
}