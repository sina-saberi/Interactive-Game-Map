using AutoMapper;
using Interactive_Map.Application.Interfaces;
using Interactive_Map.Domain.Entities;
using Interactive_Map.MapGenie;
using Interactive_Map.MapGenie.MapGenieData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.MapGenie
{
    public class MapGenieSynchronizeService
    {
        private readonly IMapper _mapper;
        private readonly IGameMapsDbContext _context;
        private readonly TimeSpan _threshold;
        public MapGenieSynchronizeService(IMapper mapper, IGameMapsDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _threshold = TimeSpan.FromDays(3);
        }


        public async Task SyncGames(IList<Domain.Entities.Game> games)
        {
            var mapGenieGames = await MapGenieGame.GetAll();
            if (mapGenieGames is null) return;


            var response = _mapper.Map<IEnumerable<Domain.Entities.Game>>(mapGenieGames);

            foreach (var mg in response)
            {
                var currentGame = games.FirstOrDefault(x => x.Slug.ToLower().Trim().Equals(mg.Slug.ToLower().Trim()));
                if (currentGame != null) currentGame.Update(mg);
                else games.Add(mg); _context.Games.Attach(mg);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SyncMaps(Domain.Entities.Game game)
        {
            if (!HasExceededTimeSinceLastSync(game.LastSynced)) return;


            var result = await MapGenieGame
                .Get(x => x.Slug == game.Slug)
                .GetMaps();

            if (result is null) return;

            var mapGenieMaps = _mapper.Map<IEnumerable<Domain.Entities.Map>>(
                result,
                opt => opt.Items["GameId"] = game.Id
            );

            foreach (var mm in mapGenieMaps)
            {
                var currentMap = game.Maps?.FirstOrDefault(x => x.Slug == mm.Slug);
                if (currentMap != null) currentMap.Update(mm);
                else game.AddMap(mm);
            }

            game.Update(game.Name, game.Slug, true, DateTime.Now);
            await _context.SaveChangesAsync();
        }

        public async Task SyncMapData(Domain.Entities.Map map)
        {
            if (!HasExceededTimeSinceLastSync(map.LastSynced)) return;

            if (map.Game is null) throw new Exception("game is not included");

            var result = await MapGenieGame
                .Get(x => x.Slug == map.Game.Slug)
                .GetMap(x => x.Slug == map.Slug)
                .GetMapData();

            if (result is null) return;

            map.AddOrUpdateMapConfig(_mapper.Map<MapConfig>(result.MapConfig));


            var dto = _mapper.Map<IEnumerable<Domain.Entities.Group>>(result.Groups,
               x => x.Items["Locations"] = result.Locations.ToList()
            );

            map.Groups.AddOrUpdate(dto,
                    (a, b) => a.RefrenceId == b.RefrenceId,
                    (a, b) => a.Update(b),
                    (a) => map.AddGroup(a),
                    OnGroupUpdated
            );


            map.Update(map.Name, map.Slug, true, DateTime.Now);

            await _context.SaveChangesAsync();

            await ChangeLocationIdsInDescription(map);

            await _context.SaveChangesAsync();
        }

        private static void OnGroupUpdated(Domain.Entities.Group existingEntity, Domain.Entities.Group newEntity)
        {
            existingEntity.Categories.AddOrUpdate(
                           newEntity.Categories,
                           (a, b) => a.RefrenceId == b.RefrenceId,
                           (a, b) => a.Update(b),
                           (a) => existingEntity.AddCategory(a),
                           OnCategoryUpdated
                );
        }

        private static void OnCategoryUpdated(Category existingEntity, Category newEntity)
        {
            existingEntity.Locations.AddOrUpdate(
                        newEntity.Locations,
                        (a, b) => a.RefrenceId == b.RefrenceId,
                        (a, b) => a.Update(b),
                        (a) => existingEntity.AddLocation(a),
                        OnLocationUpdated
             );
        }

        private static void OnLocationUpdated(Location existingEntity, Location newEntity)
        {
            existingEntity.Medias.AddOrUpdate(
                       newEntity.Medias,
                       (a, b) => a.FileName == b.FileName,
                       (a, b) => a.Update(b),
                       existingEntity.AddMedia
            );
        }

        private bool HasExceededTimeSinceLastSync(DateTime? LastSynced)
        {
            if (!LastSynced.HasValue) return true;

            var timeElapsed = DateTime.UtcNow - LastSynced.Value;

            return timeElapsed > _threshold;
        }

        private async Task ChangeLocationIdsInDescription(Domain.Entities.Map map)
        {
            var locations = await _context.Locations
                .Include(x => x.Category!)
                .ThenInclude(x => x.Group!)
                .ThenInclude(x => x.Map)
                .Where(x => x.Category!.Group!.Map!.GameId == map.GameId)
                .ToListAsync();



            foreach (var group in map.Groups)
            {
                foreach (var category in group.Categories)
                {
                    foreach (var location in category.Locations)
                    {
                        location.Update(
                            location.Title, ReplaceLocationUrlWithGuids(location.Description, locations),
                            location.Latitude, location.Longitude,
                            location.Type, location.RefrenceId
                        );
                    }
                }
            };
        }

        public static string? ReplaceLocationUrlWithGuids(string? markdown, List<Location> locations)
        {
            if (string.IsNullOrEmpty(markdown) || locations == null) return markdown;

            string pattern = @"\((https?://[^/]+(/[^\?]*)?\?locationIds=\d+)\)";
            return Regex.Replace(markdown, pattern, match =>
            {
                string originalUrl = match.Groups[1].Value;
                string path = match.Groups[2].Value ?? string.Empty;

                var locationId = GetQueryParameterValue(originalUrl, "locationIds");
                if (locationId == null) return match.Value;

                var location = locations.FirstOrDefault(l => (l.RefrenceId ?? "").ToString().Equals(locationId));
                if (location == null) return match.Value;

                string newUrl = $"{path}/locationId={location.Id}".TrimStart('/');
                return $"({newUrl})";
            });
        }

        public static string? GetQueryParameterValue(string url, string parameterName)
        {
            var match = Regex.Match(url, $@"[?&]{parameterName}=([^&]+)");
            return match.Success ? match.Groups[1].Value : null;
        }
    }
}
