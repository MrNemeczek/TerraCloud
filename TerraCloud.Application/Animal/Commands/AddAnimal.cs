using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.Interfaces.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Database;

namespace TerraCloud.Application.Animal.Commands
{
    internal class AddAnimal : IAddAnimal
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AddAnimal(IDatabaseRepository databaseRepository, IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _databaseRepository = databaseRepository;
            _mapper = mapper;
        }

        public async Task Execute(AddAnimalRequest request)
        {
            var animal = _mapper.Map<Domain.Models.Animal.Animal>(request);
            await _animalRepository.AddAnimal(animal);
            await _databaseRepository.SaveChangesAsync();
        }
    }
}
