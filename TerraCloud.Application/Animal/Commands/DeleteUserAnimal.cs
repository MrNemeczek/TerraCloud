using TerraCloud.Application.Exceptions.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Application.Animal.Commands
{
    public interface IDeleteUserAnimal
    {
        Task Execute(Guid userAnimalId, Guid userId);
    }
    internal class DeleteUserAnimal : IDeleteUserAnimal
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteUserAnimal(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task Execute(Guid userAnimalId, Guid userId)
        {
            var animalUser = await _animalRepository.GetAnimalUser(userAnimalId, userId);
            if(animalUser is null)
            {
                throw new AnimalNotFoundException(userAnimalId);
            }

            var animal = await _animalRepository.GetAnimal(animalUser.AnimalId);
            if(animal is null)
            {
                throw new AnimalNotFoundException(animalUser.AnimalId);
            }

            if(animal.UserId == userId)
            {
                await _animalRepository.DeleteAnimal(userAnimalId, animal.Id);
            }
            else
            {
                await _animalRepository.DeleteAnimal(userAnimalId);
            }
        }
    }
}
