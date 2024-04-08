using Microsoft.AspNetCore.Components;

namespace TerraCloud.Client.Pages.Device
{
    public class DetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = null!;
    }
}
