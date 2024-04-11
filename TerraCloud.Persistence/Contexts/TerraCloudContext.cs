using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Domain.Models.Animal;
using TerraCloud.Domain.Models.Device;
using TerraCloud.Domain.Models.User;
using TerraCloud.Persistence.Configurations.Animal;
using TerraCloud.Persistence.Configurations.Device;
using TerraCloud.Persistence.Configurations.User;

namespace TerraCloud.Persistence.Contexts
{
    public class TerraCloudContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }

        public TerraCloudContext(DbContextOptions<TerraCloudContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
            modelBuilder.ApplyConfiguration(new UserDeviceConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
        }
    }
}
