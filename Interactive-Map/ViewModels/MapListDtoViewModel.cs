using Interactive_Map.Application.DTOs;
using Interactive_Map.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interactive_Map.ViewModels
{
    public class MapListDtoViewModel(GameListDto dto, ICommand clickCommand) : ViewModelBase
    {
        private readonly GameListDto _dto = dto;

        public string Name => _dto.Name;
        public string Slug => _dto.Slug;

        public ICommand ClickCommand { get; } = clickCommand;
    }
}
