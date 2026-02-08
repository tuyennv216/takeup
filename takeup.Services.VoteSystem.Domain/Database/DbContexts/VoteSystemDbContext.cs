using Microsoft.EntityFrameworkCore;
using takeup.Services.VoteSystem.Domain.Database.Entities;

namespace takeup.Services.VoteSystem.Domain.Database.DbContexts
{
	public class VoteSystemDbContext : DbContext
	{
		public VoteSystemDbContext(DbContextOptions<VoteSystemDbContext> options)
		: base(options) { }

		public DbSet<Topic> Topics { get; set; }
		public DbSet<Data> Data { get; set; }
		public DbSet<Vote> Votes { get; set; }

		public DbSet<Config> Configs { get; set; }
		public DbSet<PendingData> PendingData { get; set; }
		public DbSet<Snapshot> Snapshots { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Cấu hình Topic với auto increment
			modelBuilder.Entity<Topic>(entity =>
			{
				entity.HasKey(e => e.TopicId);
				entity.Property(e => e.TopicId)
					  .ValueGeneratedOnAdd(); // Auto increment

				entity.Property(e => e.TopicName)
					  .IsRequired()
					  .HasMaxLength(100);
			});

			// Cấu hình Data với auto increment
			modelBuilder.Entity<Data>(entity =>
			{
				entity.HasKey(e => e.DataId);
				entity.Property(e => e.DataId)
					  .ValueGeneratedOnAdd(); // Auto increment

				entity.Property(e => e.Message)
					  .IsRequired()
					  .HasMaxLength(100);
			});

			// Cấu hình Config với auto increment
			modelBuilder.Entity<Config>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id)
					  .ValueGeneratedOnAdd(); // Auto increment

				entity.HasData(new Config
				{
					Id = 1,
					AnswerId = 0,
					AnswerAt = 0,
				});
			});

			// Cấu hình Vote
			modelBuilder.Entity<Vote>(entity =>
			{
				entity.HasKey(e => new { e.IPHash, e.TopicId, e.DataId });
			});
		}
	}

	public class VoteSystemReadDbContext : VoteSystemDbContext
	{
		public VoteSystemReadDbContext(DbContextOptions<VoteSystemDbContext> options) : base(options)
		{
		}
	}
}
