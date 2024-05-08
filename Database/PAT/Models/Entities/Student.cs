namespace PAT.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class Student: User
{
	[Required]
	public String Matricule { get; set; } = String.Empty;

	[Required]
	public Program? Program { get; set; } = new Program();

	[Required]
	public int Semester { get; set; } = 1;

	[Required]
	public virtual List<Availability>? Availabilities { get; set; }

	public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}