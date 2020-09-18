using Cinema.Client.Comands;
using Cinema.Client.Models;
using System.Collections.ObjectModel;

namespace Cinema.Client.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        private readonly Api.Api api;
        public MainWindowViewModel()
        {
            api = new Api.Api(this);
        }

        private ObservableCollection<FilmSession> filmSessions;
        public ObservableCollection<FilmSession> FilmSessions 
        {
            get => filmSessions;
            set
            {
                filmSessions = value;

                OnPropertyChanged();
            } 
        }

        private FilmSession selectedFilmSession;
        public FilmSession SelectedFilmSession
        {
            get => selectedFilmSession;
            set
            {
                if (selectedFilmSession != null)
                    selectedFilmSession.SeatsCountToBuy = 0;
                selectedFilmSession = value;

                OnPropertyChanged();
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??= new RelayCommand(obj =>
                  {
                      api.CreateOrder();
                  });
            }
        }
    }
}
