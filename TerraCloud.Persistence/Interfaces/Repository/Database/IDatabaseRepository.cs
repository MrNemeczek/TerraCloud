namespace TerraCloud.Persistence.Interfaces.Repository.Database
{
    public interface IDatabaseRepository
    {
        Task SaveChangesAsync();
    }
}
