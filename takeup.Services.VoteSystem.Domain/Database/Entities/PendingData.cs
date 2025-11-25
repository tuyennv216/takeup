namespace takeup.Services.VoteSystem.Domain.Database.Entities
{
	public class PendingData : Data
	{
		public bool IsChecked { get; set; }
		public bool IsAccepted { get; set; }
	}
}
