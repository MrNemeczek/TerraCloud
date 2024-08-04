using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Application.Animal.Queries
{
    public interface IGetAnimal
    {
        Task<GetAnimalResponse> Execute(Guid animalId);
    }
    internal class GetAnimal : IGetAnimal
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public GetAnimal(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<GetAnimalResponse> Execute(Guid animalId)
        {
            Domain.Models.Animal.Animal animal = await _animalRepository.GetAnimal(animalId);
            var response = _mapper.Map<GetAnimalResponse>(animal);

            return response;
        }
    }
}
