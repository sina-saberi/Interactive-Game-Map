using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Interactive_Map.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Infrastructure.Repositories
{
    public class MapRepository(GameMapsDbContext context) : RepositoryBase<Map, Guid>(context), IMapRepository
    {
        
    }
}
