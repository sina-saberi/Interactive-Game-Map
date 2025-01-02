using Interactive_Map.Stores;
using Interactive_Map.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Services
{
    public class NavigationService<TViewModel>(NavigationStore navigationStore, IServiceProvider provider) where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore = navigationStore;

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = provider.GetRequiredService<TViewModel>();
        }
    }
}
