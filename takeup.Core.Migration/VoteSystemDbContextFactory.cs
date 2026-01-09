using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;

namespace takeup.Services.VoteSystem.Domain.Database
{
	public class VoteSystemDbContextFactory : IDesignTimeDbContextFactory<VoteSystemDbContext>
	{
		public VoteSystemDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<VoteSystemDbContext>();

			optionsBuilder.UseSqlite("Data Source=D:\\App10\\database\\votesystem.db");

			return new VoteSystemDbContext(optionsBuilder.Options);
		}
	}
}