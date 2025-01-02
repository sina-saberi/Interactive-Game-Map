using Interactive_Map_Navigation;
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
    public class MapListViewModel : PageBase
    {
        [Inject]
        public MapService? Service { get; set; }
        [Inject]
        public NavigationService? NavigationService { get; set; }
        public ObservableCollection<MapListItemDtoViewModel>? Maps { get; set; }
        public ICommand NavigateToMapCommand { get; set; }
        public string Slug { get; set; }



        public async Task GetData()
        {
            if (Service is null) return;
            var maps = await Service.GetAllMaps(Slug);
            Maps = new(maps);
            OnPropertyChanged(nameof(Maps));
        }

        public override void OnReady()
        {
            Task.Run(GetData);
            base.OnReady();
        }
        private void NavigateToMap(MapListItemDtoViewModel? dto)
        {
            if (dto is null || NavigationService is null) return;
            NavigationService.Navigate(() => new MapViewModel(Slug, dto.Slug));
        }

        public MapListViewModel(string slug)
        {
            Slug = slug;
            Layout = new MainLayoutViewModel();
            NavigateToMapCommand = new RelayCommand<MapListItemDtoViewModel>(NavigateToMap);
        }
    }
}
