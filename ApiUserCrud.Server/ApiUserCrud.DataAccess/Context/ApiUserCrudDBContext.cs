using ApiUserCrud.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUserCrud.DataAccess.Context
{
    public class ApiUserCrudDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public ApiUserCrudDBContext(DbContextOptions options) : base(options) { }
    }
}
