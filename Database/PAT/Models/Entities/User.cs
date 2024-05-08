namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class User: BaseEntity
{
	/// <summary>
	/// Gets or sets the User's FirstName.
	/// </summary>
	[Required]
	public string FirstName { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the User's Lastname.
	/// </summary>
	[Required]
	public string LastName { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the User's email.
	/// </summary>
	[Required]
	public string Email { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the User's email.
	/// </summary>
	[Required]
	public string Password { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets whether the account is deleted.
	/// </summary>
	public bool IsDeleted { get; set; }

	/// <summary>
	/// Gets or sets the user's messages.
	/// </summary>
	[Required]
	public virtual ICollection<Message> Messages { get; set;} = new List<Message>();
}