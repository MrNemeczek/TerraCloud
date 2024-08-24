namespace TerraCloud.Application.DTOs.Auth.Requests
{
    public class LoginDeviceRequest
    {
        public string UniqueCode { get; set; }
        /// <summary>
        /// Device ID
        /// </summary>
        public Guid Id { get; set; }
    }
}
