using AutoMapper;
using Microsoft.AspNetCore.Components;
using Radzen;
using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Client.Common;
using TerraCloud.Domain.Models.Animal;

namespace TerraCloud.Client.Pages.Animal
{
    public class EditBase : ComponentBase
    {
        protected UpdateAnimalRequest animalUpdateRequest { get; set; } = new UpdateAnimalRequest();

        [Parameter]
        public string Id { get; set; } = null!;
        [Inject]
        private IApiRequest _apiRequest { get; set; } = default!;
        [Inject]
        NotificationService _notificationService { get; set; } = default!;
        [Inject]
        private NavigationManager _navManager { get; set; } = default!;
        [Inject]
        private IMapper _mapper { get; set; } = default!;

        protected GetAnimalResponse animal = null!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            animal = await _apiRequest.GetAsync<GetAnimalResponse>($"Animal/{Id}");
            animalUpdateRequest = _mapper.Map<UpdateAnimalRequest>(animal);
        }
        protected async Task OnAnimalEdit(UpdateAnimalRequest request)
        {
            var result = await _apiRequest.OnlyPatchAsync("Animal", request);
            if (result is not null)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = result.Describe, Duration = 5000 });
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Succes", Detail = "Animal updated", Duration = 5000 });
                _navManager.NavigateTo("animal");
            }
        }
    }
}
