using Interactive_Map.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class GroupDto
    {
        public string Title { get; set; } = null!;
        public IEnumerable<CategoryDto> Categories { get; set; } = [];
    }
}
