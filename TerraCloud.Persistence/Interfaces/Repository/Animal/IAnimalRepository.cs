using TerraCloud.Domain.Models.Animal;

namespace TerraCloud.Persistence.Interfaces.Repository.Animal
{
    public interface IAnimalRepository
    {
        Task<Domain.Models.Animal.Animal> GetAnimal(Guid animalId);
        Task<IEnumerable<Domain.Models.Animal.Animal>> GetAnimals();
        Task<IEnumerable<AnimalUser>> GetUserAnimals(Guid userId);
        Task AddAnimal(Domain.Models.Animal.Animal animal);
        Task DeleteAnimal(Guid animalId);
    }
}
