using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraCloud.Persistence.Interfaces.Repository.Database
{
    public interface IDatabaseRepository
    {
        Task SaveChangesAsync();
    }
}
