using System.ComponentModel.DataAnnotations;

namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class Topic
	{
		[Key]
		public int TopicId { get; set; }				// Primary Key, auto-increment
		public required string TopicName { get; set; }	// Text
	}
}
