using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.Interfaces.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Application.Animal.Queries
{
    internal class GetAnimals : IGetAnimals
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public GetAnimals(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAnimalResponse>> Execute()
        {
            IEnumerable<Domain.Models.Animal.Animal> animals = await _animalRepository.GetAnimals();
            IEnumerable<GetAnimalResponse> response = animals.Select(d => _mapper.Map<GetAnimalResponse>(d));

            return response;
        }
    }
}
