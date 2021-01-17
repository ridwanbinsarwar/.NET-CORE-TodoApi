using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataAccessLogic.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:SQLConnection");
            sqlConnectionString = appSetting.Value;

            var appSettingC = root.GetSection("ConnectionStrings:CassandraConnection");
            CassandraConnectionString = appSettingC.Value;
        }
        public string sqlConnectionString { get; set; }
        public string CassandraConnectionString { get; set; }

    }
}
