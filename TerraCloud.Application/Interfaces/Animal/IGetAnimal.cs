using TerraCloud.Application.DTOs.Animal.Responses;

namespace TerraCloud.Application.Interfaces.Animal
{
    public interface IGetAnimal
    {
        Task<GetAnimalResponse> Execute(Guid animalId);
    }
}
