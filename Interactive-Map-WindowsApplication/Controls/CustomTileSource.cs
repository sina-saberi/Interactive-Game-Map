using BruTile;
using BruTile.Cache;
using BruTile.Web;
using Interactive_Map_WindowsApplication.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Controls
{
    public class CustomTileSource : ITileSource, ILocalTileSource
    {
        private readonly string _name;
        private readonly TileService? _tileService;
        private readonly ITileSchema _tileSchema;
        private readonly string _pattern;
        private readonly Func<string, Task<byte[]?>> _funct;

        public CustomTileSource(ITileSchema tileSchema, string pattern, string name, Func<string, Task<byte[]?>> funct)
        {
            _tileSchema = tileSchema;
            _pattern = pattern;
            _name = name;
            _funct = funct;
        }

        public ITileSchema Schema => _tileSchema;

        public string Name => _name;

        public Attribution Attribution { get; set; }

        public async Task<byte[]?> GetTileAsync(TileInfo tileInfo)
        {
            var pattern = _pattern
              .Replace("{z}", tileInfo.Index.Level.ToString())
              .Replace("{x}", tileInfo.Index.Col.ToString())
              .Replace("{y}", tileInfo.Index.Row.ToString());

            return await _funct.Invoke(pattern);
        }
    }
}
