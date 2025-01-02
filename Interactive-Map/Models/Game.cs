using Interactive_Map.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Models
{
    public class Game
    {
        public Task<List<GameListDto>> GetAllGames()
        {
            var games = new List<GameListDto>();
            for (int i = 0; i <= 10; i++) games.Add(new GameListDto("name", "slug"));
            return Task.FromResult(games);
        }
    }
}
