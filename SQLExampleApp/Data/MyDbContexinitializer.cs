using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLExampleApp.Data
{
    public class MyDbContexinitializer : SqliteDropCreateDatabaseAlways<MYDBContext>
    {
        public MyDbContexinitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        protected override void Seed(MYDBContext context)
        { 
         }
    }
}
