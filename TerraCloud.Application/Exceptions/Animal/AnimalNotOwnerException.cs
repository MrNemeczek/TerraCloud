namespace TerraCloud.Application.Exceptions.Animal
{
    public sealed class AnimalNotOwnerException : Exception
    {
        public AnimalNotOwnerException(Guid animalId, Guid userId) : base($"User with ID: {userId} dont have edit permissions to animal with ID: {animalId}")  
        {
            
        }
    }
}
