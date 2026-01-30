using System.Collections.Concurrent;
using takeup.Services.VoteSystem.Domain.Database.Entities;

namespace takeup.Services.VoteSystem.Domain.Datatype.Models
{
	public class BatchQueue
	{
		// For database batch operations
		public ConcurrentQueue<Topic> Topic_Add { get; } = new();
		public ConcurrentQueue<Topic> Topic_Update { get; } = new();

		public ConcurrentQueue<Data> Data_Add { get; } = new();
		public ConcurrentQueue<Data> Data_Update { get; } = new();

		public ConcurrentQueue<Vote> Vote_Add { get; } = new();
		public ConcurrentQueue<Vote> Vote_Update { get; } = new();
	}
}
