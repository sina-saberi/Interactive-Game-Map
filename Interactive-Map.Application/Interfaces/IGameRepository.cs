using Interactive_Map.Domain.Base;
using Interactive_Map.Domain.Entities;

namespace Interactive_Map.Application.Interfaces;

public interface IGameRepository : IRepositoryBase<Game, Guid>
{
}