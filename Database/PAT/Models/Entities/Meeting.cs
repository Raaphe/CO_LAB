using System.ComponentModel.DataAnnotations;

namespace PAT.Models.Entities;

public class Meeting : BaseEntity
{
	[Required]
	public virtual Tutor? Tutor { get; set; }

	[Required]
	public virtual Tutee? Tutee { get; set; }

	[Required]
	public DayOfWeek DayOfWeek { get; set; }

	[Required]
	public TimeSpan StartTime { get; set; }

	[Required]
	public TimeSpan EndTime { get; set; }

	[Required]
	public Boolean IsDeleted { get; set; } = false;
}
