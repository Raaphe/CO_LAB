namespace PAT.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class Tutor: Student
{
	public bool IsValidated { get; set; }
}