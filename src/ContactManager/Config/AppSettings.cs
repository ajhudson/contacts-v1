using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Config
{
    public class AppSettings : IAppSettings
    {
        private readonly string title;

        private readonly string connectionString;

        public AppSettings(IConfiguration configuration)
        {
            this.title = configuration.GetValue<string>("AppSettings:Title");
            this.connectionString = configuration.GetValue<string>("AppSettings:ConnectionString");

        }
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }
    }
}
