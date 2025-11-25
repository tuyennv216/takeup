using takeup.Services.VoteSystem.Domain.Datatype.Models;

namespace takeup.Services.VoteSystem.Domain.Datatype.ModelContexts
{
	public class VoteContext
	{
		public ActiveVote ActiveVotes { get; set; }
		public BatchQueue BatchQueue { get; set; }
		public DataCache DataCache { get; set; }

		public VoteContext() {
			ActiveVotes = new ActiveVote();
			BatchQueue = new BatchQueue();
			DataCache = new DataCache();
		}
		
	}
}
