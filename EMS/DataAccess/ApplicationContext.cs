using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataModels;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
    }
}
