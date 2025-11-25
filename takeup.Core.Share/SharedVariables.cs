using System.Security.Cryptography;
using takeup.Core.Ultilities.Datatype;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;

namespace takeup.Core.Share
{
	public static class SharedVariables
	{
		public static int CommitDatabaseJob_AnswerId { get; set; }
		public static long CommitDatabaseJob_NextAnswerTime { get; set; }

		public static void UpdateCommitDatabaseJob(DateTimeOffset nextAnswerTime)
		{
			CommitDatabaseJob_AnswerId = RandomNumberGenerator.GetInt32(Int32.MinValue, Int32.MaxValue);
			CommitDatabaseJob_NextAnswerTime = nextAnswerTime.Ticks;
		}

		public static TimeBackoff AnalystVotes_TimeBackoff { get; set; } = new();
		public static Dictionary<int, List<GetVotesTypes.VoteItem>> AnalystVotes {  get; set; } = new();
	}
}
