using Microsoft.EntityFrameworkCore;

namespace Homework10.DbModels
{
	public class ApplicationContext: DbContext
	{
		public DbSet<SolvingExpression> SolvingExpressions { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}