using Cinema.Client.ViewModels;
using System.Net;

namespace Cinema.Client.Api
{
    class Api
    {
        public MainWindowViewModel MainWindowViewModel { get; private set; }
        public HubClient HubClient { get; private set; }

        public Api(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            HubClient = new HubClient(this);
        }

        public async void CreateOrder()
        {
            var selectedFilmSession = MainWindowViewModel.SelectedFilmSession;
            var request = WebRequest.Create("https://localhost:44349/api/orders");
            request.Method = "POST";
            var sName = $"FilmSessionId={selectedFilmSession.Id}&SeatsCount={selectedFilmSession.SeatsCountToBuy}";
            MainWindowViewModel.SelectedFilmSession = null;
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(sName);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            using var dataStream = request.GetRequestStream();
            await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
        }
    }
}
