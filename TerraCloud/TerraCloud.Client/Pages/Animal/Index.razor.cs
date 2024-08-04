using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.DTOs.Error;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Animal
{
    public class IndexBase : ComponentBase
    {
        protected IEnumerable<GetAnimalResponse> animals;

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            animals = await _apiRequest.GetAsync<IEnumerable<GetAnimalResponse>>("Animal");
        }

        public void GoToDetails(Guid animalId)
        {
            _navManager.NavigateTo($"animal/details/{animalId}");
        }
    }
}
