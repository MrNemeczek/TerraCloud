using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Persistence.Interfaces.Repository.Animal;
using TerraCloud.Persistence.Interfaces.Repository.Database;

namespace TerraCloud.Application.Animal.Commands
{
    public interface IAddAnimalToUserList
    {
        Task Execute(AddAnimalToUserListRequest request, Guid userId);
    }
    internal class AddAnimalToUserList : IAddAnimalToUserList
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public AddAnimalToUserList(IAnimalRepository animalRepository, IDatabaseRepository databaseRepository)
        {
            _animalRepository = animalRepository;
            _databaseRepository = databaseRepository;
        }

        public async Task Execute(AddAnimalToUserListRequest request, Guid userId)
        {
            await _animalRepository.AddAnimalUser(request.Id, userId);
            await _databaseRepository.SaveChangesAsync();
        }
    }
}
