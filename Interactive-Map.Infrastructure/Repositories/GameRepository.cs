using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Infrastructure.Context;
using Interactive_Map.WebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Repositories
{
    public class GameRepository(GameMapsDbContext context) : RepositoryBase<Game, Guid>(context), IGameRepository
    {

        public async Task GetAllMapGenieGames()
        {
            try
            {
                var result = await MapGenieGame.GetAll();
            }
            catch { }
        }

        public override async Task<IEnumerable<Game>> GetAll()
        {
            var result = await base.GetAll();

            return result;
        }
    }
}
