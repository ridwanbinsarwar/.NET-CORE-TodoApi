using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLogic.DataContext
{
    class CassandraDatabaseConnection
    {
        private AppConfiguration settings { get; set; }

        public string CassandraConnectionString { get; set; }
        public CassandraDatabaseConnection()
        {
            settings = new AppConfiguration();
            CassandraConnectionString = settings.CassandraConnectionString;
        }

        public ISession Connect()
        {
            Cluster cluster = Cluster.Builder()
                     .AddContactPoints(CassandraConnectionString)
                     .Build();       
            ISession session = cluster.Connect();               
            session.Execute(new SimpleStatement("CREATE KEYSPACE IF NOT EXISTS space WITH replication = { 'class': 'SimpleStrategy', 'replication_factor': '1' }"));
            session.Execute(new SimpleStatement("USE space"));
            session.Execute(new SimpleStatement("CREATE TABLE IF NOT EXISTS Todo_id(Id uuid, Task text, Title text, Date timestamp, PRIMARY KEY(Id,Title)) WITH CLUSTERING ORDER BY ( Title ASC)"));      
            session.Execute(new SimpleStatement("Create INDEX IF NOT EXISTS DateIndex on todo_id(Date)"));

            return session;
        }

        

    }
}
