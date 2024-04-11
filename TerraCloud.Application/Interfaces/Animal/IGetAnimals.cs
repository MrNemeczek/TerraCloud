using TerraCloud.Application.DTOs.Animal.Responses;

namespace TerraCloud.Application.Interfaces.Animal
{
    public interface IGetAnimals
    {
        Task<IEnumerable<GetAnimalResponse>> Execute();
    }
}
