using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Application.Animal.Queries
{
    public interface IGetAnimal
    {
        Task<GetAnimalResponse> Execute(Guid animalId, Guid userId);
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

        public async Task<GetAnimalResponse> Execute(Guid animalId, Guid userId)
        {
            Domain.Models.Animal.Animal animal = await _animalRepository.GetAnimal(animalId);
            var response = _mapper.Map<GetAnimalResponse>(animal);

            response.IsOwner = userId.Equals(animal.UserId);
            response.IsAdded = animal.AnimalUsers.Any(x => x.UserId == userId);

            return response;
        }
    }
}
