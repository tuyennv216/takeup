namespace takeup.Infrastructure.Database.Abstraction
{
	public interface IDeleted
	{
		public Boolean IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
