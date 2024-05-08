namespace MauiTaskListApp.Models;

public class BaseEntity
{
	/// <summary>
	/// Base entity to provide common properties to other entities and allow it's usage in generic repositories.
	/// </summary>
	public int Id { get; set; }
}