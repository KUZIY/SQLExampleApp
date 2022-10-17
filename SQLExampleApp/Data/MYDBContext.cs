using SQLExampleApp.Data.Tables;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLExampleApp.Data
{
    public class MYDBContext : DbContext
    {
        public MYDBContext()
           : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MYDBContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
    }
}
