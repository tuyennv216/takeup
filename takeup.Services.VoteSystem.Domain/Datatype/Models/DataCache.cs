using System.Collections.Concurrent;

namespace takeup.Services.VoteSystem.Domain.Datatype.Models
{
	public class DataCache
	{
		// Key: DataId - 4 bytes
		// Value: (Message, ExpireTicks) - variable size
		public readonly record struct CacheValue(string Message, long ExpireTicks);

		public ConcurrentDictionary<int, CacheValue> CacheDataDict { get; } = new();

		public int ClearExpiredItems()
		{
			var currentTicks = DateTime.UtcNow.Ticks;
			var removedCount = 0;

			var keys = CacheDataDict.Keys.ToArray();

			foreach (var key in keys)
			{
				if (CacheDataDict.TryGetValue(key, out var value) &&
					value.ExpireTicks <= currentTicks &&
					CacheDataDict.TryRemove(key, out _))
				{
					removedCount++;
				}
			}

			return removedCount;
		}
	}
}
