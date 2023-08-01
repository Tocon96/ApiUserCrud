using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.DataAccess.Context
{
    public class ApiUserCrudDBContextFactory : IDesignTimeDbContextFactory<ApiUserCrudDBContext>
    {
        private string dbConnectionString;

        public ApiUserCrudDBContextFactory(string DbConnectionString) 
        { 
            this.dbConnectionString = DbConnectionString;
        }

        public ApiUserCrudDBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApiUserCrudDBContext>();
            options.UseSqlServer(dbConnectionString);
            return new ApiUserCrudDBContext(options.Options);
        }
    }
}