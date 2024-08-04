using TerraCloud.Domain.Models.Animal;

namespace TerraCloud.Persistence.Interfaces.Repository.Animal
{
    public interface IAnimalRepository
    {
        Task<Domain.Models.Animal.Animal> GetAnimal(Guid animalId);
        Task<IEnumerable<Domain.Models.Animal.Animal>> GetAnimals();
        Task<AnimalUser> GetAnimalUser(Guid animalUserId, Guid userId);
        Task<AnimalUser> GetAnimalUserByAnimalId(Guid animalId, Guid userId);
        Task<IEnumerable<AnimalUser>> GetUserAnimals(Guid userId);
        Task AddAnimal(Domain.Models.Animal.Animal animal, AnimalUser animalUser);
        Task DeleteAnimal(Guid userAnimalId, Guid? animalId = null);
        void UpdateAnimal(Domain.Models.Animal.Animal animal);
    }
}
