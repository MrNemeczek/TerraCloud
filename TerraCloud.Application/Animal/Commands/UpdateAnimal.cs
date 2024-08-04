using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Persistence.Interfaces.Repository.Animal;
using TerraCloud.Application.Exceptions.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Database;

namespace TerraCloud.Application.Animal.Commands
{
    public interface IUpdateAnimal
    {
        Task Execute(UpdateAnimalRequest request, Guid userId);
    }
    internal class UpdateAnimal : IUpdateAnimal
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public UpdateAnimal(IMapper mapper, IAnimalRepository animalRepository, IDatabaseRepository databaseRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
            _databaseRepository = databaseRepository;
        }

        public async Task Execute(UpdateAnimalRequest request, Guid userId)
        {
            var animalUser = await _animalRepository.GetAnimalUserByAnimalId(request.Id, userId);
            if (animalUser is null)
            {
                throw new AnimalNotFoundException(request.Id);
            }

            var animal = animalUser.Animal;
            if(animal.UserId != userId)
            {
                throw new AnimalNotOwnerException(animal.Id, userId);
            }

            animal = _mapper.Map(request, animal);
            _animalRepository.UpdateAnimal(animal);

            await _databaseRepository.SaveChangesAsync();
        }
    }
}
