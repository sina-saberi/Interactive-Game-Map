using Interactive_Map.Application.Services.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Services
{
    public class TileService
    {
        private readonly GetTileService getTileService;

        public TileService(GetTileService getTileService)
        {
            this.getTileService = getTileService;
        }

        public async Task<byte[]?> GetTileAsync(string pattern)
        {
            return await getTileService.ExecuteAsync(pattern);
        }
    }
}
