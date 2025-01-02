using Interactive_Map_Navigation.Helpers;
using Interactive_Map_Navigation.Services;
using Interactive_Map_WindowsApplication.Commands;
using System.Windows.Input;

namespace Interactive_Map_WindowsApplication.ViewModels.Layouts
{
    public class MainLayoutViewModel : LayoutBase
    {
        [Inject]
        public NavigationService? NavigationService { get; set; }

        public ICommand NavigateBackCommand { get; }

        public bool CanNavigateBack => NavigationService?.CanNavigateBack ?? false;

        private void NavigateBack(object? args)
        {
            NavigationService?.GoBack();
        }

        public override void OnReady()
        {
            OnPropertyChanged(nameof(CanNavigateBack));
        }

        public MainLayoutViewModel()
        {
            NavigateBackCommand = new RelayCommand(NavigateBack);
        }
    }
}
