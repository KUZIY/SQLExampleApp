using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLExampleApp.Data
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetProviderFactory("System.Data.SQLite",SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);

            var providerService = (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices));
        }

        public DbConnection CreateConnection(string connectionstring) => new SQLiteConnection(connectionstring);
    }
}
