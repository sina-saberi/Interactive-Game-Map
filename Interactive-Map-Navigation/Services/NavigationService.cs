using Interactive_Map_Navigation.Helpers;
using Interactive_Map_Navigation.Interfaces;
using Interactive_Map_Navigation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Navigation.Services
{
    public class NavigationService(NavigationStore navigationStore, IServiceProvider serviceProvider)
    {
        private readonly NavigationStore _navigationStore = navigationStore;
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        public bool CanNavigateBack => _navigationStore?.History.Count > 1;

        public void Navigate<TViewModel>(Func<TViewModel> func) where TViewModel : INavigate
        {
            var page = func();
            page.InjectProperties(_serviceProvider);
            _navigationStore.CurrentViewModel = page.SortPageAndLayouts();
            page.NorifyReadyOnPageAndLayouts();
        }

        public void GoBack()
        {
            if (!CanNavigateBack) return;
            _navigationStore.RemoveCurrentViewModel();
        }
    }
}
