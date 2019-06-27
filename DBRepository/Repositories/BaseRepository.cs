﻿using DBRepository.Factories;

namespace DBRepository.Repositories
{
    public class BaseRepository
    {
        protected string ConnectionString { get; set; }
        protected IRepositoryContextFactory RepositoryContextFactory { get; set; }

        protected BaseRepository(string connectionString, IRepositoryContextFactory repositoryContextFactory)
        {
            ConnectionString = connectionString;
            RepositoryContextFactory = repositoryContextFactory;
        }
    }
}