namespace takeup.Infrastructure.Database.Abstraction
{
	public interface IEntity<T>
	{
		public T Id { get; set; }
	}
}
