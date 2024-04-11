using TerraCloud.Application.Interfaces.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Application.Animal.Commands
{
    internal class DeleteAnimal : IDeleteAnimal
    {
        private readonly IAnimalRepository _animalRepository;

        public DeleteAnimal(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task Execute(string animalId)
        {
            await _animalRepository.DeleteAnimal(Guid.Parse(animalId));
        }
    }
}
