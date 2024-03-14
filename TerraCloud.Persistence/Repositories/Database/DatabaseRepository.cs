using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Persistence.Contexts;
using TerraCloud.Persistence.Interfaces.Repository.Database;

namespace TerraCloud.Persistence.Repositories.Database
{
    internal class DatabaseRepository : IDatabaseRepository
    {
        private readonly TerraCloudContext _context;

        public DatabaseRepository(TerraCloudContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
