using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions.Animal
{
    public sealed class AnimalNotOwnerException : MyApplicationException
    {
        public AnimalNotOwnerException(Guid animalId, Guid userId) : base($"User with ID: {userId} dont have edit permissions to animal with ID: {animalId}", ErrorCode.AnimalNotOwner, HttpStatusCode.Unauthorized)  
        {
            
        }
    }
}
