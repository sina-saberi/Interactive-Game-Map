using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Infrastructure.Context;

namespace Interactive_Map.Infrastructure.Repositories
{
    public class GameRepository(GameMapsDbContext context, IMapper mapper) : RepositoryBase<Game, Guid>(context), IGameRepository
    {
        
    }
}
