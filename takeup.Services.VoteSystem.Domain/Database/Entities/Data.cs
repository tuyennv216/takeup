using System.ComponentModel.DataAnnotations;

namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class Data
	{
		[Key]
		public int DataId { get; set; }					// Primary Key, auto-increment
		public required string Message { get; set; }    // Text
	}
}
