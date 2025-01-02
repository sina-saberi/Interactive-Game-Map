using AutoMapper;
using Interactive_Map.Application.Services.Game;
using Interactive_Map_WindowsApplication.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Services
{
    public class GameService
    {
        private readonly IMapper mapper;
        private readonly GetGameListService service;

        public GameService(IMapper mapper, GetGameListService service)
        {
            this.mapper = mapper;
            this.service = service;
        }
        public async Task<IReadOnlyList<GameListItemDtoViewModel>> GetGames()
        {
            var games = await service.ExecuteAsync();
            return mapper.Map<IReadOnlyList<GameListItemDtoViewModel>>(games);
        }
    }
}
