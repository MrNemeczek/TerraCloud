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

        public async Task AddAnimal()
        {
            _navManager.NavigateTo("animal/create");
        }

        public async Task Delete(Guid deviceId)
        {
            ErrorResponse? result = await _apiRequest.DeleteAsync($"Animal/{deviceId}");
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Animal deleted", Duration = 5000 });
                _navManager.NavigateTo(_navManager.Uri, true);
            }
        }
        public void GoToDetails(Guid animalId)
        {
            _navManager.NavigateTo($"animal/details/{animalId}");
        }
    }
}
