using System.Net;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Application.Exceptions.Animal
{
    public sealed class AnimalNotFoundException : MyApplicationException
    {
        public AnimalNotFoundException(Guid id) : base($"Animal with ID: {id} not found!", ErrorCode.AnimalNotFound, HttpStatusCode.NotFound)
        {
            
        }
    }
}
