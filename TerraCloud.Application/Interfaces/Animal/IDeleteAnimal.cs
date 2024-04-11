namespace TerraCloud.Application.Interfaces.Animal
{
    public interface IDeleteAnimal
    {
        Task Execute(string animalId);
    }
}
