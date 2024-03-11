using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Persistence.Configurations.User;

namespace TerraCloud.Persistence.Contexts
{
    public class TerraCloudContext : DbContext
    {
        public TerraCloudContext(DbContextOptions<TerraCloudContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
