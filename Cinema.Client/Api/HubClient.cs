using Cinema.Client.Models;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Cinema.Client.Api
{
    class HubClient
    {
        private readonly Api api;

        public HubClient(Api api)
        {
            Connect();

            this.api = api;
        }

        private void SetFilmSessions(object obj)
        {
            var str = obj as string;

            api.MainWindowViewModel.FilmSessions = JsonConvert.DeserializeObject<ObservableCollection<FilmSession>>(str);
        }

        private HubConnection HubConnection { get; set; }
        private IHubProxy HubProxy { get; set; }

        private async void Connect()
        {
            HubConnection = new HubConnection("https://localhost:44349/");
            HubProxy = HubConnection.CreateHubProxy("AppHub");
            HubProxy.On("SetFilmSessions", obj => SetFilmSessions(obj));
            await HubConnection.Start();
        }
    }
}
