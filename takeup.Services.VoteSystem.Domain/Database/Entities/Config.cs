using System.ComponentModel.DataAnnotations;

namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class Config
	{
		[Key]
		public int Id { get; set; }

		public int AnswerId { get; set; }
		public long AnswerAt { get; set; }
	}
}
