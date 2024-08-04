namespace TerraCloud.Application.Exceptions.Animal
{
    public sealed class AnimalNotFoundException : Exception
    {
        public AnimalNotFoundException(Guid id) : base($"Animal with ID: {id} not found!")
        {
            
        }
    }
}
