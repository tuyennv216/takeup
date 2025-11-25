using System.ComponentModel.DataAnnotations;

namespace takeup.Infrastructure.Database.Abstraction
{
	public abstract class Entity<T> : IEntity<T>
	{
		[Key]
		public required T Id { get; set; }
	}

	public abstract class EntityTrack<T> : Entity<T>, IDeleted
	{
		public Boolean IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
	}

}
