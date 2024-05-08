namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

public class BaseEntity: ObservableValidator
{
	/// <summary>
	/// Base entity to provide common properties to other entities and allow it's usage in generic repositories.
	/// </summary>
	[Key]
	[Required]
	private int id;
	public int Id { get => id; set => SetProperty(ref id, value, true); }
}