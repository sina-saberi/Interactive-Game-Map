using Interactive_Map_Navigation.Helpers;
using Interactive_Map_Navigation.Services;
using Interactive_Map_WindowsApplication.Commands;
using Interactive_Map_WindowsApplication.Services;
using Interactive_Map_WindowsApplication.ViewModels.Dtos;
using Interactive_Map_WindowsApplication.ViewModels.Layouts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Interactive_Map_WindowsApplication.ViewModels.Pages
{
    public class GameListViewModel : PageBase
    {
        public ObservableCollection<GameListItemDtoViewModel>? Games { get; set; }


        [Inject]
        public NavigationService? NavigationService { get; set; }

        [Inject]
        public GameService? Service { get; set; }



        public ICommand NavigateToMapCommand { get; }

        public async Task GetData()
        {
            if (Service is null) return;
            var games = await Service.GetGames();
            Games = new(games);
            OnPropertyChanged(nameof(Games));
        }

        private void NavigateToMap(GameListItemDtoViewModel? game)
        {
            if (game is null)
                return;

            NavigationService?.Navigate(() => new MapListViewModel(game.Slug));
        }

        public override void OnReady()
        {
            Task.Run(GetData);
            base.OnReady();
        }

        public GameListViewModel()
        {
            Layout = new MainLayoutViewModel();
            NavigateToMapCommand = new RelayCommand<GameListItemDtoViewModel>(NavigateToMap);
        }
    }
}
