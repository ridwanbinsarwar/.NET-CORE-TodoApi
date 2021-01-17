using DataAccessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLogic.DataContext
{
    class SqlDatabaseContext:DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<SqlDatabaseContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;

                
            }
            public DbContextOptionsBuilder<SqlDatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<SqlDatabaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }

        }

        public static OptionsBuild ops = new OptionsBuild();

        public SqlDatabaseContext(DbContextOptions<SqlDatabaseContext> options) : base(options) { }


        // DBsets here
        public DbSet<Todo> todos { get; set; }
        
    }
}
