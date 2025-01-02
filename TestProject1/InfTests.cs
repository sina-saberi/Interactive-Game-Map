using Interactive_Map.Application.Interfaces;
using Interactive_Map.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class InfTests
    {
        private readonly IGameRepository _gameRepository;
        public InfTests()
        {
            var startup = new Startup();
            _gameRepository = startup.Services.GetRequiredService<IGameRepository>();
        }

        [Fact]
        public async Task Test()
        {
            var result = await _gameRepository.GetAll();
        }
    }
}
