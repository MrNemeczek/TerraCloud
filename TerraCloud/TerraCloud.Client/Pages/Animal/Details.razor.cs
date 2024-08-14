using Microsoft.AspNetCore.Components;
using Radzen;

using TerraCloud.Application.DTOs.Animal.Requests;
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
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;

        protected GetAnimalResponse animal = null!;
        protected AddAnimalToUserListRequest request = new();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            animal = await _apiRequest.GetAsync<GetAnimalResponse>($"Animal/{Id}");
        }

        protected void QuitClick()
        {
            _navManager.NavigateTo("useranimals");
        }

        protected async Task AddAnimalToMyListClick()
        {
            request.Id = Guid.Parse(Id);

            var result = await _apiRequest.OnlyPostAsync("Animal/AddAnimalToUserList", request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Animal added to your list", Duration = 5000 });
                _navManager.NavigateTo("useranimals");
            }
        }
    }
}
