using System.Collections.Concurrent;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;

namespace takeup.Services.VoteSystem.Domain.Datatype.Models
{
	public class ActiveVote
	{
		// Key: (HashIP, TopicId) - 20 bytes
		public readonly record struct VoteKey(Guid HashIP, int TopicId);

		// Value: (DataId, ExpireTicks) - 12 bytes  
		public readonly record struct VoteValue(int DataId, long ExpireTicks);

		// Main dictionary
		public ConcurrentDictionary<VoteKey, VoteValue> VoteDict { get; } = new();

		public int ClearExpiredItems()
		{
			var currentTicks = DateTime.UtcNow.Ticks;
			var removedCount = 0;

			var keys = VoteDict.Keys.ToArray();

			foreach (var key in keys)
			{
				if (VoteDict.TryGetValue(key, out var value) &&
					value.ExpireTicks <= currentTicks &&
					VoteDict.TryRemove(key, out _))
				{
					removedCount++;
				}
			}

			return removedCount;
		}

		public Dictionary<int, List<GetVotesTypes.VoteItem>> GetAllTopicVoteCountsConcurrent()
		{
			var currentTicks = DateTime.UtcNow.Ticks;
			var results = new ConcurrentDictionary<int, ConcurrentDictionary<int, int>>();

			Parallel.ForEach(VoteDict, kv =>
			{
				if (kvp.Value.ExpireTicks > currentTicks)
				{
					var topicId = kvp.Key.TopicId;
					var dataId = kvp.Value.DataId;

					var topicDict = results.GetOrAdd(topicId, new ConcurrentDictionary<int, int>());
					topicDict.AddOrUpdate(dataId, 1, (key, oldValue) => oldValue + 1);
				}
			});

			return results.ToDictionary(
				kv => kv.Key,
				kv => kv.Value
					.Select(dataCount => new GetVotesTypes.VoteItem
					{
						DataId = dataCount.Key,
						NumberOfVotes = dataCount.Value
					})
					.OrderByDescending(x => x.NumberOfVotes)
					.ThenBy(x => x.DataId)
					.ToList()
			);
		}
	}
}
