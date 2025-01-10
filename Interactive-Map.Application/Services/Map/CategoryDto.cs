using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Services.Map
{
    public class CategoryDto
    {
        public Guid GroupId { get; set; }
        public string Title { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
