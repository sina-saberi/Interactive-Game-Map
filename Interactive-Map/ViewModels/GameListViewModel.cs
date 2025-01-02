using Interactive_Map.Application.DTOs;
using Interactive_Map.Commands;
using Interactive_Map.Services;
using Interactive_Map.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interactive_Map.ViewModels
{
    public class GameListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MapListDtoViewModel> _games;

        public IEnumerable<MapListDtoViewModel> Games => _games;


        public GameListViewModel(NavigationService<MapListViewModel> navigation)
        {

            _games = [];
            for (int i = 0; i < 100; i++)
            {
                var values = (i + 1).ToString();
                var gameDto = new GameListDto("name" + values, "slug" + values);
                var command = new RelayCommand(_ => navigation.Navigate());
                _games.Add(new MapListDtoViewModel(gameDto, command));
            }
        }
    }
}
