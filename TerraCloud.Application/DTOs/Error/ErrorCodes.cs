namespace TerraCloud.Application.DTOs.Error
{
    public enum ErrorCode
    {
        LoginExists = 1,
        EmailExists,
        ApplicationError,
        AnimalNotFound,
        AnimalNotOwner,
        DeviceAlreadyAdded,
        DeviceNotFound
    }
}
