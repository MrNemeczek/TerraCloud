namespace TerraCloud.Infrastructure.IoTHub
{
    public class IoTHubOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string ConnectionStringClient { get; set; } = null!;
        public string ThisDeviceID { get; set; } = null!;
    }
}
