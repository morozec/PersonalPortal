using Microsoft.EntityFrameworkCore;

namespace DBRepository.Factories
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        public RepositoryContext CreateDbContext(string connectionString)
        {
            var optionBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new RepositoryContext(optionBuilder.Options);
        }
    }
}