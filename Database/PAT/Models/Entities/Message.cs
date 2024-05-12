namespace PAT.Models.Entities;

using System.ComponentModel.DataAnnotations;

public class Message: BaseEntity
{
	/// <summary>
	/// Gets or sets the message's receiver Id.
	/// </summary>
	public int ReceiverId { get; set; }

	/// <summary>
	/// Gets or sets the message's senderId.
	/// </summary>
	public int SenderId { get; set; }

	/// <summary>
	/// Gets or sets the message's Content.
	/// </summary>
	[Required]
	[MaxLength(4000)]
	public string Content { get; set; } = string.Empty;
}