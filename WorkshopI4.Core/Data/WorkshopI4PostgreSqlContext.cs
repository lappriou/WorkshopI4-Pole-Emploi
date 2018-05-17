using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopI4.Core.Data
{
    public class WorkshopI4PostgreSqlContext : DbContext
    {
        //private static string sqlConnectionString = "DataAccessPostgreSqlProvider":  "User ID=damienbod;Password=1234;Host=localhost;Port=5432;Database=damienbod;Pooling=true;"
        public WorkshopI4PostgreSqlContext(DbContextOptions<WorkshopI4PostgreSqlContext> options) :base(options)
        {
        }
         
        public DbSet<PageData> DataEventRecords { get; set; }
 
        public DbSet<TerminalData> Terminals { get; set; }
        public DbSet<InteractionData> Interactions { get; set; }
        public DbSet<PageData> Pages { get; set; }
        public DbSet<IndividualData> IndividualDatas { get; set; }
        public DbSet<ComponentUIData> Components { get; set; }
    }
}
