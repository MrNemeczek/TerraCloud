using TerraCloud.Application.DTOs.Auth.Requests;

namespace TerraCloud.Application.Interfaces.Auth
{
    public interface IRegistryService
    {
        Task Registry(RegisterRequest registerRequest);
    }
}
