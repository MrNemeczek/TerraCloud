namespace TerraCloud.Persistence.Interfaces.Repository.Animal
{
    public interface IAnimalRepository
    {
        Task<Domain.Models.Animal.Animal> GetAnimal(Guid animalId);
        Task<IEnumerable<Domain.Models.Animal.Animal>> GetAnimals();
        Task AddAnimal(Domain.Models.Animal.Animal animal);
        Task DeleteAnimal(Guid animalId);
    }
}
