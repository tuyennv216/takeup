using System.ComponentModel.DataAnnotations;

namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class Vote
	{
		[Key]
		public int VoteId { get; set; }					// Primary Key, auto-increment
		public Guid IPHash { get; set; }
		public int TopicId { get; set; }
		public int DataId { get; set; }
		public long ExpiredAt { get; set; }
	}
}
