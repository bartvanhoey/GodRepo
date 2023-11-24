using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using SimpleVideoGameLibrary.Shared;

namespace SimpleVideoGameLibrary.Client.Pages
{
    public class EditVideoGameBase : ComponentBase
    {
        [Parameter]
        public int? Id { get; set; }

        [Inject] protected NavigationManager? NavigationManager { get; set; }

        [Inject] public HttpClient? Http { get; set; }

        public VideoGame VideoGame = new() { Title = "New Game" };

        protected async void HandleValidSubmitAsync()
        {
            if (Id == null) await Http!.PostAsJsonAsync("api/videogame", VideoGame);
            else await Http!.PutAsJsonAsync($"api/videogame/{Id}", VideoGame);

            NavigationManager!.NavigateTo("videogames", false);
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id != null)
            {
                var response = await Http!.GetFromJsonAsync<VideoGame>($"api/videogame/{Id}");
                if (response != null) VideoGame = response;
            }
        }

        public async Task DeleteVideoGameAsync()
        {
            await Http!.DeleteAsync($"api/videogame/{Id}");
            NavigationManager!.NavigateTo("videogames", false);
        }


    }
}