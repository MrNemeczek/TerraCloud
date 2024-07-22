using Microsoft.AspNetCore.Components;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Animal
{
    public class DetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = null!;
        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;

        protected GetAnimalResponse animal = null!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            animal = await _apiRequest.GetAsync<GetAnimalResponse>($"Animal/{Id}");
        }
    }
}
