using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Animal
{
    public class CreateBase : ComponentBase
    {
        protected AddAnimalUserRequest animalRequest { get; set; } = new AddAnimalUserRequest();

        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;

        protected async Task OnAnimalAdd(AddAnimalUserRequest request)
        {
            var result = await _apiRequest.OnlyPostAsync("Animal/AnimalUser", request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Animal created", Duration = 5000 });
                _navManager.NavigateTo("useranimals");
            }
        }
        protected void QuitClick()
        {
            _navManager.NavigateTo($"useranimals");
        }
    }
}
