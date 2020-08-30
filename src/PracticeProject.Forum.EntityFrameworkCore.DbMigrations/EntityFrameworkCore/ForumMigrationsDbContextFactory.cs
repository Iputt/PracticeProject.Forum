﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PracticeProject.Forum.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ForumMigrationsDbContextFactory : IDesignTimeDbContextFactory<ForumMigrationsDbContext>
    {
        public ForumMigrationsDbContext CreateDbContext(string[] args)
        {
            ForumEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ForumMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ForumMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
