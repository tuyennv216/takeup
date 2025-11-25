using System.ComponentModel.DataAnnotations;

namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class Snapshot
	{
		[Key]
		public long DateTimeHour { get; set; }		// Định ngày ngày-giờ dạng Ticks
		public required byte[] Data { get; set; }	// Dữ liệu snapshot dưới dạng Binary
	}
}
