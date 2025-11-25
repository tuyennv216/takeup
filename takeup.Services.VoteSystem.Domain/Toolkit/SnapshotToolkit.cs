using BinaryContainer2.Converter;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;

namespace takeup.Services.VoteSystem.Domain.Toolkit
{
	public static class SnapshotToolkit
	{
		// Key là TopicId, Value là [DataId1, NumberOfVote1, DataId2, NumberOfVote2, ...]
		/// <summary>
		/// Tuần tự voteDict thành byte[]
		/// </summary>
		/// <param name="voteContext"></param>
		/// <returns></returns>
		public static byte[] SerializeData(VoteContext voteContext)
		{
			Dictionary<int, int[]>? data = voteContext.ActiveVotes.VoteDict
				.GroupBy(v => v.Key.TopicId)
				.Where(g => g.Count() > 10)
				.ToDictionary(
					g => g.Key, // TopicId
					g =>
					{
						// Nhóm theo DataId trong topic này
						var dataVotes = g.GroupBy(v => v.Value.DataId)
									   .Select(dg => new
									   {
										   DataId = dg.Key,
										   Count = dg.Count()
									   })
									   .OrderByDescending(x => x.Count)
									   .ToList();

						// Tạo flat array: [DataId1, Count1, DataId2, Count2, ...]
						var flatArray = new int[dataVotes.Count * 2];
						for (int i = 0; i < dataVotes.Count; i++)
						{
							flatArray[i * 2] = dataVotes[i].DataId;      // DataId
							flatArray[i * 2 + 1] = dataVotes[i].Count;   // NumberOfVote
						}

						return flatArray;
					}
				);

			var result = BinConverter.GetBytes(data);

			return result;
		}

		/// <summary>
		/// Tạo dict từ byte[]
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static Dictionary<int, int[]>? DeserializeData(byte[] data)
		{
			var result = BinConverter.GetItem<Dictionary<int, int[]>?>(data);
			return result;
		}
	}
}
