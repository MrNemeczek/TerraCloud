using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.Interfaces.Animal;
using TerraCloud.Domain.Models.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Database;

namespace TerraCloud.Application.Animal.Commands
{
    public interface IAddAnimalUser
    {
        Task Execute(AddAnimalUserRequest request, Guid userId);
    }
    internal class AddAnimalUser : IAddAnimalUser
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AddAnimalUser(IDatabaseRepository databaseRepository, IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _databaseRepository = databaseRepository;
            _mapper = mapper;
        }

        public async Task Execute(AddAnimalUserRequest request, Guid userId)
        {
            var animal = _mapper.Map<Domain.Models.Animal.Animal>(request);
            animal.UserId = userId;

            AnimalUser animalUser = new();
            animalUser.UserId = userId;
            
            await _animalRepository.AddAnimal(animal, animalUser);
            await _databaseRepository.SaveChangesAsync();
        }
    }
}
