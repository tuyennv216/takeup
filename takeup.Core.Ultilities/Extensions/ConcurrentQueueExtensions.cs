using System.Collections.Concurrent;

namespace takeup.Core.Ultilities.Extensions
{
	public static class ConcurrentQueueExtensions
	{
		/// <summary>
		/// Lấy tất cả item trong queue
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queue"></param>
		/// <returns></returns>
		public static List<T> DequeueAll<T>(this ConcurrentQueue<T> queue)
		{
			var list = new List<T>();
			while (queue.TryDequeue(out var item))
			{
				list.Add(item);
			}
			return list;
		}

		/// <summary>
		/// Lấy tất cả item trong queue, ghi đè và lấy item thêm vào cuối.
		/// Không giữ lại thứ tự trong queue.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="queue"></param>
		/// <returns></returns>
		public static List<T> DequeueAllKeepLast<T>(this ConcurrentQueue<T> queue, Func<T, object> keySelector)
		{
			var dict = new Dictionary<object, T>();
			while (queue.TryDequeue(out var item))
			{
				var key = keySelector.Invoke(item);
				dict[key] = item;
			}

			return dict.Values.ToList();
		}
	}
}
