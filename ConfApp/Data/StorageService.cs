using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfApp.Data
{
    public partial class StorageService : DbContext, IStorageService
    {
        private readonly IConfiguration configuration;

        public StorageService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration.GetConnectionString("SqLiteConnection");
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
