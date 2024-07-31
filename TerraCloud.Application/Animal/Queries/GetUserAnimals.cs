using AutoMapper;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Application.Animal.Queries
{
    public interface IGetUserAnimals
    {
        Task<IEnumerable<GetUserAnimalResponse>> Execute(Guid userId);
    }
    internal class GetUserAnimals : IGetUserAnimals
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;

        public GetUserAnimals(IMapper mapper, IAnimalRepository animalRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
        }

        public async Task<IEnumerable<GetUserAnimalResponse>> Execute(Guid userId)
        {
            var userAnimals = await _animalRepository.GetUserAnimals(userId);
            IEnumerable<GetUserAnimalResponse> response = userAnimals.Select(ua => _mapper.Map<GetUserAnimalResponse>(ua));

            return response;
        }
    }
}
