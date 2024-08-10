using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ClientDBContextFactory : IDesignTimeDbContextFactory<ClientContext>
    {
        public ClientContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClientContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ClientDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ClientContext(optionsBuilder.Options);
        }
    }
}
