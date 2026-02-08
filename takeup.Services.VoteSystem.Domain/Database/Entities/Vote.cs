namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class Vote
	{
		public Guid IPHash { get; set; }
		public int TopicId { get; set; }
		public int DataId { get; set; }
	}
}
