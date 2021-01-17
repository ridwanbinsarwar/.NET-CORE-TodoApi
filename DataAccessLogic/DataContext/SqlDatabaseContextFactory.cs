using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLogic.DataContext
{
    class SqlDatabaseContextFactory : IDesignTimeDbContextFactory<SqlDatabaseContext>
    {
        public SqlDatabaseContext CreateDbContext(string[] args)
        {
            /*Console.WriteLine(args);*/
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<SqlDatabaseContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
           
            return new SqlDatabaseContext(opsBuilder.Options);
        }
    }
}
